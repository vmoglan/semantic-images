using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace SemanticImages.Core
{
    public class ImageModificationManager :
        INotifyPropertyChanged
    {
        private Stack<Bitmap> _history;

        public event PropertyChangedEventHandler PropertyChanged;

        public Bitmap LastModification
        {
            get => _history.Peek();
            private set { }
        }

        public ImageModificationManager(Bitmap sourceImage)
        {
            _history = new Stack<Bitmap>();

            _history.Push(sourceImage);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastModification)));
        }

        public void Resize(int width, int height)
        {
            _history.Push(ImageUtils.Resize(LastModification, width, height));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastModification)));
        }

        public void Resize(float scale)
        {
            _history.Push(ImageUtils.Resize(LastModification, scale));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastModification)));
        }

        public void Crop(Rectangle r)
        {
            _history.Push(ImageUtils.Crop(LastModification, r));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastModification)));
        }

        public void Undo()
        {
            _history.Pop();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastModification)));
        }

        public void UndoAll()
        {
            while (_history.Count > 1)
            {
                _history.Pop();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastModification)));
        }
    }
}
