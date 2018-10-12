using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWork.Model
{
    class ProjectColumn
    {
        public string ProjectName { get; set; }
        public int RequiredDeptID { get; set; }
        public int RequiredDeptPMID { get; set; }
        public DateTime EstStartDate { get; set; }
        public DateTime EstEndDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int InChargeDeptID { get; set; }
        public int InChargeDeptPMID { get; set; }
        public int ProjectStatusID { get; set; }
        public int ProjectCategoryID { get; set; }
        public int ProjectSupervisorID { get; set; }
        public bool IsGeneralManagerConcerned { get; set; }
    }

}
