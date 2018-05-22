using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        private readonly IProductService _productService;

        public ProductControl()
        {
            _productService = DiConfig.Resolve<IProductService>();

            InitializeComponent();

            UCProductGrid.DataGridDoubleClick += DataGrid_MouseDoubleClick;
            UCProductForm.ButtonSaveClick += Button_Save;
            UCProductForm.ButtonDeleteClick += Button_Delete;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Delete");
            UCProductGrid.DataContext = new ProductGridControl.Data {ProductItems = _productService.GetAll()};
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::Button_Save");
            UCProductGrid.DataContext = new ProductGridControl.Data {ProductItems = _productService.GetAll()};
        }

        private void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("join::DataGrid_MouseDoubleClick");

            var product = (ProductViewModel) UCProductGrid.ProductDataGrid.SelectedItem;
            if (product != null)
            {
                UCProductForm.TextBoxId.Text = product.Id.ToString();
                UCProductForm.TextBoxName.Text = product.Name;
                UCProductForm.ComboBoxCategory.SelectedValue = product.CategoryId.ToString();
            }
        }
    }
}