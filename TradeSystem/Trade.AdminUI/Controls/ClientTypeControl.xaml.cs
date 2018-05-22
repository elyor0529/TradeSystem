using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for ClientTypeControl.xaml
    /// </summary>
    public partial class ClientTypeControl : UserControl
    {
        private readonly IClientTypeService _clientTypeService;

        public ClientTypeControl()
        {
            _clientTypeService = DiConfig.Resolve<IClientTypeService>();

            InitializeComponent();

            UCClientTypeGrid.DataGridDoubleClick += DataGrid_MouseDoubleClick;
            UCClientTypeForm.ButtonSaveClick += Button_Save;
            UCClientTypeForm.ButtonDeleteClick += Button_Delete;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Delete");
            UCClientTypeGrid.DataContext = new ClientTypeGridControl.Data
            {
                ClientTypeItems = _clientTypeService.GetAll()
            };
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Save");
            UCClientTypeGrid.DataContext = new ClientTypeGridControl.Data
            {
                ClientTypeItems = _clientTypeService.GetAll()
            };
        }

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::DataGrid_MouseDoubleClick");

            var folder = (ClientTypeViewModel) UCClientTypeGrid.ClientTypeDataGrid.SelectedItem;
            if (folder != null)
            {
                UCClientTypeForm.TextBoxId.Text = folder.Id.ToString();
                UCClientTypeForm.TextBoxName.Text = folder.Name;
            }
        }
    }
}