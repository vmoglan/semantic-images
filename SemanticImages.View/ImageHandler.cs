using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SemanticImages.View
{
    /// <summary>
    /// Singleton controller class for an image, object of processing operations within the app; calls image processing
    /// operation and notifies observers.
    /// </summary>
    class ImageHandler : IObservable<Bitmap>
    {
        private static ImageHandler _instance = null;
        private readonly List<IObserver<Bitmap>> _observers;
        private string _activePath;
        private readonly Stack<Bitmap> _history;

        private ImageHandler()
        {
            _observers = new List<IObserver<Bitmap>>();
            _history = new Stack<Bitmap>();
        }

        public static ImageHandler GetInstance()
        {
            if (_instance == null)
                _instance = new ImageHandler();

            return _instance;
        }

        public IDisposable Subscribe(IObserver<Bitmap> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                if (_history.Count > 0)
                    observer.OnNext(_history.Peek());

                else
                    observer.OnNext(null);
            }

            return new Unsubscriber<Bitmap>(_observers, observer);
        }

        /// <summary>
        /// Notifies the observers of a change in the image history.
        /// </summary>
        /// <param name="image">is the instance containing the modified image</param>
        private void NotifyNext()
        {
            foreach (var observer in _observers)
                observer.OnNext(_history.Peek());
        }

        /// <summary>
        /// Notifies the observers of an error having occured during the processing of the
        /// image.
        /// </summary>
        /// <param name="e">is the exception thrown during the processing of an image</param>
        private void NotifyError(Exception e)
        {
            foreach (var observer in _observers)
                observer.OnError(e);
        }
        
        public Bitmap LastModification
        {
            get { return _history.Peek(); }
            private set { }
        }

        /// <summary>
        /// Clears the modification history of the previously loaded image and reads the new image from the given path.
        /// </summary>
        /// <param name="path">is the path of the image to be loaded</param>
        public void Load(string path)
        {
            _history.Clear();

            try
            {
                _history.Push(ImageUtils.BytesToImage(File.ReadAllBytes(path)));
                _activePath = path;
                NotifyNext();
            }
            
            catch (Exception e)
            {
                NotifyError(e);
            }
        }

        /// <summary>
        /// Calls the image resize method on the last modification of the loaded image and notifies observers.
        /// </summary>
        /// <param name="width">is the new width of the image</param>
        /// <param name="height">is the new height of the image</param>
        public void Resize(int width, int height)
        {
            try
            {
                _history.Push(ImageUtils.Resize(_history.Peek(), width, height));
                NotifyNext();
            }

            catch (Exception e)
            {
                NotifyError(e);
            }
        }

        /// <summary>
        /// Scales the last modification of the loaded image and notifies observers.
        /// </summary>
        /// <param name="scale">is the factor by which the image is scaled</param>
        public void Resize(float scale)
        {
            try
            {
                _history.Push(ImageUtils.Resize(_history.Peek(), scale));
                NotifyNext();
            }

            catch (Exception e)
            {
                NotifyError(e);
            }
        }

        /// <summary>
        /// Crops the last modification of the loaded image and notifies observers.
        /// </summary>
        /// <param name="r">is the rectangle used for cropping the image</param>
        public void Crop(Rectangle r)
        {
            try
            {
                _history.Push(ImageUtils.Crop(_history.Peek(), r));
                NotifyNext();
            }

            catch (Exception e)
            {
                NotifyError(e);
            }
        }

        /// <summary>
        /// Reverts the last modification performed on the loaded image.
        /// </summary>
        public void Undo()
        {
            if (_history.Count > 1)
            {
                _history.Pop();
            }

            NotifyNext();
        }

        /// <summary>
        /// Reverts all modifications performed on the loaded image.
        /// </summary>
        public void UndoAll()
        {
            while (_history.Count > 1)
            {
                _history.Pop();
            }

            NotifyNext();
        }

        /// <summary>
        /// Saves the last modification to the active path in the original format given by that path.
        /// </summary>
        public void Save()
        {
            try
            {
                ImageFormat format = ImageUtils.GetImageFormat(_activePath);

                _history.Peek().Save(_activePath, format);
                NotifyNext();
            }

            catch (Exception e)
            {
                NotifyError(e);
            }
        }

        /// <summary>
        /// Saves the last modification to a path using the format of that path.
        /// </summary>
        /// <param name="path">is the path to output the last modification to</param>
        public void SaveAs(string path)
        {
            try
            {
                ImageFormat format = ImageUtils.GetImageFormat(path);

                _history.Peek().Save(path, format);
                _activePath = path;
                NotifyNext();
            }

            catch (Exception e)
            {
                NotifyError(e);
            }
        }
    }
}
