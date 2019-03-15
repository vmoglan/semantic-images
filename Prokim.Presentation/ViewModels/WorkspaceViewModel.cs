using System;
using System.Windows.Input;

namespace Prokim.Presentation.ViewModels
{
    /// <summary>
    /// Uses a RequestClose event to close the subscribed view upon launching a close commnand.
    /// </summary>
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        private RelayCommand _closeCommand;

        /// <summary>
        /// Closes the subscribed view when an action is executed upon the target component.
        /// </summary>
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

        /// <summary>
        /// Calls the subscribed view's <code>Close()</code> method when invoked.
        /// </summary>
        public event Action RequestClose;

        /// <summary>
        /// Closes the subscribed view.
        /// </summary>
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
