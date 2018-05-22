using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeControl()
        {
            _employeeService = DiConfig.Resolve<IEmployeeService>();

            InitializeComponent();

            UCEmployeeGrid.DataGridDoubleClick += DataGrid_MouseDoubleClick;
            UCEmployeeForm.ButtonSaveClick += Button_Save;
            UCEmployeeForm.ButtonDeleteClick += Button_Delete;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Delete");
            UCEmployeeGrid.DataContext = new EmployeeGridControl.Data {EmployeeItems = _employeeService.GetAll()};
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Save");
            UCEmployeeGrid.DataContext = new EmployeeGridControl.Data {EmployeeItems = _employeeService.GetAll()};
        }

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::DataGrid_MouseDoubleClick");

            var employee = (EmployeeViewModel) UCEmployeeGrid.EmployeeDataGrid.SelectedItem;
            if (employee != null)
            {
                UCEmployeeForm.TextBoxId.Text = employee.Id.ToString();
                UCEmployeeForm.TextBoxFirstName.Text = employee.FirstName;
                UCEmployeeForm.TextBoxLastName.Text = employee.LastName;
            }
        }
    }
}