using System;
using System.Windows;

namespace SemanticImages.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        void IMessageBoxService.ShowMessageBox(string message, string title, 
            MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage, 
            Action<MessageBoxResult> action)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(message, title, messageBoxButton,
                messageBoxImage);

            action?.Invoke(messageBoxResult);
        }
    }
}
