using GalaSoft.MvvmLight.Threading;
using Prokim.Presentation.ViewModels;
using Prokim.Service.Navigation;
using Prokim.View.Navigation;
using System.Windows;

namespace Prokim.View
{
    /// <summary>
    /// Bootstrapper
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
