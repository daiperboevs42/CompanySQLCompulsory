using System;
using System.Collections.Generic;

namespace CompanySQLCompulsory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> options = new List<string>();
                options.Add("1: Create Department");
                options.Add("2: Update Department Name");

            Console.WriteLine("What would you like to do today?");

            foreach(string element in options)
            {
                Console.WriteLine(element);
            };
            Console.ReadLine();
        }
    }
}
