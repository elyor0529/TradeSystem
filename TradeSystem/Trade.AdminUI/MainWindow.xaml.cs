using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignColors.WpfExample.Domain;
using MaterialDesignThemes.Wpf;
using Trade.AdminUI.Controls;
using Trade.Services;

namespace Trade.AdminUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ManagerService _managerService = new ManagerService();
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

        private void Login_ButtonLoginClick(object sender, RoutedEventArgs e)
        {
            var manager = _managerService.Get(mng => mng.Login == _login.UsernameTextBox.Text && mng.Password == _login.PasswordBox.Password);

            if (manager != null)
            {
                RootDialogHost.Visibility = Visibility.Visible;
                _isLogging = true; 
            }
            else
            { 
                _isLogging = false;

                MessageBox.Show("Your username  or password was incorrect, please try again!", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Warning);
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


        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new SampleMessageDialog
            {
                Message = { Text = ((ButtonBase)sender).Content.ToString() }
            };

            await DialogHost.Show(sampleMessageDialog, "RootDialog1");
        }


    }
}
