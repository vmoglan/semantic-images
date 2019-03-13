using System;
using System.Drawing;

namespace SemanticImages.Service.Navigation
{
    public interface IResizeWindowService
    {
        void ShowResizeWindow(IMessageBoxService messageBoxService, Bitmap imageIn, Action<Bitmap> onResize);
    }
}
