namespace SemanticImages.Presentation.ViewModels
{
    public class ResizeUserControlViewModel : ViewModel
    {
        private int _width;

        public int Width
        {
            get => _width;
            set
            {
                _width = value;

                RaisePropertyChanged(nameof(Width));
            }
        }

        private int _height;

        public int Height
        {
            get => _height;
            set
            {
                _height = value;

                RaisePropertyChanged(nameof(Height));
            }
        }

        public ResizeUserControlViewModel()
        {
            Width = 200;
            Height = 100;
        }
    }
}
