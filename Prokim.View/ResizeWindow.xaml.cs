using Prokim.Presentation.ViewModels;
using System.Windows;

namespace Prokim.View
{
    /// <summary>
    /// Interaction logic for ResizeWindow.xaml
    /// </summary>
    public partial class ResizeWindow : Window
    {
        public ResizeWindow(ResizeWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.RequestClose += () => { Close(); };
        }
    }
}
