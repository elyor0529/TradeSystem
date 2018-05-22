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
    ///     Interaction logic for ProductGridControl.xaml
    /// </summary>
    public partial class ProductGridControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly IProductService _productService;

        public ProductGridControl()
        {
            _productService = DiConfig.Resolve<IProductService>();

            InitializeComponent();

            DataContext = new Data {ProductItems = _productService.GetAll()};

            ProductDataGrid.MouseDoubleClick += DataGrid_MouseDoubleClick;
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
            public IList<ProductViewModel> ProductItems { get; set; }
        }
    }
}