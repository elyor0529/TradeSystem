using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for EmployeeFormControl.xaml
    /// </summary>
    public partial class EmployeeFormControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly IEmployeeService _employeeService;

        public EmployeeFormControl()
        {
            _employeeService = DiConfig.Resolve<IEmployeeService>();

            InitializeComponent();
        }

        // Event declaration
        public event EventHandler ButtonSaveClick;
        public event EventHandler ButtonDeleteClick;

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("own::Button_Save");
            // Check if event is null  
            if (ButtonSaveClick != null)
            {
                formSave();
                ButtonSaveClick(sender, e);
            }
            else
            {
                // execute user control code 
                formSave();
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("own::Button_Delete");
            // Check if event is null  
            if (ButtonDeleteClick != null)
            {
                formDelete();
                ButtonDeleteClick(sender, e);
            }
            else
            {
                // execute user control code 
                formDelete();
            }
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            formClear();
        }

        private void formSave()
        {
            if (string.IsNullOrEmpty(TextBoxFirstName.Text))
                return;
            if (string.IsNullOrEmpty(TextBoxLastName.Text))
                return;

            var employee = new EmployeeViewModel
            {
                Id = string.IsNullOrEmpty(TextBoxId.Text.Trim()) ? 0 : int.Parse(TextBoxId.Text.Trim()),
                FirstName = TextBoxFirstName.Text,
                LastName = TextBoxLastName.Text
            };
            var result = _employeeService.CreateOrUpdate(employee);
            Console.WriteLine("_employeeService.CreateOrUpdate({0})={1}", employee, result);
            formClear();
        }

        private void formDelete()
        {
            if (string.IsNullOrEmpty(TextBoxId.Text.Trim()))
                return;

            var Id = int.Parse(TextBoxId.Text.Trim());
            var result = _employeeService.Delete(Id);
            Console.WriteLine("_employeeService.Delete({0})={1}", Id, result);
            formClear();
        }

        private void formClear()
        {
            TextBoxId.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
        }
    }
}