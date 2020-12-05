using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using VISwpf.Common;
using VISwpf.Pages.Interfaces;

namespace VISwpf
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private readonly Regex RegexNamesFM = new Regex(@"^[а-яА-ЯёЁ]{1,30}$");
        private readonly Regex RegexNamesL = new Regex(@"^[а-яА-ЯёЁ]{1,20}$");

        private InterfaceUpdateDB interfaceUpdate;

        public AddEmployeeWindow(InterfaceUpdateDB interfaceUpdateDB)
        {
            InitializeComponent();
            var listDivision = AppDB.GetInstance().Division.ToList();
            var listPosition = AppDB.GetInstance().Position.ToList();

            this.interfaceUpdate = interfaceUpdateDB;

            foreach (Division division in listDivision)
                DataComBoxDivision.Items.Add(division);

            foreach (Position position in listPosition)
                DataComBoxPosition.Items.Add(position);
        }

        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!fieldTextValidation()) return;
            if (!datePickerValidation()) return;
            if (!fieldPickerValidation()) return;

            Employees employee = new Employees();
            employee.First_name = TBFirstName.Text;
            employee.Last_name = TBLastName.Text;
            employee.Middle_name = TBMiddleName.Text;
            employee.Birthday = (DateTime)DatePickerBirthday.SelectedDate;
            employee.FK_position = ((Position)DataComBoxPosition.SelectedItem).ID_position;
            employee.FK_division = ((Division)DataComBoxDivision.SelectedItem).ID_division;
            employee.Status_empl = "Работает";

            AppDB.GetInstance().Employees.Add(employee);
            AppDB.GetInstance().SaveChanges();
            interfaceUpdate.UpdateEmployeeList();
            this.Close();
        }

        private bool datePickerValidation()
        {
            if(DatePickerBirthday.SelectedDate == null)
            {
                MessageBox.Show("Дата рождения не выбрана");
                return false;
            }
            return true;
        }

        private bool fieldPickerValidation()
        {
            if (DataComBoxDivision.SelectedItem == null)
            {
                MessageBox.Show("Не выбрано подразделение");
                return false;
            }
            if (DataComBoxPosition.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана должность");
                return false;
            }
            return true;
        }

        private bool fieldTextValidation()
        {
            var fName = TBFirstName.Text;
            var lName = TBLastName.Text;
            var mName = TBMiddleName.Text;

            if (!validationNames(fName, TypesField.FIRST))
            {
                MessageBox.Show("Имя имеет неверный формат");
                return false;
            }
            else if (!validationNames(lName, TypesField.LAST))
            {
                MessageBox.Show("Фамилия имеет неверный формат");
                return false;
            }
            else if (!validationNames(mName, TypesField.MIDDLE))
            {
                MessageBox.Show("Отчество имеет неверный формат");
                return false;
            }
            return true;
        }

        public bool validationNames(string name, TypesField type)
        {
            switch (type)
            {
                case TypesField.FIRST:
                    if (!RegexNamesFM.IsMatch(name)) return false;
                    break;
                case TypesField.LAST:
                    if (!RegexNamesL.IsMatch(name)) return false;
                    break;
                case TypesField.MIDDLE:
                    if (!RegexNamesFM.IsMatch(name)) return false;
                    break;
            }
            
            return true;
        }

        public enum TypesField
        {
            FIRST,
            LAST,
            MIDDLE
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
