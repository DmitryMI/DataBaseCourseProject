using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectApplication.SecSystem
{
    public class User
    {
        private int _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private int _identDataId;
        private int _secLevelId;
        private int _dbAccessLevelId;

        public int Id => _id;
        public string FirstName => _firstName;
        public string MiddleName => _middleName;
        public string LastName => _lastName;
        public int IdentDataId => _identDataId;
        public int SecLevelId => _secLevelId;
        public int DbAccessLevelId => _dbAccessLevelId;

        internal User(int id, string fn, string mn, string ln, int identid, int secid, int dblvlid)
        {
            _id = id;
            _firstName = fn;
            _middleName = mn;
            _lastName = ln;
            _identDataId = identid;
            _secLevelId = secid;
            _dbAccessLevelId = dblvlid;
        }

        internal User(int id, UserName name, int identid, int secid, int dblvlid)
        {
            _id = id;
            _firstName = name.FirstName;
            _middleName = name.MiddleName;
            _lastName = name.LastName;
            _identDataId = identid;
            _secLevelId = secid;
            _dbAccessLevelId = dblvlid;
        }
    }
}
