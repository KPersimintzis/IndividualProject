using System;
using System.Collections.Generic;
using System.Dynamic;

namespace IndividualProject
{
    class Course
    {
        private static int idc = 1;
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Stream { get; private set; }
        public string Type { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<Assignment> Assignments { get; private set; } = new List<Assignment>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();


        public Course(string title, string stream, string type, DateTime startdate, DateTime enddate)
        {
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startdate;
            EndDate = enddate;
            IdInsert();
        }
        public Course()
        {
        }

        //Inserts
        public void IdInsert()
        {
            Id = idc;
            idc++;
        }
        public void TitleInsert()
        {
            Console.Clear();
            Console.WriteLine("You can quit if you type 'exit'");
            do
            {
                Console.Write("Give a title to your course:\n> ");
                Title = Console.ReadLine().Trim();
                if (Check.Exit(Title)) { return; }
                Console.Write($"You gave this title {this.Title}\nDo you want to proceed ? <Y> or <N>?:\n");
            } while (!Check.YesOrNo());
        }
        public void StreamInsert()
        {
            Console.Clear();
            Console.WriteLine($"Choose Stream for you Course({this.Title})");
            Console.Write("1.C#\n2.Java\n3.Python\n4.Javascript\n\n------\n>");
            int temp = Input.Integer(1, 4);
            switch (temp)
            {
                case 1:
                    {
                        this.Stream = "C#";
                        break;
                    }
                case 2:
                    {
                        this.Stream = "Java";
                        break;
                    }
                case 3:
                    {
                        this.Stream = "Python#";
                        break;
                    }
                case 4:
                    {
                        this.Stream = "Javascript";
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please choose again!");
                        StreamInsert();
                        break;
                    }
            }

        }
        public void TypeInsert()
        {
            Console.Clear();
            Console.WriteLine($"Choose Type for you Course ({this.Title})");
            Console.Write("1.Part-Time\n2.Full-Time\n\n------\n>");
            int temp = Input.Integer(1, 2);
            switch (temp)
            {
                case 1:
                    {
                        this.Type = "Part-Time";
                        break;
                    }
                case 2:
                    {
                        this.Type = "Full-Time";
                        break;
                    }
                default:
                    {
                        TypeInsert();
                        break;
                    }
            }
        }
        public void DatesInsert()
        {
            Console.Clear();
            Console.WriteLine($"Choose Starting Date for your Course ({this.Title})");

            Console.Write($"From: {DateTime.Now:d} To: {DateTime.Now.AddMonths(12):d} \n\n (dd/MM/yyyy)\n>");
            StartDate = Input.Dates(DateTime.Now, DateTime.Now.AddMonths(12));

            Console.Clear();
            Console.WriteLine($"Choose Ending Date for your Course ({this.Title})");

            Console.Write($"From: {this.StartDate:d} To: {this.StartDate.AddMonths(12):d} \n\n (dd/MM/yyyy)\n>");
            EndDate = Input.Dates(this.StartDate, this.StartDate.AddMonths(12));
        }

        //Checking
        public bool CheckNames(List<Course> courses)
        {
            foreach (Course c in courses)
                if (c == null)
                {
                    return false;
                }
                else if (c.Title == this.Title)
                {
                    Console.WriteLine($"There is already a course with this title({Title})!\nGive names again:\nIf you want to quit type'exit'.");
                    Console.Write("Press any button to continue...");
                    Console.ReadKey();
                    return true;
                }
            return false;
        }



        //Displays 
        public override string ToString()
        {
            return ($"{this.Id}. {this.Title}\t \t{this.Stream}\t{this.StartDate:dd/MM/yyyy}\t {this.EndDate:dd/MM/yyyy}"); ;
        }
        public void StudentsDisplay()
        {
            Console.WriteLine($"Students:");
            foreach (Student a in this.Students)
            {
                Console.Write($"\t {a.FullName}\n");
            }
        }
        public void TrainersDisplay()
        {
            Console.WriteLine("Trainers:");
            foreach (Trainer a in this.Trainers)
            {
                Console.Write($"\t {a.FullName}\n");
            }
        }
        public void AssignmentsDisplay()
        {
            Console.WriteLine("Assignments:");
            foreach (Assignment a in this.Assignments)
            {
                Console.Write($"\t    {a.Title}\t{a.Description}\n");
            }

        }

        public void InfoDisplay()
        {
            StudentsDisplay();
            TrainersDisplay();
            AssignmentsDisplay();
        }
    }
}

