using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for CategoryFormControl.xaml
    /// </summary>
    public partial class CategoryFormControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly ICategoryService _categoryService;
        private readonly IFolderService _folderService;

        public CategoryFormControl()
        {
            _categoryService = DiConfig.Resolve<ICategoryService>();
            _folderService = DiConfig.Resolve<IFolderService>();

            InitializeComponent();

            ComboBoxFolder.ItemsSource = _folderService.GetAll();
            ComboBoxFolder.DisplayMemberPath = "Name";
            ComboBoxFolder.SelectedValuePath = "Id";
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
            if (string.IsNullOrEmpty(ComboBoxFolder.SelectedValue.ToString()))
                return;

            var category = new CategoryViewModel
            {
                Id = string.IsNullOrEmpty(TextBoxId.Text.Trim()) ? 0 : int.Parse(TextBoxId.Text.Trim()),
                Name = TextBoxName.Text,
                FolderId = int.Parse(ComboBoxFolder.SelectedValue.ToString())
            };
            var result = _categoryService.CreateOrUpdate(category);
            Console.WriteLine("_categoryService.CreateOrUpdate({0})={1}", category, result);
            formClear();
        }

        private void formDelete()
        {
            if (string.IsNullOrEmpty(TextBoxId.Text.Trim()))
                return;

            var Id = int.Parse(TextBoxId.Text.Trim());
            var result = _categoryService.Delete(Id);
            Console.WriteLine("_categoryService.Delete({0})={1}", Id, result);
            formClear();
        }

        private void formClear()
        {
            TextBoxId.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            ComboBoxFolder.SelectedIndex = -1;
        }
    }
}