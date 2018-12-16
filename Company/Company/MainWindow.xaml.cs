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

namespace Company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listDep.ItemsSource = Comp.ListDep;
            
        }
        /// <summary>
        /// Удаляет выбранного сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmplDel_Click(object sender, RoutedEventArgs e)
        {
            Comp.DelEmpl(listDep.SelectedIndex, listEmp.SelectedIndex);
        }
        /// <summary>
        /// Открывает форму для создания сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmplAdd_Click(object sender, RoutedEventArgs e)
        {
            new EmplWindow(this).ShowDialog();
        }
        /// <summary>
        /// Открывает форму для изменения выбранного сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listEmp_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var frm = new EmplWindow(listEmp.SelectedItem as Employee);
            frm.ShowDialog();
        }


        /// <summary>
        /// Открывает форму для изменения  департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepAdd_Click(object sender, RoutedEventArgs e)
        {
            new DepWindow(this).ShowDialog();
        }
        /// <summary>
        /// Открывает форму для создания департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDep_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var frm = new DepWindow(listDep.SelectedItem as Department);
            frm.ShowDialog();
        }
        /// <summary>
        /// Удаляет выбранный департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepDel_Click(object sender, RoutedEventArgs e)
        {
            Comp.DeleteDep(listDep.SelectedIndex);
        }
        /// <summary>
        /// Показывает список сотрудников отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDep_MouseUp(object sender, RoutedEventArgs e)
        {
            listEmp.ItemsSource = Comp.ListDep[listDep.SelectedIndex].ListWorker;
        }
    }
}
