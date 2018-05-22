using System;
using System.Windows;
using System.Windows.Controls;
using Trade.Core;
using Trade.Services.Interface;
using Trade.ViewModels.DAL;

namespace Trade.AdminUI.Controls
{
    /// <summary>
    ///     Interaction logic for ClientTypeFormControl.xaml
    /// </summary>
    public partial class ClientTypeFormControl : UserControl
    {
        // Delegate declaration
        public delegate void EventHandler(object sender, RoutedEventArgs e);

        private readonly IClientTypeService _clientTypeService;

        public ClientTypeFormControl()
        {
            _clientTypeService = DiConfig.Resolve<IClientTypeService>();

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

            var clientType = new ClientTypeViewModel
            {
                Id = string.IsNullOrEmpty(TextBoxId.Text.Trim()) ? 0 : int.Parse(TextBoxId.Text.Trim()),
                Name = TextBoxName.Text
            };
            var result = _clientTypeService.CreateOrUpdate(clientType);
            Console.WriteLine("_clientTypeService.CreateOrUpdate({0})={1}", clientType, result);
            formClear();
        }

        private void formDelete()
        {
            if (string.IsNullOrEmpty(TextBoxId.Text.Trim()))
                return;

            var Id = int.Parse(TextBoxId.Text.Trim());
            var result = _clientTypeService.Delete(Id);
            Console.WriteLine("_clientTypeService.Delete({0})={1}", Id, result);
            formClear();
        }

        private void formClear()
        {
            TextBoxId.Text = string.Empty;
            TextBoxName.Text = string.Empty;
        }
    }
}