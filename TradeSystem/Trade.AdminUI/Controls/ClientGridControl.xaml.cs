using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for ClientGridControl.xaml
    /// </summary>
    public partial class ClientGridControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly IClientService _clientService;

        public ClientGridControl()
        {
            _clientService = DiConfig.Resolve<IClientService>();

            InitializeComponent();

            DataContext = new Data {ClientItems = _clientService.GetAll()};

            ClientDataGrid.MouseDoubleClick += DataGrid_MouseDoubleClick;
        }

        // Event declaration
        public event EventHandler DataGridDoubleClick;

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("own::DataGrid_MouseDoubleClick");
            // Check if event is null  
            if (DataGridDoubleClick != null)
            {
                DataGridDoubleClick(sender, e);
            }
            // execute user control code 
        }

        public class Data
        {
            public IList<ClientViewModel> ClientItems { get; set; }
        }
    }
}