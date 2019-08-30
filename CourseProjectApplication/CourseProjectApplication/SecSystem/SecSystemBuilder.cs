using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectApplication.SecSystem
{
    static class SecSystemBuilder
    {
        private static ISecSystem _instance;
        public static ISecSystem GetInstance()
        {
            if(_instance == null)
                _instance = new SecSystemBridge();

            return _instance;
        }
    }
}
