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
            int conv = 0;
            try { conv = Int32.Parse(MgrSSN); }
            catch { Console.WriteLine("Your SSN is not a number"); }

            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"CreateCommand", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add($"DName", SqlDbType.VarChar).Value = DName;
                command.Parameters.Add($"MgrSSN", SqlDbType.Int).Value = conv;
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
            int conv = 0;
            try { conv = Int32.Parse(DNumber); }
            catch { Console.WriteLine("Your Department Number is not a number"); }
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"UpdateDeptCommand", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add($"DName", SqlDbType.VarChar).Value = DName;
                command.Parameters.Add($"MgrSSN", SqlDbType.Int).Value = conv;
                cnn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Department name updated");
            }
        }

        public void UpdateDepartmentManager(string DNumber, string MgrSSN)
        {
            int convDNumber = 0;
            try { convDNumber = Int32.Parse(DNumber); }
            catch { Console.WriteLine("Your Department Number is not a number"); }
            int convSSN = 0;
            try { convSSN = Int32.Parse(MgrSSN); }
            catch { Console.WriteLine("Your SSN is not a number"); }
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"UpdateDeptManCommand", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add($"DName", SqlDbType.Int).Value = convDNumber;
                command.Parameters.Add($"MgrSSN", SqlDbType.Int).Value = convSSN;
                cnn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Department manager updated");
            }
        }

        public void DeleteDepartment(string DNumber)
        {
            int convDNumber = 0;
            try { convDNumber = Int32.Parse(DNumber); }
            catch { Console.WriteLine("Your Department Number is not a number"); }
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"DeleteCommand", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add($"DName", SqlDbType.Int).Value = convDNumber;
                cnn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Department deleted");
            }
        }

        public void GetDepartment(string DNumber)
        {
            int convDNumber = 0;
            try { convDNumber = Int32.Parse(DNumber); }
            catch { Console.WriteLine("Your Department Number is not a number"); }
            using (var cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"GetDepartment", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add($"DName", SqlDbType.Int).Value = convDNumber;
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
                command.CommandType = CommandType.StoredProcedure;
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
