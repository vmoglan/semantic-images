using SemanticImages.Presentation.ViewModels;
using SemanticImages.Service.Navigation;
using System;
using System.Drawing;

namespace SemanticImages.View.Service
{
    public class ResizeWindowService : IResizeWindowService
    {
        public void ShowResizeWindow(IMessageBoxService messageBoxService, Bitmap imageIn, Action<Bitmap> onResize)
        {
            ResizeWindowViewModel viewModel = new ResizeWindowViewModel(messageBoxService, imageIn, onResize);
            ResizeWindow window = new ResizeWindow(viewModel);

            window.ShowDialog();
        }
    }
}
