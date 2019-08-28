using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProjectApplication.SecSystem;

namespace CourseProjectApplication
{
    interface ISecSystem
    {
        User GetUserById(int userId);
        User RegisterUser(UserName name, string password);
        IList<Location> GetAccessibleLocations(User user);

        void LoginAs(string userId, string password);
    }
}
