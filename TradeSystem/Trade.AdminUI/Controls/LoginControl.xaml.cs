using System.Windows;
using System.Windows.Controls;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        public LoginControl()
        {
            InitializeComponent();
        }

        // Event declaration
        public event EventHandler ButtonLoginClick;

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if event is null  
            if (ButtonLoginClick != null)
            {
                ButtonLoginClick(sender, e);
            }
        }
    }
}