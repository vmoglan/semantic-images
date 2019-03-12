using SemanticImages.Core;
using SemanticImages.Presentation;
using SemanticImages.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SemanticImages.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private static void ComposeObjects()
        {
            OpenImageDialogService openImageDialogService = new OpenImageDialogService();
            SaveImageDialogService saveImageDialogService = new SaveImageDialogService();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(openImageDialogService, saveImageDialogService);
            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            Current.MainWindow = mainWindow;
        }
    }
}
