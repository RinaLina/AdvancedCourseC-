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
        public int IndexDep { get; set; }
        public DepWindow(int indD)
        {
            IndexDep = indD;
            InitializeComponent();
            if (IndexDep == Comp.NEWINDEX)
            {
                btnDepDef.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                txtName.Text = Comp.ListDep[IndexDep].NameDepart;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(IndexDep  == Comp.NEWINDEX)
            {
                Department dep = new Department(txtName.Text);
                Comp.Adddep(dep);
            }
            else
            {
                Comp.ListDep[IndexDep].NameDepart = txtName.Text;
            }
            SafeClose();
        }
        /// <summary>
        /// Добавляет стандартный департамент в компанию, пока использую для тестов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepDef_Click(object sender, RoutedEventArgs e)
        {
            Department dep = new Department();
            Comp.Adddep(dep);
            SafeClose();
        }
        /// <summary>
        /// Закрывает форму изменение департамента и открывает основную
        /// </summary>
        private void SafeClose()
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        
    }
}
