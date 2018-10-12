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
    public partial class LabelText : UserControl
    {
        public LabelText()
        {
            InitializeComponent();
        }

        public string labelContent
        {           
            set
            {
                label1.Content = value;
            }
        }

        public string text
        {
            set
            {
                textBox1.Text = value;
            }
        }
    }
}
