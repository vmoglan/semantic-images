using System;
using System.Drawing;

namespace Prokim.Service.Navigation
{
    public interface IResizeWindowService
    {
        void ShowResizeWindow(IMessageBoxService messageBoxService, Bitmap imageIn, Action<Bitmap> onResize);
    }
}
