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
        public int IndexEmpl { get; set; }
        public int IndexDep { get; set; }
        public EmplWindow(int indE, int indD)
        {
            InitializeComponent();
            IndexDep = indD;
            IndexEmpl = indE;
            if(IndexEmpl >= 0)
            {
                txtName.Text = Comp.ListDep[IndexDep].ListWorker[IndexEmpl].Name;
                txtAge.Text = Convert.ToString(Comp.ListDep[IndexDep].ListWorker[IndexEmpl].Age);
                txtSal.Text = Convert.ToString(Comp.ListDep[IndexDep].ListWorker[IndexEmpl].Salary);
                cbDep.SelectedValue = Comp.ListDep[IndexDep];
            }
            cbDep.ItemsSource = Comp.ListDep;
        }

        private void TextBox_TextChangedName(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChangedAge(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChangedSalary(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// Сохраняет изменения в сотрудниках департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int age, salary;
            name = txtName.Text;
            if (Comp.GetValue(txtAge.Text) > Comp.WRONGVAL && Comp.GetValue(txtSal.Text) > Comp.WRONGVAL)
            {
                age = Comp.GetValue(txtAge.Text);
                salary = Comp.GetValue(txtSal.Text);
                if (IndexEmpl < 0)
                {
                    Employee newempl = new Employee(name, age, salary, cbDep.SelectedValue.ToString());
                    Comp.ListDep[IndexDep].AddEmpl(newempl);
                }
                else
                {
                    Comp.ListDep[IndexDep].ListWorker[IndexEmpl].Name = name;
                    Comp.ListDep[IndexDep].ListWorker[IndexEmpl].Age = age;
                    Comp.ListDep[IndexDep].ListWorker[IndexEmpl].Salary = salary;
                    int indep = Comp.GetDepIndex(cbDep.SelectedValue.ToString());
                    if(indep != IndexDep)
                    {
                        Comp.ListDep[IndexDep].ListWorker.RemoveAt(IndexEmpl);
                        Employee newempl = new Employee(name, age, salary, cbDep.SelectedValue.ToString());
                        Comp.ListDep[indep].AddEmpl(newempl);
                    }
                }
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                txtError.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
