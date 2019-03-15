namespace Prokim.Presentation.ViewModels
{
    public class ScaleUserControlViewModel : ViewModelBase
    {
        private float _scale;

        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;

                RaisePropertyChanged(nameof(Scale));
            }
        }

        public ScaleUserControlViewModel()
        {
            Scale = 1.0f;
        }
    }
}
