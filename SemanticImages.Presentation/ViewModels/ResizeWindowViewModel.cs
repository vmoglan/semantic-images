using SemanticImages.Core;
using SemanticImages.Service.Navigation;
using System;
using System.Drawing;

namespace SemanticImages.Presentation.ViewModels
{
    public class ResizeWindowViewModel : WorkspaceViewModel
    {
        private readonly Bitmap _imageIn;
        private readonly Action<Bitmap> _onResize;
        private readonly IMessageBoxService _messageBoxService;

        public Bitmap ImageOut
        {
            get; private set;
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;

                RaisePropertyChanged(nameof(IsVisible));
            }
        }

        private ViewModelBase _activeChildViewModel;

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
            IsVisible = true;
            _imageIn = imageIn;
            _onResize = onResize;
            _messageBoxService = messageBoxService;
            MaintainAspectRatio = true;
            ApplyCommand = new RelayCommand(o => CanClose(),
                o =>
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
                });
        }
    }
}
