using System.ComponentModel;

/// <summary>
/// A base class for any view model. Raises property change events.
/// </summary>
namespace SemanticImages.Presentation.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}