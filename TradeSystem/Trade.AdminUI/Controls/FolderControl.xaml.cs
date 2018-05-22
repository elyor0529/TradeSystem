using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for FolderControl.xaml
    /// </summary>
    public partial class FolderControl : UserControl
    {
        private readonly IFolderService _folderService;

        public FolderControl()
        {
            _folderService = DiConfig.Resolve<IFolderService>();

            InitializeComponent();

            UCFolderGrid.DataGridDoubleClick += DataGrid_MouseDoubleClick;
            UCFolderForm.ButtonSaveClick += Button_Save;
            UCFolderForm.ButtonDeleteClick += Button_Delete;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Delete");
            UCFolderGrid.DataContext = new FolderGridControl.Data {FolderItems = _folderService.GetAll()};
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Save");
            UCFolderGrid.DataContext = new FolderGridControl.Data {FolderItems = _folderService.GetAll()};
        }

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::DataGrid_MouseDoubleClick");

            var folder = (FolderViewModel) UCFolderGrid.FolderDataGrid.SelectedItem;
            if (folder != null)
            {
                UCFolderForm.TextBoxId.Text = folder.Id.ToString();
                UCFolderForm.TextBoxName.Text = folder.Name;
                UCFolderForm.TextBoxColor.Text = folder.Color;
            }
        }
    }
}