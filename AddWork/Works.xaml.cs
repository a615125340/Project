using ProjectModel;
using System;
using System.Collections.Generic;
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
        public string projectIDTextBox { get; internal set; }
        ProjectManagementEntities ProjectDBContext = new ProjectManagementEntities();
        public Works()
        {
            InitializeComponent();
            LoadProjectTreeView();
        }
        private void LoadProjectTreeView()
        {
            //ProjectTreeView.Items.Clear();
            //var q = ProjectDBContext.Works.Where(n=>n.ProjectID==.GroupBy(n => n.Project.ProjectName);
            //foreach (var dept in q)
            //{
            //    TreeViewItem x = new TreeViewItem();
            //    x.Header = dept.Key;
            //    ProjectTreeView.Items.Add(x);
            //    foreach (var projects in dept)
            //    {
            //        TreeViewItem y = new TreeViewItem();
            //        y.Header = projects.ProjectName;
            //        y.Selected += Y_Selected;
            //        x.Items.Add(y);
            //    }
            //}

        }
        private void Y_Selected(object sender, RoutedEventArgs e)
        {
           
        }

    }
    
}
