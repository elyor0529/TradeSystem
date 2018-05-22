using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for ProductFormControl.xaml
    /// </summary>
    public partial class ProductFormControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductFormControl()
        {
            _productService = DiConfig.Resolve<IProductService>();
            _categoryService = DiConfig.Resolve<ICategoryService>();

            InitializeComponent();

            ComboBoxCategory.ItemsSource = _categoryService.GetAll();
            ComboBoxCategory.DisplayMemberPath = "Name";
            ComboBoxCategory.SelectedValuePath = "Id";
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
            if (string.IsNullOrEmpty(ComboBoxCategory.SelectedValue.ToString()))
                return;

            var product = new ProductViewModel
            {
                Id = string.IsNullOrEmpty(TextBoxId.Text.Trim()) ? 0 : int.Parse(TextBoxId.Text.Trim()),
                Name = TextBoxName.Text,
                CategoryId = int.Parse(ComboBoxCategory.SelectedValue.ToString())
            };
            var result = _productService.CreateOrUpdate(product);
            Console.WriteLine("_productService.CreateOrUpdate({0})={1}", product, result);
            formClear();
        }

        private void formDelete()
        {
            if (string.IsNullOrEmpty(TextBoxId.Text.Trim()))
                return;

            var Id = int.Parse(TextBoxId.Text.Trim());
            var result = _productService.Delete(Id);
            Console.WriteLine("_productService.Delete({0})={1}", Id, result);
            formClear();
        }

        private void formClear()
        {
            TextBoxId.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            ComboBoxCategory.SelectedIndex = -1;
        }
    }
}