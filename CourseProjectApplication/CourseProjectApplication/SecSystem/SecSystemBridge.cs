using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;

namespace CourseProjectApplication.SecSystem
{
    class SecSystemBridge : ISecSystem
    {
        //public const string ConnectionString = "Data Source=DESKTOP-7C0V9B9;Initial Catalog=EngineChemicals;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection _sqlConnection;

        public User GetUserById(int userId)
        {
            SqlDataAdapter da2 = new SqlDataAdapter();
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand getUser = new SqlCommand("SELECT dbo.GetUserById(@userId)", _sqlConnection);
            SqlParameter userIdParam = new SqlParameter("@userId", SqlDbType.Int);
            userIdParam.Value = userId;
            getUser.Parameters.Add(userIdParam);

            var reader = getUser.ExecuteReader();
            reader.Read();

            string firstName, middleName, lastName;
            int id, identDataId, secLevelId, dbAccessId;
            id = (int) reader["Id"];
            identDataId = (int) reader["IdentDataId"];
            secLevelId = (int) reader["SecLevelId"];
            dbAccessId = (int) reader["DbAccessLevelId"];
            firstName = (string) reader["UserFirstName"];
            middleName = (string) reader["UserMiddleName"];
            lastName = (string) reader["UserLastName"];


            return new User(id, firstName, middleName, lastName, identDataId, secLevelId, dbAccessId);
        }

        public User RegisterUser(UserName name, string password)
        {
            SqlCommand cmd = new SqlCommand("RegisterUser", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter firstNameParam = new SqlParameter("@firstName", SqlDbType.VarChar);
            firstNameParam.Value = name.FirstName;
            cmd.Parameters.Add(firstNameParam);

            SqlParameter middleNameParam = new SqlParameter("@middleName", SqlDbType.VarChar);
            middleNameParam.Value = name.FirstName;
            cmd.Parameters.Add(middleNameParam);

            SqlParameter lastNameParam = new SqlParameter("@lastName", SqlDbType.VarChar);
            lastNameParam.Value = name.FirstName;
            cmd.Parameters.Add(lastNameParam);

            SqlParameter passwordHashParam = new SqlParameter("@passwordHash", SqlDbType.VarChar);
            passwordHashParam.Value = name.FirstName;
            cmd.Parameters.Add(passwordHashParam);

            int id = (int)cmd.ExecuteScalar();

            return GetUserById(id);
        }

        public IList<Location> GetAccessibleLocations(User user)
        {
            throw new NotImplementedException();
        }

        public void LoginAs(string userId, string password)
        {
            SecureString secString = new SecureString();

            for (int i = 0; i < password.Length; i++)
            {
                secString.AppendChar(password[i]);
            }

            _sqlConnection = new SqlConnection();
            SqlCredential credential = new SqlCredential(userId, secString);
            _sqlConnection.Credential = credential;
            _sqlConnection.Open();
        }
    }
}
