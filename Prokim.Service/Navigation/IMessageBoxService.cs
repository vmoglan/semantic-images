using System;
using System.Windows;

namespace Prokim.Service.Navigation
{
    public interface IMessageBoxService
    {
        void ShowInformationMessageBox(string message, string title = "Info");

        void ShowWarningMessageBox(string message, string title = "Warning", Action<bool> action = null);

        void ShowErrorMessageBox(string message, string title = "Error");

        void ShowQuestionMessageBox(string message, string title, Action<bool> action);
    }

}
