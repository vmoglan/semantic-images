using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemanticImages.Presentation
{
    class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private string _path;

        public bool CanExecute(object path)
        {
            if (!(path is string))
            {
                _path = null;

                return false;
            }

            _path = (string)path;

            return true;
        }

        public void Execute(object assumedImage)
        {
            if (assumedImage is Image image)
            {
                image.Save(_path);
            }
        }
    }
}
