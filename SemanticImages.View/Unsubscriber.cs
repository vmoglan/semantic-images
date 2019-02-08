using System;
using System.Collections.Generic;

namespace SemanticImages.View
{
    /// <summary>
    /// Allows an Bitmap observer to unsubscribe from an observable.
    /// </summary>
    /// <typeparam name="Bitmap">defines the type of unsubscriber</typeparam>
    class Unsubscriber<Bitmap> : IDisposable
    {
        private readonly List<IObserver<Bitmap>> _observers;
        private readonly IObserver<Bitmap> _observer;

        public Unsubscriber(List<IObserver<Bitmap>> observers, IObserver<Bitmap> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
