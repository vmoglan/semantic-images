using System;
using System.Windows;

namespace SemanticImages.Service
{
    public interface IMessageBoxService
    {
        void ShowMessageBox(string message, string title, MessageBoxButton messageBoxButton,
            MessageBoxImage messageBoxImage, Action<MessageBoxResult> action = null);
    }
}
