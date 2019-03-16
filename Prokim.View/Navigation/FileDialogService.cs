﻿using Microsoft.Win32;
using System;
using Prokim.Service.Navigation;

namespace Prokim.View.Navigation
{
    public class FileDialogService : IFileDialogService
    {
        public void ShowOpenFileDialog(string title, string filter, Action<string> action)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
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

        public void ShowSaveFileDialog(string title, string filter, Action<string> action)
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
