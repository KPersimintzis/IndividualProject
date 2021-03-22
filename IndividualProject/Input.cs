using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IndividualProject
{
    static class Input
    {
        public static int Integer(int min, int max)
        {
            int tempint;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out tempint) || (tempint < min) || (tempint > max))
            {
                Console.WriteLine("Invalid Number");
                Console.Write($"Please type a number between {min} and {max}: ");
                input = Console.ReadLine();
            }
            return tempint;
        }
        public static double Double(int min, int max)
        {

            double tempint;
            string input = Console.ReadLine();
            while (!double.TryParse(input, out tempint) || (tempint < min) || (tempint > max))
            {
                Console.WriteLine("Invalid Number");
                Console.Write($"Please type a number between {min} and {max}:\n> ");
                input = Console.ReadLine();
            }
            return tempint;

        }
        public static string String()
        {

            Console.WriteLine("First letter must be capital and use only letters\n>");
            string temp = Console.ReadLine();
            if (temp == "exit") { return temp; }
            bool check = Regex.Match(temp, @"^[A-Z][a-z]+?$").Success;
            while (check == false)
            {
                Console.Write("First letter must be capital and use only letters\n(for example:Mark)\n>");
                temp = Console.ReadLine();
                check = Regex.Match(temp, @"^[A-Z][a-z]+?$").Success;
            }
            return temp;
        }
        public static DateTime Dates(DateTime min, DateTime max)
        {
            byte i = 0; // ο χρηστης μετα απο πεντε αποτυχημενες επιλογες να μπορει να αποχωρει
            DateTime date = new DateTime();
            while (date < min || date > max)
            {
                string temp = Console.ReadLine();
                while (!DateTime.TryParseExact(temp, "d", null, 0, out date))
                {
                    i++;
                    Console.WriteLine("Wrong Format");
                    if (i > 5)
                    {
                        Console.Write("Do you want to exit? <Y> or <N>?:\n>");
                        if (Check.YesOrNo()) { return DateTime.Now; }
                    }
                    Console.Write("The Format is (dd/MM/yyyy)\n>");
                    temp = Console.ReadLine();
                }
                i++;
                if (date < min || date > max)
                { Console.Write($"The Date must be inside {min:d} and {max:d}!\nTry Again\n>"); }
                if (i > 5)
                {
                    Console.Write("Do you want to exit? <Y> or <N>?:\n>");
                    if (Check.YesOrNo()) { return DateTime.Now; }
                }
            }
            return date;
        }
    }


}
