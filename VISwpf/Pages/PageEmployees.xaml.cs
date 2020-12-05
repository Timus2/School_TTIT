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
using VISwpf.Common;
using VISwpf.Pages.Interfaces;

namespace VISwpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEmployees.xaml
    /// </summary>
    public partial class PageEmployees : Page, InterfaceUpdateDB
    {
        private List<Full_employees> listFullEmployees;
        public PageEmployees()
        {
            InitializeComponent();
            UpdateEmployeeList();
        }


        public void UpdateEmployeeList()
        {
            var list = AppDB.GetInstance().Full_employees.ToList();
            listFullEmployees = list;
            DataGridEmployes.ItemsSource = listFullEmployees;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployes.SelectedItem == null)
            {
                MessageBox.Show("Сотрудник не выбран");
                return;
            }
            var employee = AppDB.GetInstance().Employees.Where((selected) => selected.ID_employee == ((Full_employees)DataGridEmployes.SelectedItem).ID).FirstOrDefault();
            AppDB.GetInstance().Employees.Remove(employee);
            AppDB.GetInstance().SaveChanges();
            AppDB.RefreshDB();
            UpdateEmployeeList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(this);
            addEmployeeWindow.Show();
        }
    }
}
