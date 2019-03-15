using System;
using System.Collections.Generic;
using System.IO;

namespace Prokim.Service.Navigation
{
    public interface IFileDialogService
    {
        void ShowOpenFileDialog(string title, string filters, Action<string> action);

        void ShowSaveFileDialog(string title, string filters, Action<string> action);
    }
}
