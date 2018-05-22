using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for ClientFormControl.xaml
    /// </summary>
    public partial class ClientFormControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly IClientService _clientService;
        private readonly IClientTypeService _clientTypeService;

        public ClientFormControl()
        {
            _clientService = DiConfig.Resolve<IClientService>();
            _clientTypeService = DiConfig.Resolve<IClientTypeService>();

            InitializeComponent();

            ComboBoxClientType.ItemsSource = _clientTypeService.GetAll();
            ComboBoxClientType.DisplayMemberPath = "Name";
            ComboBoxClientType.SelectedValuePath = "Id";
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
            if (string.IsNullOrEmpty(TextBoxAddress.Text))
                return;
            if (string.IsNullOrEmpty(TextBoxPhone.Text))
                return;
            if (string.IsNullOrEmpty(ComboBoxClientType.SelectedValue.ToString()))
                return;

            var client = new ClientViewModel
            {
                Id = string.IsNullOrEmpty(TextBoxId.Text.Trim()) ? 0 : int.Parse(TextBoxId.Text.Trim()),
                FirstName = TextBoxFirstName.Text,
                LastName = TextBoxLastName.Text,
                Address = TextBoxAddress.Text,
                Phone = TextBoxPhone.Text,
                ClientTypeId = int.Parse(ComboBoxClientType.SelectedValue.ToString())
            };
            var result = _clientService.CreateOrUpdate(client);
            Console.WriteLine("_clientService.CreateOrUpdate({0})={1}", client, result);
            formClear();
        }

        private void formDelete()
        {
            if (string.IsNullOrEmpty(TextBoxId.Text.Trim()))
                return;

            var Id = int.Parse(TextBoxId.Text.Trim());
            var result = _clientService.Delete(Id);
            Console.WriteLine("_clientService.Delete({0})={1}", Id, result);
            formClear();
        }

        private void formClear()
        {
            TextBoxId.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
            TextBoxAddress.Text = string.Empty;
            TextBoxPhone.Text = string.Empty;
            ComboBoxClientType.SelectedIndex = -1;
        }
    }
}