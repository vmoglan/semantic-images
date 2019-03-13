using SemanticImages.Service.Navigation;
using System;
using System.Windows;

namespace SemanticImages.View.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowErrorMessageBox(string message, string title = "Error")
        {
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxButton button = MessageBoxButton.OK;

            MessageBox.Show(message, title, button, icon);
        }

        public void ShowInformationMessageBox(string message, string title = "Info")
        {
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = MessageBoxButton.OK;

            MessageBox.Show(message, title, button, icon);
        }

        public void ShowQuestionMessageBox(string message, string title, Action<bool> action)
        {
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = MessageBoxButton.YesNo;

            action.Invoke(MessageBox.Show(message, title, button, icon) == MessageBoxResult.Yes ? true : false);
        }

        public void ShowWarningMessageBox(string message, string title = "Warning", Action<bool> action = null)
        {
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = (action == null) ? MessageBoxButton.OK : MessageBoxButton.OKCancel;

            action?.Invoke(MessageBox.Show(message, title, button, icon) == MessageBoxResult.OK ? true : false);
        }
    }
}
