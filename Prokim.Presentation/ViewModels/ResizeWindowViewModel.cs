using Prokim.Core;
using Prokim.Service.Navigation;
using System;
using System.Drawing;

namespace Prokim.Presentation.ViewModels
{
    /// <summary>
    /// View model allowing for view switching support by keeping a reference to the child
    /// view model active at a given moment.
    /// </summary>
    public class ResizeWindowViewModel : WorkspaceViewModel
    {
        private readonly Bitmap _imageIn;
        private readonly Action<Bitmap> _onResize;
        private readonly IMessageBoxService _messageBoxService;

        private ViewModelBase _activeChildViewModel;

        /// <summary>
        /// Child view model active at a given time, determining the view to be displayed.
        /// </summary>
        public ViewModelBase ActiveChildViewModel
        {
            get => _activeChildViewModel;
            private set
            {
                _activeChildViewModel = value;
                RaisePropertyChanged(nameof(ActiveChildViewModel));
            }
        }

        private ResizeUserControlViewModel _resizeUserControlViewModel;
        
        public ResizeUserControlViewModel ResizeUserControlViewModel
        {
            get
            {
                if (_resizeUserControlViewModel == null)
                {
                    _resizeUserControlViewModel = new ResizeUserControlViewModel();
                }

                return _resizeUserControlViewModel;
            }

            set { }
        }

        private ScaleUserControlViewModel _scaleUserControlViewModel;

        public ScaleUserControlViewModel ScaleUserControlViewModel
        {
            get
            {
                if (_scaleUserControlViewModel == null)
                {
                    _scaleUserControlViewModel = new ScaleUserControlViewModel();
                }

                return _scaleUserControlViewModel;
            }

            set { }
        }

        public RelayCommand ApplyCommand
        {
            get; private set;
        }

        private bool _maintainAspectRatio;

        public bool MaintainAspectRatio
        {
            get => _maintainAspectRatio;
            set
            {
                _maintainAspectRatio = value;

                if (value)
                {
                    ActiveChildViewModel = ScaleUserControlViewModel;
                }
                else
                {
                    ActiveChildViewModel = ResizeUserControlViewModel;
                }

                RaisePropertyChanged(nameof(MaintainAspectRatio));
            }
        }

        public ResizeWindowViewModel() { }

        public ResizeWindowViewModel(IMessageBoxService messageBoxService, Bitmap imageIn, Action<Bitmap> onResize)
        {
            _imageIn = imageIn;
            _onResize = onResize;
            _messageBoxService = messageBoxService;
            MaintainAspectRatio = true;
            ApplyCommand = new RelayCommand(o => CanClose(), o => OnApplyCommandExecution());
        }

        /// <summary>
        /// Applies the resize operation on the input image and closes the window or shows an error dialog if
        /// an exception is raised.
        /// </summary>
        private void OnApplyCommandExecution()
        {
            if (ActiveChildViewModel is ScaleUserControlViewModel)
            {
                try
                {
                    _onResize(ImageUtils.Resize(_imageIn, ScaleUserControlViewModel.Scale));
                    Close();
                }

                catch (Exception e)
                {
                    _messageBoxService.ShowErrorMessageBox(e.Message);
                }
            }
            else
            {
                try
                {
                    _onResize(ImageUtils.Resize(_imageIn, ResizeUserControlViewModel.Width,
                        ResizeUserControlViewModel.Height));
                    Close();
                }
                catch (Exception e)
                {
                    _messageBoxService.ShowErrorMessageBox(e.Message);
                }
            }
        }
    }
}
