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
        public int IndexE { get; set; }
        public int IndexD{ get; set; }
        public MainWindow()
        {
            InitializeComponent();
            listDep.ItemsSource = Comp.ListDep;
        }

        private void listDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listDep.SelectedItem != null)
            {
                int index = listDep.SelectedIndex;
                listEmp.ItemsSource = Comp.ListDep[index].ListWorker;
            }
        }
        /// <summary>
        /// Открывает форму для изменения выбранного сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmplChange_Click(object sender, RoutedEventArgs e)
        {
            if (listDep.SelectedItem != null && listEmp.SelectedItem != null)
            {

                IndexE = listEmp.SelectedIndex;
                IndexD = listDep.SelectedIndex;
                OpenWindowEmpl();
            }
        }
        /// <summary>
        /// Удаляет выбранный департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepDel_Click(object sender, RoutedEventArgs e)
        {
            int indexD = listDep.SelectedIndex;
            Comp.DeleteDep(indexD);
        }
        /// <summary>
        /// Удаляет выбранного сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmplDel_Click(object sender, RoutedEventArgs e)
        {
            int indexE = listEmp.SelectedIndex;
            int indexD = listDep.SelectedIndex;
            Comp.ListDep[indexD].ListWorker.RemoveAt(indexE);
        }
        /// <summary>
        /// Открывает форму для создания департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepAdd_Click(object sender, RoutedEventArgs e)
        {
            IndexD = Comp.NEWINDEX;
            OpenDepWindow();
        }
        /// <summary>
        /// открывает форму измнения департамента
        /// </summary>
        private void OpenDepWindow()
        {
            DepWindow depWindow = new DepWindow(IndexD);
            depWindow.Show();
            this.Close();
        }
        /// <summary>
        /// Открывает форму изменения сотрудника
        /// </summary>
        private void OpenWindowEmpl()
        {
            EmplWindow emplWindow = new EmplWindow(IndexE, IndexD);
            
            emplWindow.Show();
            this.Close();
        }
        /// <summary>
        /// Открывает форму для изменения выбранного департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepChange_Click(object sender, RoutedEventArgs e)
        {
            IndexD = listDep.SelectedIndex;
            OpenDepWindow();
        }
        /// <summary>
        /// Открывает форму для создания сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmplAdd_Click(object sender, RoutedEventArgs e)
        {
            if (listDep.SelectedItem != null)
            {
                IndexE = Comp.NEWINDEX;
                IndexD = listDep.SelectedIndex;
                OpenWindowEmpl();
            }
            
        }
    }
}
