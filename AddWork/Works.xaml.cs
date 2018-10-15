using AddWork.Model;
using Aga.Controls.Tree;
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

        public TextBlock projectIDTextBox { get; internal set; }
        public TextBox projectNameTextBox { get; internal set; }

        public void LoadProjectTreeView()
        {
            ProjectTreeView.Model = new WorksTreeModel(projectIDTextBox.Text, projectNameTextBox.Text);            
        }

        private void ProjectTreeView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;           
            var q = ProjectDBContext.Tasks.Where(n => n.WorkID == (int)textBlock.Tag).
                Select(n=>
                new { 工作名稱=n.Work.WorkName,任務代號=n.TaskID,任務名稱=n.TaskName,預計開始時間=n.EstStartDate,預計結束時間=n.EstEndDate,開始時間=n.StartDate,結束時間=n.EndDate,}                
                );
            dataGrid1.ItemsSource = q.ToList();
        }
    }
    
}
