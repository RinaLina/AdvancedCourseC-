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

namespace Company
{
    /// <summary>
    /// Interaction logic for DepWindow.xaml
    /// </summary>
    public partial class DepWindow : Window
    {
        public bool NewDep { get; set; }
        public DepWindow()
        {
            InitializeComponent();
            
        }
        public DepWindow(MainWindow w) : this()
        {
            NewDep = true;
            btnDepDef.Visibility = System.Windows.Visibility.Visible;
        }
        public DepWindow(Department dep) : this()
        {
            mainStackPanel.DataContext = dep;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(NewDep)
            {
                Comp.Adddep(txtName.Text);
            }
            this.DialogResult = true;
        }
        /// <summary>
        /// Добавляет стандартный департамент в компанию, пока использую для тестов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepDef_Click(object sender, RoutedEventArgs e)
        {
            Comp.AddDefult();
            this.DialogResult = true;
        }
    }
}
