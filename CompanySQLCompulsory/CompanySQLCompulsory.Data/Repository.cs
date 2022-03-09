using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CompanySQLCompulsory.CompanySQLCompulsory.Data
{
    public class Repository
    {
        //get actual connection string here
        private string connectionString = "Server=DESKTOP-ITEBOS2;Database=Company;Trusted_Connection=True;";

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

        public void ReadSomething()
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
    }
}
