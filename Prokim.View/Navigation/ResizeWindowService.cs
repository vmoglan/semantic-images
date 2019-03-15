using Prokim.Presentation.ViewModels;
using Prokim.Service.Navigation;
using System;
using System.Drawing;

namespace Prokim.View.Service
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
