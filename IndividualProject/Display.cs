using System;
using System.Collections.Generic;


namespace IndividualProject
{

    static class Display
    {
        public static void Courses(List<Course> courses)
        {
            Console.WriteLine("\t\t Courses");
            foreach (Course a in courses)
            {
                Console.WriteLine(a);
            }
        }
        public static void Trainers(List<Trainer> trainers)
        {
            Console.WriteLine("Trainers\n");
            Console.WriteLine("ID. FullName\t\tSubject");
            foreach (Trainer a in trainers)
            {
                Console.Write($"{a}");
            }
        }
        public static void Students(List<Student> students)
        {
            Console.WriteLine("Students\n");
            foreach (Student a in students)
            {
                Console.Write($"\nID {a.Id}. FullName: {a.FullName}\nDate of Birth: {a.Dateofbirth:dd/MM/yyyy}\nTuition Fee: {a.TuitionFee:0.00}\u20AC\n");
                int i = 0;
                while (i < a.Courses.Count)
                {
                    Console.Write($"Course n{i + 1}: {a.Courses[i].Title}\n");
                    i++;
                }
            }
            Console.WriteLine("");
        }
        public static void Assignments(List<Assignment> assignments)
        {
            Console.WriteLine("Assignments\n");
            foreach (Assignment a in assignments)
            {
                Console.Write($"\nID {a.Id}. Title: {a.Title}\nDescription: {a.Description}\nMax Oral: {a.OralMark} Max Total: {a.TotalMark}\nSubmission Date: {a.Submission:dd/MM/yyyy}\n");
                int i = 0;
                while (i < a.Courses.Count)
                {
                    Console.Write($"Course n{i + 1} {a.Courses[i].Title}\n");
                    i++;
                }
            }
            Console.WriteLine("");
        }
        public static void StudentMoreThanOneCourse(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("ID.FullName \t TuitionFee");
            bool check = false;
            foreach (Student st in students)
            {
                if (st.Courses.Count > 1)
                {
                    check = true;
                    Console.WriteLine(st);
                    foreach (Course a in st.Courses)
                    {
                        Console.WriteLine($"ID. Course Title \t Stream \t Starting    \t Ending Date:\n{a}");
                    }
                }
                Console.WriteLine("");
            }
            if (check == false)
            {
                Console.WriteLine("None of students belong to more than one course");
            }
        }
        public static void Submission(List<Assignment> assignments)
        {
            Console.Clear();
            Console.Write("Give Date to check who students have to submit their assignment to that week" +
                   $"\nDate must be between {DateTime.Now.AddDays(1):d} and {DateTime.Now.AddMonths(12):d}\n\n (dd/MM/yyyy)\n>");
            DateTime date = Input.Dates(DateTime.Now.AddDays(1), DateTime.Now.AddMonths(12));
            bool check = false;
            int diff = date.DayOfWeek - DayOfWeek.Monday;
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(-6);
                diff = 6;
            }
            else { date = date.AddDays(-diff); }
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                foreach (Assignment a in assignments)
                {
                    if (a.Submission.Date == date.Date)
                    {
                        check = true;
                        Console.WriteLine($"Submission Date:{a.Submission:dd/MM/yyyy}");
                        a.StudentDisplay();
                    }
                }
                date = date.AddDays(1);
            }
            if (check == false)
            {
                Console.WriteLine("No assignment have to be submitted at that week");
            }
        }
    }
}
