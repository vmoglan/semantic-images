using SemanticImages.Core;
using SemanticImages.Service.Navigation;
using System;
using System.Drawing;

namespace SemanticImages.Presentation.ViewModels
{
    public class ResizeWindowViewModel : ViewModel
    {
        private readonly Bitmap _imageIn;
        private readonly Action<Bitmap> _onResize;

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

        private ViewModel _activeChildViewModel;

        public ViewModel ActiveChildViewModel
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
            MaintainAspectRatio = true;
            ApplyCommand = new RelayCommand(o => true,
                o =>
                {
                    if (ActiveChildViewModel is ScaleUserControlViewModel)
                    {
                        try
                        {
                            onResize(ImageUtils.Resize(_imageIn, ScaleUserControlViewModel.Scale));

                            IsVisible = false;
                        }

                        catch (Exception e)
                        {
                            messageBoxService.ShowErrorMessageBox(e.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            onResize(ImageUtils.Resize(_imageIn, ResizeUserControlViewModel.Width,
                                ResizeUserControlViewModel.Height));

                            IsVisible = false;
                        } 
                        catch (Exception e)
                        {
                            messageBoxService.ShowErrorMessageBox(e.Message);
                        }
                    }
                });
        }
    }
}
