using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for FolderFormControl.xaml
    /// </summary>
    public partial class FolderFormControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly IFolderService _folderService;

        public FolderFormControl()
        {
            _folderService = DiConfig.Resolve<IFolderService>();

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
            if (string.IsNullOrEmpty(TextBoxName.Text))
                return;
            if (string.IsNullOrEmpty(TextBoxColor.Text))
                return;

            var folder = new FolderViewModel
            {
                Id = string.IsNullOrEmpty(TextBoxId.Text.Trim()) ? 0 : int.Parse(TextBoxId.Text.Trim()),
                Name = TextBoxName.Text,
                Color = TextBoxColor.Text
            };
            var result = _folderService.CreateOrUpdate(folder);
            Console.WriteLine("_folderService.CreateOrUpdate({0})={1}", folder, result);
            formClear();
        }

        private void formDelete()
        {
            if (string.IsNullOrEmpty(TextBoxId.Text.Trim()))
                return;

            var Id = int.Parse(TextBoxId.Text.Trim());
            var result = _folderService.Delete(Id);
            Console.WriteLine("_folderService.Delete({0})={1}", Id, result);
            formClear();
        }

        private void formClear()
        {
            TextBoxId.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            TextBoxColor.Text = string.Empty;
        }
    }
}