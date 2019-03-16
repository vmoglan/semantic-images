/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Prokim.View"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Prokim.Presentation.ViewModels;
using Prokim.Service.Navigation;
using Prokim.View.Navigation;

namespace Prokim.View
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IFileDialogService, FileDialogService>();
                SimpleIoc.Default.Register<IMessageBoxService, MessageBoxService>();
            }

            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainWindowViewModel>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}