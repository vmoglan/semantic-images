using System;
using System.Collections.Generic;
using System.IO;

namespace SemanticImages.Service
{
    interface IFileDialogService
    {
        void ShowFileDialog(string title, string filters, Action<string> action);
    }
}
