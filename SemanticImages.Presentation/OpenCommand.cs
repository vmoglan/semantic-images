using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemanticImages.Presentation
{
    class OpenCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Bitmap Image { get; private set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
