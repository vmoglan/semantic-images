using SemanticImages.View;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SemanticBitmaps.View
{
    class ImageHandler : IObservable<Bitmap>
    {
        private readonly List<IObserver<Bitmap>> _observers;
        private readonly Stack<Bitmap> _imageHistory;

        private ImageHandler()
        {
            _observers = new List<IObserver<Bitmap>>();
            _imageHistory = new Stack<Bitmap>();
        }

        public IDisposable Subscribe(IObserver<Bitmap> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                observer.OnNext(_imageHistory.Peek());
            }

            return new Unsubscriber<Bitmap>(_observers, observer);
        }
    }
}
