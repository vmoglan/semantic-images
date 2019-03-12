using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticImages.Service
{
    public class SaveImageDialogService : IFileDialogService
    {
        public string RetrievePath()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
            };

            return fileDialog.ShowDialog() == false ? null : fileDialog.FileName;
        }
    }
}
