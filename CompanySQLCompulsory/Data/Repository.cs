using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CompanySQLCompulsory.CompanySQLCompulsory.Data
{
    public class Repository
    {
        //Change here to local DB
        //TODO: Change this so it works better/uses an actual DB
        private string connectionString = "Server=DESKTOP-ITEBOS2;Database=Company;Trusted_Connection=True;";

        public void CreateDepartment(string DName, string MgrSSN)
        {
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"CreateCommand {DName}, {MgrSSN}", cnn))
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine("Department created with Department Number:");
                            Console.WriteLine(reader.GetValue(i));
                        }
                    }
                }
            }
        }

        public void UpdateDepartmentName(string DNumber, string DName)
        {
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"UpdateDeptCommand {DNumber}, {DName}", cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Department name updated");
            }
        }

        public void UpdateDepartmentManager(string DNumber, string MgrSSN)
        {
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"UpdateDeptManCommand {DNumber}, {MgrSSN}", cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Department manager updated");
            }
        }

        public void DeleteDepartment(string DNumber)
        {
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"DeleteCommand {DNumber}", cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Department deleted");
            }
        }

        public void GetDepartment(string DNumber)
        {
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"GetDepartment {DNumber}", cnn))
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader.GetValue(i));
                        }
                    }
                }
            }
        }

        public void GetAllDepartments()
        {
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"GetAllDepartments", cnn))
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader.GetValue(i));
                        }
                    }
                }
            }
        }

        /*public void ReadSomething()
        {
            using (var cnn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("whatevertheydecideitscalled", cnn){ CommandType = CommandType.StoredProcedure }) 
            {
                cnn.Open(); //does this go here?

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                }
            };
        }
        
         public void Testies()
        {
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM Department", cnn))
            {
                cnn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
         
         */
    }
}
