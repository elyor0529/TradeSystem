using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Trade.ClientUI.Controls;
using Trade.Services;
using Trade.ViewModels.DAL;

namespace Trade.ClientUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly FolderService _folderService = new FolderService();
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly ProductService _productService = new ProductService();
        private readonly OrderService _orderService = new OrderService();
        private readonly LoginControl _login = new LoginControl();
        private readonly Timer _timer = new Timer
        {
            AutoReset = true,
            Enabled = true,
            Interval = 1000
        };
        private int _counter;
        private static bool _isLogging;

        public MainWindow()
        {
            InitializeComponent();

            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();

            _login.ButtonLoginClick += Login_ButtonLoginClick;
        }

        private void LoadFolders()
        {
            FolderListBox.ItemsSource = _folderService.GetAll();
            FolderListBox.DisplayMemberPath = "Name";
            FolderListBox.SelectedValuePath = "Id";
        }

        private void LoadCategories(int? folderId)
        {
            CategoryListBox.ItemsSource = _categoryService.GetAll(a => a.FolderId == folderId);
            CategoryListBox.DisplayMemberPath = "Name";
            CategoryListBox.SelectedValuePath = "Id";
        }

        private void LoadProducts(int? categoryId)
        {
            ProductListBox.ItemsSource = _productService.GetAll(a => a.CategoryId == categoryId);
            ProductListBox.DisplayMemberPath = "Name";
            ProductListBox.SelectedValuePath = "Id";
        }

        private void LoadOrders()
        {
            OrderGrid.ItemsSource = _orderService.GetAll(a => a.EmployeeId == _login.SelectedEmpoyee.Id);
        }

        private void Login_ButtonLoginClick(object sender, RoutedEventArgs e)
        {
            if (_login.SelectedEmpoyee == null)
            {
                MessageBox.Show("Plesae select client!", "Select", MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }

            var employee = _employeeService.Get(emp => emp.Code == _login.CodeBox.Password);

            if (employee != null)
            {
                RootDialogHost.Visibility = Visibility.Visible;
                UserName.Content = employee.ToString();
                _isLogging = true;
            }
            else
            {
                _isLogging = false;
                _login.CodeBox.Clear();
                _login.SelectedEmpoyee = null;

                MessageBox.Show("Your code was incorrect, please try again!", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_counter == 0 && _isLogging == false)
            {
                await Dispatcher.InvokeAsync(async () =>
                {
                    RootDialogHost.Visibility = Visibility.Hidden;

                    await DialogHost.Show(_login, "RootDialog1");
                });
            }
            else
            {
                _counter++;

                if (_isLogging && _counter == 5 * 1000 * 60)
                {
                    _isLogging = false;
                    _counter = 0;
                }
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            _isLogging = false;
            _counter = 0;
        }

        private void Testindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFolders();
        }

        private void FolderListBox_MouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (FolderListBox.SelectedItem == null)
                return;

            LoadCategories((int?)FolderListBox.SelectedValue);

            CategoryExpander.IsExpanded = true;
        }

        private void CategoryListBox_MouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (CategoryListBox.SelectedItem == null)
                return;

            LoadProducts((int?)CategoryListBox.SelectedValue);

            ProductExpander.IsExpanded = true;
        }

        private void ProductListBox_MouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (ProductListBox.SelectedItem == null)
                return;

            LoadOrders();

            OrderExpander.IsExpanded = true;
        }

        private void FolderReload_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadFolders();
        }

        private void OrderCloseIcon_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderExpander.IsExpanded = false;
            OrderGrid.ItemsSource = null;
        }

        private void ProductCloseIcon_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductExpander.IsExpanded = false;
            ProductListBox.ItemsSource = null;
        }

        private void CategoryCloseIcon_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CategoryExpander.IsExpanded = false;
            CategoryListBox.ItemsSource = null;
        }

        private void FolderCloseIcon_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FolderExpander.IsExpanded = false;
            FolderListBox.ItemsSource = null;
        }
    }
}
