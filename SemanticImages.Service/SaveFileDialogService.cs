using Microsoft.Win32;
using System;

namespace SemanticImages.Service
{
    public class SaveFileDialogService : IFileDialogService
    {
        public void ShowFileDialog(string title, string filter, Action<string> action)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Title = title,
                Filter = filter
            };

            bool? dialogResult = fileDialog.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value)
            {
                action(fileDialog.FileName);
            }
        }
    }
}
