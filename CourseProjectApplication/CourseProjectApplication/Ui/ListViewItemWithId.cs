using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectApplication.Ui
{
    class ListViewItemWithId : ListViewItem
    {
        public int Id { get; set; }

        public ListViewItemWithId(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
