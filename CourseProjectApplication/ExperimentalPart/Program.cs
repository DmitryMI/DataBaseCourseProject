using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalPart
{
    class Program
    {
        private static SqlConnection _sqlConnection;

        public const string ConnectionString =
            "Data Source=DMITRYBIGPC;Initial Catalog=SecSystem;Integrated Security=False;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void OpenConnection()
        {
            string password = "123";
            string login = "Sergay";
            try
            {
                SecureString secString = new SecureString();

                for (int i = 0; i < password.Length; i++)
                {
                    secString.AppendChar(password[i]);
                }

                secString.MakeReadOnly();

                _sqlConnection = new SqlConnection();
                //_sqlConnection.ConnectionString = GetConnectionString("", userId, password);
                _sqlConnection.ConnectionString = ConnectionString;
                SqlCredential credential = new SqlCredential(login, secString);

                _sqlConnection.Credential = credential;
                _sqlConnection.Open();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine("InvalidOperationException: " + ex.Message);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("SqlException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
        }


        static void Main(string[] args)
        {
            OpenConnection();
            Console.WriteLine("Connection established...");

            double proc = DoStopwatch(DoStoredProcedure, 1000);
            double query = DoStopwatch(DoQuery, 1000);

            Console.WriteLine("Stored procedure: " + proc);
            Console.WriteLine("Query: " + query);

            Console.ReadKey();
        }

        static double DoStopwatch(Func<int> action, int count)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
                action();
            sw.Stop();
            return (double)sw.ElapsedTicks / count;
        }

        static int DoStoredProcedure()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from dbo.GetAccessibleLocations(@id)", _sqlConnection);
            SqlParameter userIdParam = new SqlParameter("@id", SqlDbType.Int);
            userIdParam.Value = 10;
            cmd.Parameters.Add(userIdParam);

            var reader = cmd.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count++;
            }

            reader.Close();

            return count;
        }

        static int DoQuery()
        {
            string query =
                "declare @userId int = 10\n" +
                "select Locations.Id, Locations.LocName from \n" +
                "(Locations join AccessRules on Locations.Id = AccessRules.LocId)\n" +
                "join SecLevel on SecLevel.Id = AccessRules.SecLevelId\n" +
                "join Users on SecLevel.Id = Users.SecLevelId\n" +
                "where Users.Id = @userId";
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
           
            var reader = cmd.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count++;
            }

            reader.Close();

            return count;
        }
    }
}
