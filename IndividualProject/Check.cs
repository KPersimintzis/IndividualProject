using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    static class Check
    {
        public static bool YesOrNo()
        {
            Console.Write(">");
            string temp = Console.ReadLine();
            if (temp.ToUpper().Equals("Y"))
            {
                Console.WriteLine("");
                return true;
            }
            else if (temp.ToUpper().Equals("N"))
            {
                Console.WriteLine("");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid!Type <Y> or <N>:");
                return YesOrNo();
            }

        }
        public static bool StringEquals(string a, string b)
        {
            if (a.ToUpper().Equals(b.ToUpper()))
            {
                return true;
            }
            return false;
        }
        public static bool ListEmpty<T>(List<T> list)
        {
            if (list.Any() == false)
            {
                return true;                //true ειναι αδεια
            }
            else
                return false;
        }
        public static bool Exit(string a)
        {
            string b = a.ToLower();
            if (b.Contains("exit"))
            {
                return true;
            }
            return false;
        }
    }
}
