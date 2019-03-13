using SemanticImages.Service.Navigation;
using System;
using System.Drawing;

namespace SemanticImages.Presentation.ViewModel
{
    public class ResizeWindowViewModel : ViewModel
    {
        private readonly Bitmap _imageIn;
        private readonly Action<Bitmap> _onResize;

        public Bitmap ImageOut
        {
            get; private set;
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

        public RelayCommand ChangeActiveChildViewModel
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
            MaintainAspectRatio = true;
        }
    }
}
