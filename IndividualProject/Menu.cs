using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{

    static class Menu
    {
        static List<Course> courses = new List<Course>();
        static List<Trainer> trainers = new List<Trainer>();
        static List<Student> students = new List<Student>();
        static List<Assignment> assignments = new List<Assignment>();

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\tPrivate School");
            Console.WriteLine("Select an option from menu: ");
            Console.Write("0.Exit\n1.Courses\n2.Trainers\n3.Students\n4.Assignments\n5.SytheticData\n\n------\n>");
            int temp = Input.Integer(0, 5);
            switch (temp)
            {
                case 0:
                    {
                        Console.WriteLine("\nExiting...\n");
                        Console.WriteLine("Are you sure?<Y> or <N>");
                        return;
                    }
                case 1:
                    {
                        Console.Clear();
                        CoursesMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        TrainersMenu();
                        return;
                    }
                case 3:
                    {
                        Console.Clear();
                        StudentsMenu();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        AssignmentsMenu();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        SyntheticDataMenu();
                        break;
                    }
            }
        }
        static public void CoursesMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an option from Courses menu: ");
            Console.Write("0.Back to Main Menu\n1.Insert\n2.Display\n3.Exit\n\n------\n>");
            int temp = Input.Integer(0, 3);
            switch (temp)
            {
                case 0:
                    {
                        MainMenu();
                        break;
                    }
                case 1:
                    {
                        do
                        {
                            Console.Clear();
                            Console.Write("How many courses you want to add?\nMaximum number:5\n\n------\n>");
                            temp = Input.Integer(1, 5);
                            for (int i = 1; i <= temp; i++)
                            {
                                Course course = new Course();
                                do
                                {
                                    course.TitleInsert();
                                    if (course.Title.Contains("exit")) { break; }
                                } while (course.CheckNames(courses));
                                if (course.Title.Contains("exit"))
                                {
                                    Console.WriteLine("You exit from register process...");
                                    break;
                                }
                                course.StreamInsert();
                                course.TypeInsert();
                                course.DatesInsert();
                                course.IdInsert();
                                courses.Add(course);
                            }
                            Console.WriteLine("Do you want to add more courses? <Y> or <N>?");
                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        CoursesMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        if (Check.ListEmpty(courses))
                        {
                            SyntheticData.Courses(courses);
                        }
                        Display.Courses(courses);
                        Console.Write("If you want more info about each course please type its id:\nPress 0 to go back\n\n------\n>");
                        temp = Input.Integer(0, courses.Count);
                        while (temp != 0)
                        {
                            courses[temp - 1].InfoDisplay();
                            Console.Write("\nIf you want more info about other course please type its id:\nPress 0 to go back\n\n------\n>");
                            temp = Input.Integer(0, courses.Count);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        CoursesMenu();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Are you sure want to close the program? <Y> or <N>?");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            Console.WriteLine("\nExiting...\n");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            CoursesMenu();
                            break;
                        }
                    }
            }
        }
        static public void TrainersMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an option from Trainers menu: ");
            Console.Write("0.Back to Main Menu\n1.Insert\n2.Display\n3.Exit\n\n------\n>");
            int temp = Input.Integer(0, 3);
            switch (temp)
            {
                case 0:
                    {
                        MainMenu();
                        break;
                    }
                case 1:
                    {
                        do
                        {
                            Console.Clear();
                            Console.Write("How many trainers you want to add?\nMaximum number:5\n\n------\n>");
                            temp = Input.Integer(1, 5);
                            for (int i = 1; i <= temp; i++)
                            {
                                Trainer trainer = new Trainer();
                                trainer.NameInsert(trainers); //μεσα εκει γινεται ελεγχος και για το αν υπαρχει ο trainer ηδη εγγεγραμμενος
                                if (trainer.FullName.Contains("exit"))
                                {
                                    Console.WriteLine("You exit from register process...");
                                    break;
                                }
                                Console.Clear();
                                trainer.SubjectInsert();
                                Console.Clear();
                                trainer.CourseInsert(courses);
                                trainer.IdInsert();
                                trainers.Add(trainer);
                            }
                            Console.WriteLine("Do you want to add more trainers? <Y> or <N>?");
                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        TrainersMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        if (Check.ListEmpty(trainers))
                        {
                            if (Check.ListEmpty(courses))
                            { SyntheticData.Courses(courses); }
                            SyntheticData.Trainers(trainers, courses);
                        }
                        Display.Trainers(trainers);
                        Console.Write("If you want more info about each trainer please type its id:\nPress 0 to go back\n\n------\n>");
                        temp = Input.Integer(0, trainers.Count);
                        while (temp != 0)
                        {
                            Console.WriteLine("Id FullName\tSubject");
                            Console.WriteLine(trainers[temp - 1]);
                            trainers[temp - 1].InfoDisplay();
                            Console.Write("\nIf you want more info about other trainer please type its id:\nPress 0 to go back\n\n------\n>");
                            temp = Input.Integer(0, trainers.Count);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        TrainersMenu();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Are you sure want to close the program? <Y> or <N>?");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            Console.WriteLine("\nExiting...\n");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            TrainersMenu();
                            break;
                        }
                    }
            }
        }
        static public void StudentsMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an option from Students menu: ");
            Console.Write("0.Back to Main Menu\n1.Insert\n2.Display\n3.Exit\n\n------\n>");
            int temp = Input.Integer(0, 3);
            switch (temp)
            {
                case 0:
                    {
                        MainMenu();
                        break;
                    }
                case 1:
                    {
                        do
                        {
                            Console.Clear();
                            Console.Write("How many students you want to add?\nMaximum number:5\n\n------\n>");
                            temp = Input.Integer(1, 5);
                            for (int i = 1; i <= temp; i++)
                            {
                                Student student = new Student();
                                student.NameInsert(students); //μεσα εκει γινεται ελεγχος και για το αν υπαρχει ο student ηδη εγγεγραμμενος
                                if (student.FullName.Contains("exit"))
                                {
                                    Console.WriteLine("You exit from register process...");
                                    break;
                                }
                                student.CourseInsert(courses);
                                student.DatesInsert();
                                student.IdInsert();
                                students.Add(student);
                            }
                            Console.WriteLine("Do you want to add more students? <Y> or <N>?");
                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        StudentsMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        if (Check.ListEmpty(students))
                        {
                            if (Check.ListEmpty(courses))
                            { SyntheticData.Courses(courses); }
                            SyntheticData.Students(students, courses);
                        }
                        Console.WriteLine("Select an option from Display menu: ");
                        Console.Write("0.Back to Main Menu\n1.Display all the Students" +
                            "\n2.Display the Student who belong to more than a course" +
                            "\n3.Display the Student who have to submit assignment(s) in certain date" +
                            "\n4.Exit\n\n------\n>");
                        int temp2 = Input.Integer(0, 4);
                        switch (temp2)
                        {
                            case 0: { MainMenu(); break; }
                            case 1:
                                {
                                    Display.Students(students);
                                    Console.WriteLine();
                                    Console.Write("If you want more info about each student please type its id:\nPress 0 to go back\n\n------\n>");
                                    temp = Input.Integer(0, students.Count);
                                    while (temp != 0)
                                    {
                                        Console.WriteLine("Id FullName\tTuition Fee");
                                        Console.WriteLine(students[temp - 1]);
                                        students[temp - 1].InfoDisplay();
                                        Console.Write("\nIf you want more info about other student please type its id:\nPress 0 to go back\n\n------\n>");
                                        temp = Input.Integer(0, students.Count);
                                    }
                                    Console.Write("Press any button to continue...");
                                    Console.ReadKey();
                                    StudentsMenu();
                                    break;
                                }
                            case 2:
                                {
                                    Display.StudentMoreThanOneCourse(students);
                                    Console.Write("Press any button to continue...");
                                    Console.ReadKey();
                                    StudentsMenu();
                                    break;
                                }
                            case 3:
                                {
                                    Display.Submission(assignments);
                                    Console.Write("Press any button to continue...");
                                    Console.ReadKey();
                                    StudentsMenu();
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Are you sure want to close the program? <Y> or <N>?");
                                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                                    {
                                        Console.WriteLine("\nExiting...\n");
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        StudentsMenu();
                                        break;
                                    }
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Are you sure want to close the program? <Y> or <N>?");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            Console.WriteLine("\nExiting...\n");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            StudentsMenu();
                            break;
                        }
                    }
            }
        }
        static public void AssignmentsMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an option from Assignments menu: ");
            Console.Write("0.Back to Main Menu\n1.Insert\n2.Display\n3.Exit\n\n------\n>");
            int temp = Input.Integer(0, 3);
            switch (temp)
            {
                case 0:
                    {
                        MainMenu();
                        break;
                    }
                case 1:
                    {
                        do
                        {
                            Console.Clear();
                            Console.Write("How many assignments you want to add?\nMaximum number:5\n\n------\n>");
                            temp = Input.Integer(1, 5);
                            for (int i = 1; i <= temp; i++)
                            {
                                Assignment assignment = new Assignment();
                                assignment.TitleInsert(assignments);
                                if (assignment.Title.Contains("exit"))
                                {
                                    Console.WriteLine("You exit from register process...");
                                    break;
                                }
                                assignment.DescriptionInsert();
                                assignment.SubmissionInsert();
                                assignment.CourseInsert(courses);
                                assignment.MarksInsert();
                                assignment.IdInsert();
                                assignments.Add(assignment);
                            }
                            Console.WriteLine("Do you want to add more assignments? <Y> or <N>?");
                        } while (Console.ReadKey(true).Key == ConsoleKey.Y);
                        AssignmentsMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        if (Check.ListEmpty(assignments))
                        {
                            if (Check.ListEmpty(courses))
                            { SyntheticData.Courses(courses); }
                            SyntheticData.Assignments(assignments, courses);
                        }
                        Display.Assignments(assignments);
                        Console.WriteLine();
                        Console.Write("If you want more info about each assignment please type its id:\nPress 0 to go back\n\n------\n>");
                        temp = Input.Integer(0, assignments.Count);
                        while (temp != 0)
                        {
                            Console.WriteLine("Id Title \t\tDescription\t Submission Date");
                            Console.WriteLine(assignments[temp - 1]);
                            assignments[temp - 1].InfoDisplay();
                            Console.Write("\nIf you want more info about other assignment please type its id:\nPress 0 to go back\n\n------\n>");
                            temp = Input.Integer(0, assignments.Count);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        AssignmentsMenu();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Are you sure want to close the program? <Y> or <N>?");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            Console.WriteLine("\nExiting...\n");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            AssignmentsMenu();
                            break;
                        }
                    }
            }
        }
        static public void SyntheticDataMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an option from SyntheticData menu: ");
            Console.Write("0.Back to Main Menu\n1.Insert Courses\n2.Insert Trainers" +
                "\n3.Insert Students\n4.Insert Assignments\n5.Insert All\n\n------\n>");
            int temp = Input.Integer(0, 5);
            switch (temp)
            {
                case 0:
                    {
                        Console.Clear();
                        MainMenu();
                        break;
                    }
                case 1:
                    {
                        if (courses.Any())
                        { Console.WriteLine("Already inserted SyntheticData for courses"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for courses");
                            SyntheticData.Courses(courses);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        SyntheticDataMenu();
                        break;
                    }

                case 2:
                    {
                        if (trainers.Any())
                        { Console.WriteLine("Already inserted SyntheticData for trainers"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for trainers");
                            SyntheticData.Trainers(trainers, courses);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        SyntheticDataMenu();
                        break;
                    }
                case 3:
                    {
                        if (students.Any())
                        { Console.WriteLine("Already inserted SyntheticData for students"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for students");
                            SyntheticData.Students(students, courses);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        SyntheticDataMenu();
                        break;
                    }
                case 4:
                    {
                        if (assignments.Any())
                        { Console.WriteLine("Already inserted SyntheticData for assignments"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for assignments");
                            SyntheticData.Assignments(assignments, courses);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        SyntheticDataMenu();
                        break;
                    }
                case 5:
                    {
                        if (courses.Any())
                        { Console.WriteLine("Already inserted SyntheticData for courses"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for courses");
                            SyntheticData.Courses(courses);
                        }
                        if (trainers.Any())
                        { Console.WriteLine("Already inserted SyntheticData for trainers"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for trainers");
                            SyntheticData.Trainers(trainers, courses);
                        }
                        if (students.Any())
                        { Console.WriteLine("Already inserted SyntheticData for students"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for students");
                            SyntheticData.Students(students, courses);
                        }
                        if (assignments.Any())
                        { Console.WriteLine("Already inserted SyntheticData for assignments"); }
                        else
                        {
                            Console.WriteLine("Succesfully inserted SyntheticData for assignments");
                            SyntheticData.Assignments(assignments, courses);
                        }
                        Console.Write("Press any button to continue...");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    }

            }
        }
    }

}

