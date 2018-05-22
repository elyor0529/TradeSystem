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
    ///     Interaction logic for FolderGridControl.xaml
    /// </summary>
    public partial class FolderGridControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly IFolderService _folderService;

        public FolderGridControl()
        {
            _folderService = DiConfig.Resolve<IFolderService>();

            InitializeComponent();

            DataContext = new Data {FolderItems = _folderService.GetAll()};

            FolderDataGrid.MouseDoubleClick += DataGrid_MouseDoubleClick;
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
            public IList<FolderViewModel> FolderItems { get; set; }
        }
    }
}