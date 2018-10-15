using Aga.Controls.Tree;
using ProjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddWork.Model
{
    public class WorksTreeModel : ITreeModel
    {
        ProjectManagementEntities ProjectDBContext = new ProjectManagementEntities();
        private string projectIDTextBox;
        private string projectNameTextBox;

        public WorksTreeModel()
        {
            
        }

        public WorksTreeModel(string projectIDTextBox, string projectNameTextBox)
        {
            this.projectIDTextBox = projectIDTextBox;
            this.projectNameTextBox = projectNameTextBox;
        }

        public bool HasChildren(object parent)//當return true表示還有子項目，會在往下增加階層
        {
            return (parent as WorksModel).ChildCount > 0;
        }

        IEnumerable ITreeModel.GetChildren(object parent)
        {
            
            if (parent == null)
            {
                
                var q = ProjectDBContext.Works.Where(n => n.ProjectID == projectIDTextBox && n.ParentWorkID == null);
                foreach (var x in q)
                {
                    WorksModel worksModel = new WorksModel
                    {
                        ChildCount = ProjectDBContext.Works.Where(n => n.ParentWorkID == x.WorkID).Count(),
                        WorkName = x.WorkName ,
                        WorkID = x.WorkID
                    };
                    yield return worksModel;
                }
                
            }
            else
            {
                WorksModel subWorksModel = parent as WorksModel;
                var q = ProjectDBContext.Works.Where(n => n.ParentWorkID ==subWorksModel.WorkID);


                foreach (var x in q)
                {
                    WorksModel worksModel = new WorksModel
                    {
                        ChildCount = ProjectDBContext.Works.Where(n => n.ParentWorkID == x.WorkID).Count(),
                        WorkName = x.WorkName,
                        WorkID = x.WorkID
                    };
                    yield return worksModel;
                }

            }
        }
    }
    public class WorksModel
    {
        public int ChildCount { get; set; }
        public string WorkName { get; set; }
        public int WorkID { get; internal set; }
    }
}
