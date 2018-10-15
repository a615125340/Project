using AddWork.Model;
using ProjectModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AddWork
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Works : Window
    {

        ProjectManagementEntities ProjectDBContext = new ProjectManagementEntities();
        public Works()
        {
            InitializeComponent();            
        }

        public TextBox projectIDTextBox { get; internal set; }
        public TextBox projectNameTextBox { get; internal set; }

        public void LoadProjectTreeView()
        {
            ProjectTreeView.Model = new WorksTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);            
        }
        public void LoadProjectListBox()
        {
            ListBox works = (ListBox)this.Resources["subWorks"];            
            List<WorksListBox> worksListBoxes = new List<WorksListBox>();
            var q = ProjectDBContext.Works.Where(n => n.ProjectID == projectIDTextBox.Text);
            foreach (var x in q.Where(n=>n.ParentWorkID==null))
            {
                WorksListBox listBox = new WorksListBox()
                {
                    WorkName = x.WorkName,
                    WorkID = x.WorkID,
                };
                worksListBoxes.Add(listBox);
            }
            works.ItemsSource = worksListBoxes;
            stackPanel1.Children.Add(works);
        }

        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //ListBox works = (ListBox)this.Resources["subWorks"];
            ListBox works = new ListBox();
            ListBox selectitem = sender as ListBox;
            WorksListBox parentworks = selectitem.SelectedItem as WorksListBox;
            List<WorksListBox> worksListBoxes = new List<WorksListBox>();
            var q = ProjectDBContext.Works.Where(n => n.ProjectID == projectIDTextBox.Text);
            foreach (var x in q.Where(n => n.ParentWorkID == parentworks.WorkID))
            {
                WorksListBox listBox = new WorksListBox()
                {
                    WorkName = x.WorkName,
                    WorkID = x.WorkID,
                };
                worksListBoxes.Add(listBox);
            }
            works.ItemsSource = worksListBoxes;
            stackPanel1.Children.Add(works);
        }
    }
    
}
