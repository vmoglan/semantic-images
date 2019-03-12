using SemanticImages.Core;
using SemanticImages.Core.IO;
using SemanticImages.Service;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace SemanticImages.Presentation
{
    public class MainWindowViewModel : ViewModel
    {
        public ImageModificationManager ImageModificationManager
        {
            get => _imageModificationManager;
            private set
            {
                _imageModificationManager = value;
                RaisePropertyChanged();
            }
        }

        private readonly OpenImageDialogService _openImageDialogService;
        private readonly SaveImageDialogService _saveImageDialogService;
        private ImageModificationManager _imageModificationManager;
        
        public RelayCommand OpenCommand
        {
            get; private set;
        }

        public RelayCommand SaveCommand
        {
            get; private set;
        }

        public MainWindowViewModel()
        {

        }

        public MainWindowViewModel(OpenImageDialogService openImageDialogService, SaveImageDialogService saveImageDialogService)
        {
            _openImageDialogService = openImageDialogService;
            _saveImageDialogService = saveImageDialogService;
            OpenCommand = new RelayCommand(
                o => true,
                o =>
                {
                    string path = _openImageDialogService.RetrievePath();

                    if (path != null)
                    {
                        ImageReader reader = new ImageReader(path);

                        reader.Read();

                        Bitmap image = reader.Image;
                        ImageModificationManager = new ImageModificationManager(image);
                        RaisePropertyChanged(nameof(ImageModificationManager));
                    }
                }
            );
        }
    }
}
