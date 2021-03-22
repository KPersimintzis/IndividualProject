using System;
using System.Collections.Generic;

namespace IndividualProject
{
    static class SyntheticData
    {
        static public void Courses(List<Course> courses)
        {
            courses.Add(new Course("CB1 C# Full-Time", "C#", "Full-Time", new DateTime(2020, 09, 23), new DateTime(2021, 05, 04)));
            courses.Add(new Course("CB2 C# Part-Time", "C#", "Part-Time", new DateTime(2020, 09, 23), new DateTime(2021, 05, 04)));
            courses.Add(new Course("CB3 Java Full-Time", "Java", "Full-Time", new DateTime(2020, 09, 23), new DateTime(2021, 05, 04)));
            courses.Add(new Course("CB4 Java Part-Time", "Java", "Part-Time", new DateTime(2020, 09, 23), new DateTime(2021, 05, 04)));
            courses.Add(new Course("CB5 Python Full-Time", "Python", "Full-Time", new DateTime(2020, 09, 23), new DateTime(2021, 05, 04)));
            courses.Add(new Course("CB6 JS Part-Time", "Javascript", "Part-Time", new DateTime(2020, 09, 23), new DateTime(2021, 05, 04)));
        }
        static public void Trainers(List<Trainer> trainers, List<Course> courses)
        {
            trainers.Add(new Trainer("Zelimir", "Obradovic", "C#"));
            trainers.Add(new Trainer("Dusan", "Ivkovic", "C#"));
            trainers.Add(new Trainer("Giorgos", "Bartzokas", "Java"));
            trainers.Add(new Trainer("Giannis", "Sfairopoulos", "Java"));
            trainers.Add(new Trainer("Giorgos", "Paraschos", "Python"));
            trainers.Add(new Trainer("Aggelos", "Anastasiadis", "Python"));

            foreach (Trainer a in trainers)
            {
                a.CourseDataInsert(courses);
            }
        }
        static public void Students(List<Student> students, List<Course> courses)
        {
            students.Add(new Student("Juninho", "Pernambucano", new DateTime(1986, 12, 4)));
            students.Add(new Student("Giorgos", "Printezis", new DateTime(1977, 1, 2)));
            students.Add(new Student("Vagelis", "Mantzaris", new DateTime(1979, 12, 6)));
            students.Add(new Student("Kyle", "Hynes", new DateTime(1996, 11, 1)));
            students.Add(new Student("Stratos", "Perperoglou", new DateTime(1995, 10, 1)));
            students.Add(new Student("Tasos", "Pantos", new DateTime(1976, 6, 1)));
            students.Add(new Student("Lomana", "Lua-Lua", new DateTime(2000, 4, 1)));
            students.Add(new Student("Haruna", "Babangida", new DateTime(2001, 5, 1)));
            students.Add(new Student("Luis", "Diogo", new DateTime(1999, 12, 1)));
            students.Add(new Student("Felix", "Borha", new DateTime(1993, 12, 1)));
            students.Add(new Student("Nazario", "Ronaldo", new DateTime(1992, 2, 1)));
            students.Add(new Student("Diego", "Maradona", new DateTime(1991, 2, 1)));

            if (Check.ListEmpty(courses)) { return; } // για να γινει ενας καταμερισμος οσο γινεται ομοιομορφα στα courses
            int n = 0;                               // να αποφευχθει να μπουν ολοι οι μαθητες σε ολα τα τμηματα για να φανει καλυτερα η λειτουργια του προγραμματος
            int m = courses.Count - 1;
            foreach (Student a in students)
            {
                if (n >= courses.Count)
                { n = 0; m = courses.Count - 1; }
                a.CourseDataInsert(courses, n);
                if (m >= 0 && m != n)
                {
                    a.CourseDataInsert(courses, m);
                }
                n++;
                m--;
            }
        }
        static public void Assignments(List<Assignment> assignments, List<Course> courses) //οπως πανω στο students
        {
            assignments.Add(new Assignment("ICDL", "Basics of Programming", DateTime.Now.AddDays(5), 20, 80));
            assignments.Add(new Assignment("OOP_Beg", "Basics of OOP", DateTime.Now.AddMonths(1), 20, 80));
            assignments.Add(new Assignment("OOP_Int", "Intermediate of OOP", DateTime.Now.AddMonths(2), 20, 80));
            assignments.Add(new Assignment("OOP_Adv", "Advanced of OOP", DateTime.Now.AddMonths(3), 20, 80));
            assignments.Add(new Assignment("Project 1", "Individual Project", DateTime.Now.AddMonths(4), 20, 80));
            assignments.Add(new Assignment("Project 2", "Team Project", DateTime.Now.AddMonths(5), 20, 80));
            if (Check.ListEmpty(courses)) { return; }
            int n = 0;
            int m = courses.Count - 1;
            foreach (Assignment a in assignments)
            {

                if (n >= courses.Count)
                { n = 0; m = courses.Count - 1; }
                a.CourseDataInsert(courses, n);
                if (m >= 0 && m != n)
                {
                    a.CourseDataInsert(courses, m);
                }
                n++;
                m--;
            }
        }

    }
}
