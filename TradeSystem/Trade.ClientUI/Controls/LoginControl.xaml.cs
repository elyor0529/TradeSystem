using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Trade.Services;
using Trade.ViewModels.DAL;

namespace Trade.ClientUI.Controls
{
    /// <summary>
    ///     Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly EmployeeService _employeeService = new EmployeeService();

        public LoginControl()
        {
            InitializeComponent();
        }

        public EmployeeViewModel SelectedEmpoyee { get; set; }

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

        private void LoginControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            var employees = _employeeService.GetAll();
            var style = Application.Current.FindResource("MaterialDesignRaisedButton") as Style;

            if (EmployeeStackPanel.Children.Count > 0)
                EmployeeStackPanel.Children.Clear();

            foreach (var employee in employees)
            {
                var btn = new Button
                {
                    Margin = new Thickness(5),
                    Width = 200,
                    ToolTip = employee.ToString(),
                    Style = style,
                    Content = employee.ToString(),
                    Tag = employee
                };
                btn.Click += BtnOnClick;
                EmployeeStackPanel.Children.Add(btn);
            }
        }

        private void BtnOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var buttons = EmployeeStackPanel.Children.Cast<Button>();
            var style = Application.Current.FindResource("MaterialDesignRaisedButton") as Style;

            foreach (var button in buttons)
            {
                button.Style = style;
            }

            var btn = (Button)sender;

            btn.Style = Application.Current.FindResource("MaterialDesignRaisedAccentButton") as Style;

            SelectedEmpoyee = (EmployeeViewModel)btn.Tag;
        }
    }
}