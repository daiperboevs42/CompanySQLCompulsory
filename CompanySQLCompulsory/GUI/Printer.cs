using CompanySQLCompulsory.CompanySQLCompulsory.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySQLCompulsory.GUI
{
    public class Printer
    {
        Repository repository = new Repository();
        public void Options()
        {
            List<string> options = new List<string>();
            options.Add("1: Create Department");
            options.Add("2: Update Department Name");
            options.Add("3: Update Department Manager");
            options.Add("4: Delete Department");
            options.Add("5: Get Department");
            options.Add("6: Get All Departments");

            Console.WriteLine("What would you like to do today?");

            foreach (string element in options)
            {
                Console.WriteLine(element);
            };

            var input = Console.ReadLine();
            try
            {
                int result = Int32.Parse(input);
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Please input Name");
                        var DName = Console.ReadLine();
                        Console.WriteLine("Please input Manager SSN");
                        var MgrSSN = Console.ReadLine();
                        try
                        {
                            repository.CreateDepartment(DName, MgrSSN);
                        }
                        catch
                        {
                            Console.WriteLine("Error processing database request");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please input Department Number");
                        var DNum = Console.ReadLine();
                        Console.WriteLine("Please input new Department Name");
                        var NewDName = Console.ReadLine();
                        try
                        {
                            repository.UpdateDepartmentName(DNum, NewDName);
                        }
                        catch
                        {
                            Console.WriteLine("Error processing database request");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please input Department Number");
                        var DNum1 = Console.ReadLine();
                        Console.WriteLine("Please input new Department Manager SSN");
                        var NewDMan = Console.ReadLine();
                        try
                        {
                            repository.UpdateDepartmentManager(DNum1, NewDMan);
                        }
                        catch
                        {
                            Console.WriteLine("Error processing database request");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Please input Department Number");
                        var DNum2Delete = Console.ReadLine();
                        try
                        {
                            repository.DeleteDepartment(DNum2Delete);
                        }
                        catch
                        {
                            Console.WriteLine("Error processing database request");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Please input Department Number");
                        var DNum2Get = Console.ReadLine();
                        try
                        {
                            repository.GetDepartment(DNum2Get);
                        }
                        catch
                        {
                            Console.WriteLine("Error processing database request");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        try
                        {
                            repository.GetAllDepartments();
                        }
                        catch
                        {
                            Console.WriteLine("Error processing database request");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please try again");
                        break;
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                Options();
            }
            catch
            {
                Console.WriteLine("Invalid Input, please try again");
            }
        }
    }
}
