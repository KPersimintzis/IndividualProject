using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace IndividualProject
{
    class Trainer
    {
        private static int idt = 1;
        public int Id { get; private set; }
        public string FirstName
        { get; private set; }
        public string LastName
        { get; private set; }
        public string FullName
        { get => FirstName + " " + LastName; }
        public string Subject
        { get; private set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public Trainer(string first, string last, string subject)
        {
            FirstName = first;
            LastName = last;
            Subject = subject;
            IdInsert();
        }
        public Trainer()
        {

        }

        //Inserts
        public void IdInsert()
        {
            Id = idt;
            idt++;
        }
        public void NameInsert(List<Trainer> trainers)
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
            } while (CheckNames(trainers));
        }
        public void SubjectInsert()
        {
            Console.Clear();
            Console.WriteLine("Choose the subject for the trainer:");
            Console.Write("1.C#\n2.Java\n3.Javascript\n4.Python\n\n------\n>");
            int temp = Input.Integer(1, 4);
            switch (temp)
            {
                case 1: { this.Subject = "C#"; break; }
                case 2: { this.Subject = "Java"; break; }
                case 3: { this.Subject = "Javascript"; break; }
                case 4: { this.Subject = "Python"; break; }
            }
        }
        public void CourseInsert(List<Course> courses)
        {
            Console.Clear();
            if (Check.ListEmpty(courses)) { SyntheticData.Courses(courses); }
            int n;
            do
            {
                Console.WriteLine("Choose a course for trainer to register:");
                Display.Courses(courses);
                Console.Write($"{courses.Count + 1}.Exit\n>");
                n = Input.Integer(1, courses.Count + 1);
                if (n == courses.Count + 1) { return; }
                Console.Clear();
            } while (!CheckCourse(courses, n)); //ελεγχος αν ειναι ηδη εγγεγραμμενος ο trainer και αν ειναι το τμημα στο αντικειμενο του
            {
                Console.WriteLine($"{FullName} is registered to course: {courses[n - 1].Title}");
                this.Courses.Add(courses[n - 1]);   //προσθετω το τμημα στον trainer
                courses[n - 1].Trainers.Add(this); //προσθετω τον trainer στο τμημα (και γλιτώνω ακομα ενα ελεγχο)
                Console.WriteLine("Do you want to register in other course?<Y> or <N> ?:");
                if (Check.YesOrNo())
                {
                    CourseInsert(courses);
                }
                else { Console.Clear(); return; }
                return;
            }
        }
        public void CourseDataInsert(List<Course> courses) // γρηγορη μεθοδος για εισαγωγή synthetic data
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (this.Subject == courses[i].Stream)
                {
                    this.Courses.Add(courses[i]);
                    courses[i].Trainers.Add(this);
                }
            }
        }

        //Checkings
        public bool CheckNames(List<Trainer> trainers)
        {
            foreach (Trainer a in trainers)
            {
                if (a == null)
                {
                    return false;
                }
                else if (a.FirstName == this.FirstName && a.LastName == this.LastName)
                {
                    Console.WriteLine($"There is already a trainer with this name({FullName})!\nGive names again:\nIf you want to quit type'exit'.");
                    Console.Write("Press any button to continue...");
                    Console.ReadKey();
                    return true;
                }
            }
            return false;
        }
        public bool CheckCourse(List<Course> courses, int n)
        {
            if (this.Subject != courses[n - 1].Stream)
            {
                Console.WriteLine($"The trainer is not familiar with this subject.Choose a course in {this.Subject}:");
                return false;
            }
            for (int i = 0; i < Courses.Count; i++) // ελεγχος για τον αν ειναι ηδη εγγεγραμμένος ο trainer
            {
                if (this.Courses[i].Title == courses[n - 1].Title)
                {
                    Console.WriteLine("The Trainer is already registered in this course.Please choose other option:");
                    return false;
                }
            }
            return true;
        }

        //Displays
        public override string ToString()
        {
            return ($"{this.Id}. {this.FullName}\t {this.Subject}\n"); ;
        }
        public void InfoDisplay()
        {
            foreach (Course a in Courses)
            {
                Console.WriteLine($"ID. Course Title\t Starting    \t Ending Date:\n{a}");
                a.StudentsDisplay();
                a.AssignmentsDisplay();
                Console.WriteLine();
            }
        }
    }
}
