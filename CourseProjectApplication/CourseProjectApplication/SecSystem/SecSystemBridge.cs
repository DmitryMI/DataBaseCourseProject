using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;

namespace CourseProjectApplication.SecSystem
{
    class SecSystemBridge : ISecSystem
    {
        //public const string ConnectionString = "Data Source=DESKTOP-7C0V9B9;Initial Catalog=EngineChemicals;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //public const string ConnectionString = "Data Source=DMITRYBIGPC;Initial Catalog=SecSystem;Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public const string ConnectionString = "Data Source=DMITRYBIGPC;Initial Catalog=SecSystem;Integrated Security=False;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string SqlConnectionString =
            "Data Source=DMITRYBIGPC;Initial Catalog=SecSystem;Integrated Security=SSPI;User ID={0};Password={1};";

        private SqlConnection _sqlConnection;

        private string GetConnectionString(string domain, string login, string password)
        {
            string userId;
            if (String.IsNullOrWhiteSpace(domain))
            {
                userId = login;
            }
            else
            {
                userId = $"{domain}\\login";
            }

            return String.Format(SqlConnectionString, userId, password);
        }

        public User GetUserById(int userId)
        {
            //SqlDataAdapter da2 = new SqlDataAdapter();
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand getUser = new SqlCommand("SELECT GetUserById(@id)", _sqlConnection);
            SqlParameter userIdParam = new SqlParameter("@id", SqlDbType.Int) {Value = userId};
            getUser.Parameters.Add(userIdParam);

            var reader = getUser.ExecuteReader();
            if (reader.Read())
            {
                var id = (int) reader["Id"];
                var identDataId = (int) reader["IdentDataId"];
                var secLevelId = (int) reader["SecLevelId"];
                var dbAccessId = (int) reader["DbAccessLevelId"];
                var firstName = (string) reader["UserFirstName"];
                var middleName = (string) reader["UserMiddleName"];
                var lastName = (string) reader["UserLastName"];

                reader.Close();
                return new User(id, firstName, middleName, lastName, identDataId, secLevelId, dbAccessId);
            }

            reader.Close();

            return null;
        }

        public IList<User> GetUsers()
        {
            //SqlCommand cmd = new SqlCommand("GetUsers", _sqlConnection);
            SqlCommand getUsers = new SqlCommand("SELECT * from GetUsers()", _sqlConnection);

            var reader = getUsers.ExecuteReader();

            List<User> result = new List<User>();

            while (reader.Read())
            {
                string firstName, middleName, lastName;
                int id, identDataId, secLevelId, dbAccessId;
                id = (int)reader["Id"];
                identDataId = (int)reader["IdentDataId"];
                secLevelId = (int)reader["SecLevelId"];
                dbAccessId = (int)reader["DbAccessLevelId"];
                firstName = (string)reader["UserFirstName"];
                middleName = (string)reader["UserMiddleName"];
                lastName = (string)reader["UserLastName"];

                var user = new User(id, firstName, middleName, lastName, identDataId, secLevelId, dbAccessId);
                result.Add(user);
            }

            reader.Close();

            return result;
        }

        public Location GetLocationById(int locationId)
        {
            //SqlDataAdapter da2 = new SqlDataAdapter();
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand getUser = new SqlCommand("SELECT * from dbo.GetLocationById(@id)", _sqlConnection);
            SqlParameter locationIdParam = new SqlParameter("@id", SqlDbType.Int);
            locationIdParam.Value = locationId;
            getUser.Parameters.Add(locationIdParam);

            var reader = getUser.ExecuteReader();
            if (reader.Read())
            {
                string name;
                int id;
                id = (int) reader["Id"];
                name = (string) reader["LocName"];

                reader.Close();
                return new Location(id, name);
            }

            reader.Close();
            return null;
        }

        public IList<Location> GetLocations()
        {
            SqlCommand getUsers = new SqlCommand("SELECT * from GetLocations()", _sqlConnection);

            var reader = getUsers.ExecuteReader();

            List<Location> result = new List<Location>();

            while (reader.Read())
            {
                string name;
                int id;
                id = (int)reader["Id"];
                name = (string)reader["LocName"];
                
                var loc = new Location(id, name);
                result.Add(loc);
            }

            reader.Close();

            return result;
        }

        public IList<SecLevel> GetSecLevels()
        {
            SqlCommand getUsers = new SqlCommand("SELECT * from GetSecLevels()", _sqlConnection);

            var reader = getUsers.ExecuteReader();

            List<SecLevel> result = new List<SecLevel>();

            while (reader.Read())
            {
                string name, description;
                int id;
                id = (int)reader["Id"];
                name = (string)reader["LevelName"];
                description = (string)reader["LevelDescription"];

                var secLevel = new SecLevel(id, name, description);
                result.Add(secLevel);
            }

            reader.Close();

            return result;
        }

        public SecLevel GetSecLevelById(int secLevelId)
        {
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand getUser = new SqlCommand("SELECT * from dbo.GetSecLevelById(@id)", _sqlConnection);
            SqlParameter locationIdParam = new SqlParameter("@id", SqlDbType.Int);
            locationIdParam.Value = secLevelId;
            getUser.Parameters.Add(locationIdParam);

            var reader = getUser.ExecuteReader();
            if (reader.Read())
            {
                string name, description;
                int id;
                id = (int) reader["Id"];
                name = (string) reader["LevelName"];
                description = (string) reader["LevelDescription"];

                reader.Close();
                return new SecLevel(id, name, description);
            }

            reader.Close();
            return null;
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

        public Location CreateLocation(string name)
        {
            SqlCommand cmd = new SqlCommand("CreateLocation", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar);
            nameParam.Value = name;
            cmd.Parameters.Add(nameParam);

            SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int);
            idParam.Value = -1;
            idParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(idParam);
            
            cmd.ExecuteNonQuery();
            //int id = (int)cmd.ExecuteScalar();
            int id = (int)idParam.Value;

            return GetLocationById(id);
        }

        public SecLevel CreateSecLevel(string name, string description)
        {
            SqlCommand cmd = new SqlCommand("CreateSecLevel", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar);
            nameParam.Value = name;
            cmd.Parameters.Add(nameParam);
            SqlParameter desciptionParam = new SqlParameter("@description", SqlDbType.VarChar);
            desciptionParam.Value = description;
            cmd.Parameters.Add(desciptionParam);

            int id = (int)cmd.ExecuteScalar();

            return GetSecLevelById(id);
        }

        public void AddAccessibleLocation(SecLevel targetSecLevel, Location location)
        {
            SqlCommand cmd = new SqlCommand("AddAccessibleLocation", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter secLevelParam = new SqlParameter("@targetSecLevelId", SqlDbType.Int);
            secLevelParam.Value = targetSecLevel.Id;
            cmd.Parameters.Add(secLevelParam);
            SqlParameter locationParam = new SqlParameter("@locationId", SqlDbType.Int);
            locationParam.Value = location.Id;
            cmd.Parameters.Add(locationParam);

            cmd.ExecuteNonQuery();
        }

        public void RemoveAccessibleLocation(SecLevel targetSecLevel, Location location)
        {
            RemoveAccessibleLocation(targetSecLevel, location.Id);
        }

        public void RemoveAccessibleLocation(SecLevel targetSecLevel, int locationId)
        {
            SqlCommand cmd = new SqlCommand("RemoveAccessibleLocation", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter secLevelParam = new SqlParameter("@targetSecLevelId", SqlDbType.Int);
            secLevelParam.Value = targetSecLevel.Id;
            cmd.Parameters.Add(secLevelParam);
            SqlParameter locationParam = new SqlParameter("@locationId", SqlDbType.Int);
            locationParam.Value = locationId;
            cmd.Parameters.Add(locationParam);

            cmd.ExecuteNonQuery();
        }

        public IList<Location> GetAccessibleLocations(User user)
        {
            return GetAccessibleLocations(user.Id);
        }

        public IList<Location> GetAccessibleLocations(int userId)
        {
            /*SqlCommand cmd = new SqlCommand("GetAccessibleLocations", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;*/

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from dbo.GetAccessibleLocations(@id)", _sqlConnection);
            SqlParameter userIdParam = new SqlParameter("@id", SqlDbType.Int);
            userIdParam.Value = userId;
            cmd.Parameters.Add(userIdParam);

            var reader = cmd.ExecuteReader();

            List<Location> result = new List<Location>();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string name = (string)reader["LocName"];
                Location location = new Location(id, name);
                result.Add(location);
            }

            reader.Close();

            return result;
        }

        public IList<Location> GetSecLevelLocations(SecLevel secLevel)
        {
            return GetSecLevelLocations(secLevel.Id);
        }

        public IList<Location> GetSecLevelLocations(int secLevelId)
        {
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from dbo.GetSecLevelLocations(@id)", _sqlConnection);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = secLevelId;
            cmd.Parameters.Add(idParam);

            var reader = cmd.ExecuteReader();

            List<Location> result = new List<Location>();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string name = (string)reader["LocName"];
                Location location = new Location(id, name);
                result.Add(location);
            }

            reader.Close();

            return result;
        }

        public byte[] GetVoiceSample(int userId)
        {
            string query = "select VoiceData.VoiceSample\r\n" +
                           "\t\t\tfrom\r\n" +
                           "\t\t\t\tUsers\r\n" +
                           "\t\t\t\tjoin\r\n" +
                           "\t\t\t\tIdentData on Users.IdentDataId = IdentData.Id\r\n" +
                           "\t\t\t\tjoin\r\n" +
                           "\t\t\t\tVoiceData on IdentData.VoiceDataId = VoiceData.Id\r\n" +
                           $"\t\t\twhere Users.Id = {userId}";

            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            var reader = cmd.ExecuteReader();
            byte[] result = null;
            if (reader.Read())
            {
                SqlBytes bytes = reader.GetSqlBytes(0);
                if(!bytes.IsNull)
                    result = bytes.Value;
            }

            reader.Close();

            return result;
        }

        public int SetVoiceSample(int userId, byte[] voiceSample)
        {
            SqlCommand cmd = new SqlCommand("SetVoiceSample", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter userIdParam = new SqlParameter("@userId", SqlDbType.Int);
            userIdParam.Value = userId;
            cmd.Parameters.Add(userIdParam);

            SqlParameter voiceSampleParam = new SqlParameter("@voiceSample", SqlDbType.VarBinary, voiceSample.Length);
            /*SqlParameter voiceSampleParam = new SqlParameter();
            voiceSampleParam.ParameterName = "@voiceSample";
            //voiceSampleParam.TypeName = "varbinary(max)";
            voiceSampleParam.Direction = ParameterDirection.Input;
            voiceSampleParam.Value = voiceSample;*/
            voiceSampleParam.Value = voiceSample;
            cmd.Parameters.Add(voiceSampleParam);

            SqlParameter resultParam = new SqlParameter("@Id", SqlDbType.Int);
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultParam);

            cmd.ExecuteNonQuery();
            int voiceSampleId = (int)resultParam.Value;

            return voiceSampleId;
        }

        public void LoginAs(string userId, string password)
        {
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
                SqlCredential credential = new SqlCredential(userId, secString);
                
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

        public bool LoginSuccessful => _sqlConnection != null && _sqlConnection.State != ConnectionState.Closed;
    }
}
