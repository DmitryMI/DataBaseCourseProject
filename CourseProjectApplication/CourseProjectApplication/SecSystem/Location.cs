using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectApplication.SecSystem
{
    class Location
    {
        private int _id;
        private string _name;

        public int Id => _id;
        public string Name => _name;

        internal Location(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
