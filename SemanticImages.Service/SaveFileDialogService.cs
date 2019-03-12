using Microsoft.Win32;

namespace SemanticImages.Service
{
    public class SaveFileDialogService : IFileDialogService
    {
        public string ShowFileDialog(string title, string filter)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Title = title,
                Filter = filter
            };

            return fileDialog.ShowDialog() == true ? fileDialog.FileName : null;
        }
    }
}
