using System;
using System.Collections.Generic;

namespace IndividualProject
{
    class Student
    {
        private static int ids = 1;
        public int Id { get; private set; }
        public string FirstName
        { get; set; }
        public string LastName
        { get; set; }

        public string FullName
        { get => FirstName + " " + LastName; }

        public DateTime Dateofbirth
        { get; set; }

        public decimal TuitionFee
        { get; private set; }

        public List<Course> Courses { get; set; } = new List<Course>();

        public Student(string first, string last, DateTime date)
        {
            FirstName = first;
            LastName = last;
            Dateofbirth = date;
            IdInsert();
        }
        public Student()
        {

        }

        //Inserts
        public void IdInsert()
        {
            Id = ids;
            ids++;
        }
        public void NameInsert(List<Student> students)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("You can quit if you type 'exit'");
                do
                {
                    Console.Write("Give First Name:\n>");
                    FirstName = Input.String().Trim();
                    if (Check.Exit(FirstName)) { FirstName = "exit"; return; } // μολις γραφτει exit η διαδικασια σταματαει
                    Console.Write($"You gave this first name {FirstName}\nDo you want to proceed? <Y> or <N>?:\n");//επιστρεφουμε exit και στο μενου ,με ελεγχο ,θα σταματησει η καταχωριση
                } while (!Check.YesOrNo());
                do
                {
                    Console.Write("Give Last Name:\n>");
                    LastName = Input.String().Trim();
                    if (Check.Exit(LastName)) { LastName = "exit"; return; }
                    Console.Write($"You gave this last name {LastName}\nDo you want to proceed? <Y> or <N>?:\n");
                } while (!Check.YesOrNo());
            } while (CheckNames(students));
        }
        public void DatesInsert()
        {
            Console.Clear();
            Console.WriteLine($"Give the Date of Birth for ({this.FullName})");

            Console.Write($"From: {DateTime.Now.AddYears(-80):d} To: {DateTime.Now.AddYears(-18):d} \n\n (dd/MM/yyyy)\n>");
            Dateofbirth = Input.Dates(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-18));
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
            } while (!CheckCourse(courses, n)); //ελεγχος για το αν ειναι εγγεγραμμενος ηδη ο μαθητης στο τμημα
            {
                Console.WriteLine($"{FullName} is registered to course: {courses[n - 1].Title}");
                this.Courses.Add(courses[n - 1]);   //προσθετω το τμημα στον μαθητη
                courses[n - 1].Students.Add(this); //προσθετω τον student στο τμημα (και γλιτώνω ακομα ενα ελεγχο)
                this.TuitionFee = 1500.0m - ((Courses.Count - 1) * 5.0m / 100.0m * 1500.0m);
                Console.WriteLine("Do you want to register in other course?Extra Discount 5%!<Y> or <N> ?:");
                if (Check.YesOrNo())
                {
                    CourseInsert(courses);
                }
                else { Console.Clear(); return; }
                return;
            }
        }
        public void CourseDataInsert(List<Course> courses, int n) // γρηγορη μεθοδος για εισαγωγή synthetic data
        {
            if (Check.ListEmpty(courses))
            { SyntheticData.Courses(courses); }
            this.Courses.Add(courses[n]);
            this.TuitionFee = 1500.0m - ((Courses.Count - 1) * 5.0m / 100.0m * 1500.0m);
            courses[n].Students.Add(this);

        }

        //Checkings
        public bool CheckNames(List<Student> students)
        {
            foreach (Student a in students)
            {
                if (a == null)
                {
                    return false;
                }
                else if (a.FirstName == this.FirstName && a.LastName == this.LastName)
                {
                    Console.WriteLine($"There is already a student with this name({FullName})!\nGive names again:\nIf you want to quit type'exit'.");
                    Console.Write("Press any button to continue...");
                    Console.ReadKey();
                    return true;
                }
            }
            return false;
        }
        public bool CheckCourse(List<Course> courses, int n) // ελεγχος για τον αν ειναι ηδη εγγεγραμμένος ο student
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (this.Courses[i].Title == courses[n - 1].Title)
                {
                    Console.WriteLine("The student is already registered in this course.Please choose other option:");
                    return false;
                }
            }
            return true;
        }

        //Displays
        public override string ToString()
        {
            return ($"{this.Id} {this.FullName}\t {this.TuitionFee}\u20AC\n");
        }
        public void InfoDisplay()
        {
            foreach (Course a in Courses)
            {
                Console.WriteLine($"ID. Course Title\t Starting    \t Ending Date:\n{a}");
                a.TrainersDisplay();
                a.AssignmentsDisplay();
                Console.WriteLine();
            }
        }
    }
}

