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

namespace AddWork
{
    /// <summary>
    /// LabelText.xaml 的互動邏輯
    /// </summary>
    public partial class LabelComboBox : UserControl
    {
        public LabelComboBox()
        {
            InitializeComponent();
            comboBox1.SelectionChanged += ComboBox1_SelectionChanged;
        }

        public delegate void EventArgs (object sender, SelectionChangedEventArgs e);
        public event EventArgs SelectionChanged;
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectionChanged == null)
            {
            }
            else
            {
                SelectionChanged(sender, e);
            }
        }
           

        public string labelContent
        {           
            set
            {
                label1.Content = value;
            }
        }

        public int selectIndex
        {
            set
            {
                comboBox1.SelectedIndex=value;
            }
        }

        public string addItems
        {
            set
            {
                comboBox1.Items.Add(value);
            }
        }
    }
}
