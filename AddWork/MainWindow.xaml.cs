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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Aga.Controls.Tree;
using System.Collections;
using Microsoft.Win32;
using ProjectModel;
using System.Globalization;
using AddWork.Model;

namespace AddWork
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        ProjectManagementEntities ProjectDBContext = new ProjectManagementEntities();
        System.Windows.Data.CollectionViewSource projectViewSource;
        public MainWindow()
        {
            InitializeComponent();
            LoadDeptTreeView();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            AddWork.ProjectManagementDataSet projectManagementDataSet = ((AddWork.ProjectManagementDataSet)(this.FindResource("projectManagementDataSet")));
            // 將資料載入資料表 Project。您可以視需要修改這個程式碼。
            AddWork.ProjectManagementDataSetTableAdapters.ProjectTableAdapter projectManagementDataSetProjectTableAdapter = new AddWork.ProjectManagementDataSetTableAdapters.ProjectTableAdapter();
            projectManagementDataSetProjectTableAdapter.Fill(projectManagementDataSet.Project);
            projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
            // 將資料載入資料表 Department。您可以視需要修改這個程式碼。
            AddWork.ProjectManagementDataSetTableAdapters.DepartmentTableAdapter projectManagementDataSetDepartmentTableAdapter = new AddWork.ProjectManagementDataSetTableAdapters.DepartmentTableAdapter();
            projectManagementDataSetDepartmentTableAdapter.Fill(projectManagementDataSet.Department);
            System.Windows.Data.CollectionViewSource departmentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("departmentViewSource")));
            //departmentViewSource.View.MoveCurrentToFirst();
            // 將資料載入資料表 ProjectCategory。您可以視需要修改這個程式碼。
            AddWork.ProjectManagementDataSetTableAdapters.ProjectCategoryTableAdapter projectManagementDataSetProjectCategoryTableAdapter = new AddWork.ProjectManagementDataSetTableAdapters.ProjectCategoryTableAdapter();
            projectManagementDataSetProjectCategoryTableAdapter.Fill(projectManagementDataSet.ProjectCategory);
            System.Windows.Data.CollectionViewSource projectCategoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectCategoryViewSource")));
            projectCategoryViewSource.View.MoveCurrentToFirst();
        }

        private void Y_Selected(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TreeViewItem selectprojectname = sender as System.Windows.Controls.TreeViewItem;
            var q = ProjectDBContext.Projects.Where(n => n.ProjectName == selectprojectname.Header.ToString());
            foreach (var project in q)
            {
                projectIDTextBox.Text = project.ProjectID;
                projectNameTextBox.Text = project.ProjectName;
                projectCategoryIDTextBox.Text = project.ProjectCategoryID;
                projectSupervisorIDTextBox.Text = project.ProjectSupervisorID.ToString();
                projectStatusIDTextBox.Text = project.ProjectStatusID;
                requiredDeptIDTextBox.Text = project.RequiredDeptID.ToString();
                requiredDeptPMIDTextBox.Text = project.RequiredDeptPMID.ToString();
                startDateTextBox.Text = project.StartDate.ToString();
                endDateTextBox.Text = project.EndDate.ToString();
                estStartDateTextBox.Text = project.EstStartDate.ToString();
                estEndDateTextBox.Text = project.EstEndDate.ToString();
                inChargeDeptIDTextBox.Text = project.InChargeDeptID.ToString();
                inChargeDeptPMIDTextBox.Text = project.InChargeDeptPMID.ToString();
                isGeneralManagerConcernedCheckBox.IsChecked = project.IsGeneralManagerConcerned;
            }
            treelist1.Model = new TreeModel();
        }

        private void AddProject()
        {
            ProjectModel.Project project = new ProjectModel.Project
            {
                ProjectID = projectIDTextBox.Text,
                ProjectName = projectNameTextBox.Text,
                ProjectCategoryID = projectCategoryIDTextBox.Text,
                ProjectSupervisorID = int.Parse(projectSupervisorIDTextBox.Text),
                ProjectStatusID = projectStatusIDTextBox.Text,
                RequiredDeptID = int.Parse(requiredDeptIDTextBox.Text),
                RequiredDeptPMID = int.Parse(requiredDeptPMIDTextBox.Text),
                StartDate = DateTime.Parse(startDateTextBox.Text),
                EndDate = DateTime.Parse(endDateTextBox.Text),
                EstStartDate = DateTime.Parse(estStartDateTextBox.Text),
                EstEndDate = DateTime.Parse(estEndDateTextBox.Text),
                InChargeDeptID = int.Parse(inChargeDeptIDTextBox.Text),
                InChargeDeptPMID = int.Parse(inChargeDeptPMIDTextBox.Text),
                IsGeneralManagerConcerned = isGeneralManagerConcernedCheckBox.IsChecked,

            };
            ProjectDBContext.Projects.Local.Add(project);
        }
        private void LoadDeptTreeView()
        {
            DeptTreeView.Items.Clear();
            var q = ProjectDBContext.Projects.GroupBy(n => n.Department.DepartmentName);
            foreach (var dept in q)
            {
                TreeViewItem x = new TreeViewItem();
                x.Header = dept.Key;
                DeptTreeView.Items.Add(x);
                foreach (var projects in dept)
                {
                    TreeViewItem y = new TreeViewItem();
                    y.Header = projects.ProjectName;
                    y.Selected += Y_Selected;
                    x.Items.Add(y);
                }
            }

        }
        private void UpdateProject()
        {
            var q = ProjectDBContext.Projects.Find(projectIDTextBox.Text);
            q.ProjectID = projectIDTextBox.Text.ToString();
            q.ProjectName = projectNameTextBox.Text.ToString();
            q.ProjectCategoryID = projectCategoryIDTextBox.Text;
            q.ProjectSupervisorID = int.Parse(projectSupervisorIDTextBox.Text);
            q.ProjectStatusID = projectStatusIDTextBox.Text;
            q.RequiredDeptID = int.Parse(requiredDeptIDTextBox.Text);
            q.RequiredDeptPMID = int.Parse(requiredDeptPMIDTextBox.Text);
            q.StartDate = DateTime.Parse(startDateTextBox.Text);
            q.EndDate = DateTime.Parse(endDateTextBox.Text);
            q.EstStartDate = DateTime.Parse(estStartDateTextBox.Text);
            q.EstEndDate = DateTime.Parse(estEndDateTextBox.Text);
            q.InChargeDeptID = int.Parse(inChargeDeptIDTextBox.Text);
            q.InChargeDeptPMID = int.Parse(inChargeDeptPMIDTextBox.Text);
            q.IsGeneralManagerConcerned = isGeneralManagerConcernedCheckBox.IsChecked;
        }
        private void DeleteProject()
        {
            var q = ProjectDBContext.Projects.Where(n => n.ProjectID == projectIDTextBox.Text).First();

            if (q != null)
            {
                ProjectDBContext.Projects.Remove(q);
            }
            ProjectDBContext.SaveChanges();
            projectViewSource.View.Refresh();
        }
        private void ColumnClear()
        {
            projectIDTextBox.Text = "";
            projectNameTextBox.Text = "";
            projectCategoryIDTextBox.Text = "";
            projectSupervisorIDTextBox.Text = "";
            projectStatusIDTextBox.Text = "";
            requiredDeptIDTextBox.Text = "";
            requiredDeptPMIDTextBox.Text = "";
            startDateTextBox.Text = "";
            endDateTextBox.Text = "";
            estStartDateTextBox.Text = "";
            estEndDateTextBox.Text = "";
            inChargeDeptIDTextBox.Text = "";
            inChargeDeptPMIDTextBox.Text = "";
            isGeneralManagerConcernedCheckBox.IsChecked = false;
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var q = ProjectDBContext.Projects.Find(projectIDTextBox.Text);
            if (q == null)
            {
                AddProject();
            }
            else
            {
                UpdateProject();
            }
            ProjectDBContext.SaveChanges();
            LoadDeptTreeView();
        }
        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteProject();            
            LoadDeptTreeView();
            ColumnClear();
        }
        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDeptTreeView();
            ColumnClear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (projectIDTextBox.Text == "" || projectIDTextBox.Text == null)
            {
            }
            else
            {
                SaveMenuItem_Click(sender, e);
                Works works = new Works();

                works.projectIDTextBox = projectIDTextBox.Text;

                works.Show();
            }
           
        }
    }
    

}

public class Project
{
    public string Step { get; set; }
    public string Name { get; set; }
    public string Kind { get; set; }
    public string Data { get; set; }
}

