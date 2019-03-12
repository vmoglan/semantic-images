using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticImages.Service
{
    public class OpenFileDialogService : IFileDialogService
    {
        public void ShowFileDialog(string title, string filter, Action<string> action)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter
            };

            bool? dialogResult = fileDialog.ShowDialog();

            if (dialogResult.HasValue)
            {
                action(fileDialog.FileName);
            }
        }
    }
}
