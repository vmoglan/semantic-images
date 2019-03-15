using Prokim.Presentation.ViewModels;
using Prokim.Service.Navigation;
using Prokim.View.Service;
using System.Windows;

namespace Prokim.View
{
    /// <summary>
    /// Bootstrapper
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
            IFileDialogService fileDialogService = new FileDialogService();
            IMessageBoxService messageBoxService = new MessageBoxService();
            IResizeWindowService resizeWindowService = new ResizeWindowService();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(resizeWindowService, fileDialogService, messageBoxService);
            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            Current.MainWindow = mainWindow;
        }
    }
}
