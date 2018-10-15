using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWork.Model
{
    class WorksListBox
    {
        public string ProjectID { get; set; }
        public string WorkName { get; set; }
        public string WorkID { get; set; }
        public int ParentWorkID { get; set; }
        public List<WorksListBox> Children { get; set; }
        public WorksListBox()
        {
            Children = new List<WorksListBox>();
        }
    }
}
