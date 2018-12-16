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
    /// Interaction logic for Change.xaml
    /// </summary>
    public partial class EmplWindow : Window
    {
        public bool NewEmpl = false;
        public EmplWindow()
        {
            InitializeComponent();
            cbDep.ItemsSource = Comp.ListDep;         
        }

        public EmplWindow(MainWindow w) : this()
        {
            NewEmpl = true;
        }
        public EmplWindow(Employee em) : this()
        {
            mainStackPanel.DataContext = em;
            cbDep.SelectedValue = Comp.ListDep[Comp.GetDepIndex(em.NameDep)];
        }

        /// <summary>
        /// Сохраняет изменения в сотрудниках департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {          
            if (NewEmpl)
            {
                Comp.Addempl(txtName.Text, Comp.GetValue(txtAge.Text), Comp.GetValue(txtSal.Text),
                    cbDep.SelectedValue.ToString());
            }            
            this.DialogResult = true;
        }
    }
}
