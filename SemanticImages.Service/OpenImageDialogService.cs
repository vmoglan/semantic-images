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
    public class OpenImageDialogService : IFileDialogService
    {
        public string RetrievePath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Load Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            bool? result = fileDialog.ShowDialog();

            return result == null || result == false ? null : fileDialog.FileName;
        }
    }
}
