using System;
using System.Collections.Generic;

namespace IndividualProject
{
    class Assignment
    {
        private static int idt = 1;
        public int Id { get; private set; }
        public string Title
        { get; set; }
        public string Description
        { get; set; }
        public DateTime Submission
        { get; set; }
        public double OralMark
        { get; set; }
        public double TotalMark
        { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public Assignment(string title, string description, DateTime submission, double oral, double total)
        {
            Title = title;
            Description = description;
            Submission = submission;
            OralMark = oral;
            TotalMark = total;
            IdInsert();
        }
        public Assignment()
        {

        }
        //Inserts
        public void IdInsert()
        {
            Id = idt;
            idt++;
        }
        public void TitleInsert(List<Assignment> assignments)
        {
            do
            {
                Console.Clear();
                string title;
                Console.WriteLine("You can quit if you type 'exit'");
                Console.Write("Give Title for the Assignment\n>");
                title = Console.ReadLine();
                title.Trim();
                if (Check.StringEquals(title, "exit")) { Title = "exit"; return; }
                Title = title;
            } while (CheckTitle(assignments));
        }
        public void DescriptionInsert()
        {
            Console.Clear();
            string description;
            Console.Write("Give Description for the Assignment\n>");
            description = Console.ReadLine();
            description.Trim();
            Description = description;
        }
        public void SubmissionInsert()
        {
            Console.Clear();
            Console.WriteLine($"Give the Submission Date ({this.Title})");
            Console.Write($"From: {DateTime.Now.AddDays(1):d} To: {DateTime.Now.AddMonths(12):d} \n\n (dd/MM/yyyy)\n>");
            Submission = Input.Dates(DateTime.Now, DateTime.Now.AddMonths(12));
            if (this.Submission.DayOfWeek == DayOfWeek.Saturday || this.Submission.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Submission cannot be at weekend!Do you want to be next week?<Y> or <N>?\nIf <N> it will be at previous.");
                if (Check.YesOrNo())
                {
                    Submission = Submission.AddDays(2);
                }
            }
        }
        public void MarksInsert()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("Give marks for the assignment.Max Total value is 100");
                Console.Write("The maximum mark for the oral presentation is:\n\n------\n>");
                OralMark = Input.Double(0, 100);
                Console.Write($"The max of oral mark is:{this.OralMark}.The maximum mark for the paper of the assginment is {100 - OralMark}" +
                    $"\nDo you want to proceed? <Y> or <N> ?");
            } while (!Check.YesOrNo());
            TotalMark = 100 - OralMark;
        }
        public void CourseInsert(List<Course> courses)
        {
            Console.Clear();
            if (Check.ListEmpty(courses)) { SyntheticData.Courses(courses); }
            int n;
            do
            {
                Console.WriteLine("Choose a course for student to register:");
                Display.Courses(courses);
                Console.Write($"{courses.Count + 1}.Exit\n>");
                n = Input.Integer(1, courses.Count + 1);
                if (n == courses.Count + 1) { return; }
                Console.Clear();
            } while (!CheckCourse(courses, n)); //ελεγχος για το αν ειναι ηδη ανατεθιμενη στο τμημα
            {
                Console.WriteLine($"{Title} is registered to course: {courses[n - 1].Title}");
                this.Courses.Add(courses[n - 1]);
                courses[n - 1].Assignments.Add(this);
                Console.WriteLine("Do you want to register in other course?<Y> or <N> ?:");
                if (Check.YesOrNo())
                {
                    CourseInsert(courses);
                }
                else { Console.Clear(); return; }
                return;
            }
        }

        //checking
        public bool CheckTitle(List<Assignment> assignments)
        {
            bool checker = false;
            foreach (Assignment a in assignments)
            {
                if (a == null)
                {
                    checker = false;
                }
                else if (a.Title == Title)
                {
                    Console.WriteLine($"There is already an assignment with this title({Title})!\nGive title again:\nIf you want to quit type'exit'.");
                    checker = true;
                }
            }
            return checker;
        }
        public bool CheckCourse(List<Course> courses, int n)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (this.Courses[i].Title == courses[n - 1].Title)
                {
                    Console.WriteLine("The assignment is already assigned in this course.Please choose other option:");
                    return false;
                }
            }
            return true;
        }
        public void CourseDataInsert(List<Course> courses, int n) // γρηγορη μεθοδος για εισαγωγή synthetic data
        {
            if (Check.ListEmpty(courses))
            { SyntheticData.Courses(courses); }
            this.Courses.Add(courses[n]);
            courses[n].Assignments.Add(this);
        }

        //Displays
        public override string ToString()
        {
            return ($"{this.Id}. {this.Title}\t {this.Description}\t {this.Submission:d}\n");
        }
        public void InfoDisplay()
        {
            foreach (Course a in Courses)
            {
                Console.WriteLine($"ID. Course Title\t Starting    \t Ending Date:\n{a}");
                a.TrainersDisplay();
                a.StudentsDisplay();
                Console.WriteLine();
            }
        }
        public void StudentDisplay()
        {
            foreach (Course a in Courses)
            {
                if (a.Students.Count != 0)
                {
                    Console.WriteLine($"ID. Course Title\t Starting    \t Ending Date:\n{a}");
                    a.StudentsDisplay();
                    Console.WriteLine();
                }
            }

        }
    }
}
