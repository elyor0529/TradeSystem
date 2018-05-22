using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for CategoryControl.xaml
    /// </summary>
    public partial class CategoryControl : UserControl
    {
        private readonly ICategoryService _categoryService;

        public CategoryControl()
        {
            _categoryService = DiConfig.Resolve<ICategoryService>();

            InitializeComponent();

            UCCategoryGrid.DataGridDoubleClick += DataGrid_MouseDoubleClick;
            UCCategoryForm.ButtonSaveClick += Button_Save;
            UCCategoryForm.ButtonDeleteClick += Button_Delete;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Delete");
            UCCategoryGrid.DataContext = new CategoryGridControl.Data {CategoryItems = _categoryService.GetAll()};
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Save");
            UCCategoryGrid.DataContext = new CategoryGridControl.Data {CategoryItems = _categoryService.GetAll()};
        }

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::DataGrid_MouseDoubleClick");

            var category = (CategoryViewModel) UCCategoryGrid.CategoryDataGrid.SelectedItem;
            if (category != null)
            {
                UCCategoryForm.TextBoxId.Text = category.Id.ToString();
                UCCategoryForm.TextBoxName.Text = category.Name;
                UCCategoryForm.ComboBoxFolder.SelectedValue = category.FolderId.ToString();
            }
        }
    }
}