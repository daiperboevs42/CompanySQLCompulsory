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
            int conv = ConvertStringToInt(MgrSSN);
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand($"usp_CreateDepartment", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add($"DName", SqlDbType.VarChar).Value = DName;
                    command.Parameters.Add($"MgrSSN", SqlDbType.Int).Value = conv;

                    command.Parameters.Add("DNumber", SqlDbType.Int);
                    command.Parameters["DNumber"].Direction = ParameterDirection.Output;
                    //var message = (string)command.Parameters["DNumber"].Value;
                    //command.Parameters.Add($"DNumber", SqlDbType.Int).Value = 0;
                    //command.Parameters["DNumber"].Direction = ParameterDirection.Output;
                    cnn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine("Department created with Department Number:");
                                Console.WriteLine(reader.GetValue(i));
                               //Console.WriteLine(message);
                            }
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
        }

        public void UpdateDepartmentName(string DNumber, string DName)
        {
            try
            {
                int conv = ConvertStringToInt(DNumber);
                using (var cnn = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand($"usp_UpdateCreateDepartment", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add($"DName", SqlDbType.VarChar).Value = DName;
                    command.Parameters.Add($"DNumber", SqlDbType.Int).Value = conv;
                    
                    cnn.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Department name updated");
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
        }

        public void UpdateDepartmentManager(string DNumber, string MgrSSN)
        {
            try
            {
                int convDNumber = ConvertStringToInt(DNumber);
                int convSSN = ConvertStringToInt(MgrSSN);
                using (var cnn = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand($"usp_UpdateDepartmentManager", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add($"DNumber", SqlDbType.Int).Value = convDNumber;
                    command.Parameters.Add($"MgrSSN", SqlDbType.Int).Value = convSSN;
                    cnn.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Department manager updated");
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
        }

        public void DeleteDepartment(string DNumber)
        {
            try
            {
                int convDNumber = ConvertStringToInt(DNumber);
                using (var cnn = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand($"usp_DeleteDepartment", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add($"DNumber", SqlDbType.Int).Value = convDNumber;
                    cnn.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Department deleted");
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
        }

        public void GetDepartment(string DNumber)
        {
            try
            {
                int convDNumber = ConvertStringToInt(DNumber);
                using (var cnn = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand($"usp_GetDepartment", cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add($"DNumber", SqlDbType.Int).Value = convDNumber;
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
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
        }

        public void GetAllDepartments()
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand($"usp_GetAllDepartment", cnn))
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
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
        }

        private int ConvertStringToInt(string toConvert)
        {
            int conv = 0;
            try { conv = Int32.Parse(toConvert); }
            catch { Console.WriteLine("Your input is not a number"); }
            return conv;
        }
    }
}
