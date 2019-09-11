using System.Collections.Generic;

namespace CourseProjectApplication.SecSystem
{
    public interface ISecSystem
    {
        User GetUserById(int userId);
        IList<User> GetUsers();
        Location GetLocationById(int locationId);
        IList<Location> GetLocations();
        SecLevel GetSecLevelById(int secLevelId);
        IList<SecLevel> GetSecLevels();



        User RegisterUser(UserName name, string password);
        Location CreateLocation(string name);
        SecLevel CreateSecLevel(string name, string description);

        void AddAccessibleLocation(SecLevel targetSecLevel, Location location);
        void RemoveAccessibleLocation(SecLevel targetSecLevel, Location location);
        void RemoveAccessibleLocation(SecLevel targetSecLevel, int locationId);
        IList<Location> GetAccessibleLocations(User user);
        IList<Location> GetAccessibleLocations(int userId);
        IList<Location> GetSecLevelLocations(SecLevel secLevel);
        IList<Location> GetSecLevelLocations(int secLevelId);

        byte[] GetVoiceSample(int userId);
        int SetVoiceSample(int userId, byte[] voiceSample);

        void LoginAs(string userId, string password);
        bool LoginSuccessful { get; }
    }
}
