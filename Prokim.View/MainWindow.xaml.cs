using Prokim.Presentation.ViewModels;
using System.Windows;

namespace Prokim.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            
            DataContext = viewModel;
        }
    }
}
