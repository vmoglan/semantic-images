using System;
using System.Windows.Input;

namespace SemanticImages.Presentation.ViewModels
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        private RelayCommand _closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(param => CanClose(), param => Close());
                }

                return _closeCommand;
            }
        }

        public event Action RequestClose;

        public virtual void Close()
        {
            RequestClose?.Invoke();
        }

        public virtual bool CanClose()
        {
            return true;
        }
    }
}
