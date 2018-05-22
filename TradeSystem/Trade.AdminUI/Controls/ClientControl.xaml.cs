using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for ClientControl.xaml
    /// </summary>
    public partial class ClientControl : UserControl
    {
        private readonly IClientService _clientService;

        public ClientControl()
        {
            _clientService = DiConfig.Resolve<IClientService>();

            InitializeComponent();

            UCClientGrid.DataGridDoubleClick += DataGrid_MouseDoubleClick;
            UCClientForm.ButtonSaveClick += Button_Save;
            UCClientForm.ButtonDeleteClick += Button_Delete;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Delete");
            UCClientGrid.DataContext = new ClientGridControl.Data {ClientItems = _clientService.GetAll()};
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Save");
            UCClientGrid.DataContext = new ClientGridControl.Data {ClientItems = _clientService.GetAll()};
        }

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::DataGrid_MouseDoubleClick");

            var client = (ClientViewModel) UCClientGrid.ClientDataGrid.SelectedItem;
            if (client != null)
            {
                UCClientForm.TextBoxId.Text = client.Id.ToString();
                UCClientForm.TextBoxFirstName.Text = client.FirstName;
                UCClientForm.TextBoxLastName.Text = client.LastName;
                UCClientForm.TextBoxAddress.Text = client.Address;
                UCClientForm.TextBoxPhone.Text = client.Phone;
                UCClientForm.ComboBoxClientType.SelectedValue = client.ClientTypeId.ToString();
            }
        }
    }
}