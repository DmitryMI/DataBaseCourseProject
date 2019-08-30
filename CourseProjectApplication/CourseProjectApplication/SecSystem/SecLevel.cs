using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectApplication.SecSystem
{
    public class SecLevel
    {
        private int _id;
        private string _name;
        private string _description;

        public int Id => _id;
        public string Name => _name;
        public string Description => _description;

        internal SecLevel(int id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
