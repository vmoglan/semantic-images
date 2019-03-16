using GalaSoft.MvvmLight.Views;

namespace Prokim.Service.Navigation
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
