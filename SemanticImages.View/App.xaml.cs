using SemanticImages.Presentation.ViewModels;
using SemanticImages.Service.Navigation;
using SemanticImages.View.Service;
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
            IFileDialogService fileDialogService = new FileDialogService();
            IMessageBoxService messageBoxService = new MessageBoxService();
            IResizeWindowService resizeWindowService = new ResizeWindowService();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(resizeWindowService, fileDialogService, messageBoxService);
            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            Current.MainWindow = mainWindow;
        }
    }
}
