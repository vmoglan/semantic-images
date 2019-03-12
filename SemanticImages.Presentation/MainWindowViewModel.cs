using SemanticImages.Core;
using SemanticImages.Core.IO;
using SemanticImages.Service;
using System;
using System.Drawing;

namespace SemanticImages.Presentation
{
    public class MainWindowViewModel : ViewModel
    {
        private ImageModificationManager _imageModificationManager;

        public ImageModificationManager ImageModificationManager
        {
            get => _imageModificationManager;
            private set
            {
                _imageModificationManager = value;
                RaisePropertyChanged();
            }
        }

        private string _imageExportPath;

        private readonly OpenFileDialogService _openImageDialogService;
        private readonly SaveFileDialogService _saveImageDialogService;
        private readonly IMessageBoxService _messageBoxService;

        public RelayCommand OpenCommand
        {
            get; private set;
        }

        public RelayCommand SaveCommand
        {
            get; private set;
        }

        public RelayCommand SaveAsCommand
        {
            get; private set;
        }

        public MainWindowViewModel() { }

        public MainWindowViewModel(OpenFileDialogService openImageDialogService, 
            SaveFileDialogService saveImageDialogService, IMessageBoxService messageBoxService)
        {
            _openImageDialogService = openImageDialogService;
            _saveImageDialogService = saveImageDialogService;
            _messageBoxService = messageBoxService;
            
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            OpenCommand = new RelayCommand(o => true, o => OnOpenCommandExecution(o));
            SaveCommand = new RelayCommand(o => (ImageModificationManager != null), o => OnSaveCommandExecution(o));
            SaveAsCommand = new RelayCommand(o => true, o => OnSaveAsCommandExecution(o));
        }

        private void OnOpenCommandExecution(object o)
        {
            _openImageDialogService.ShowFileDialog("Open", "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                path =>
                {
                    ImageReader reader = new ImageReader(path);

                    reader.Read();

                    _imageExportPath = path;
                    Bitmap image = reader.Image;
                    ImageModificationManager = new ImageModificationManager(image);

                    RaisePropertyChanged(nameof(ImageModificationManager));
                });
        }

        private void OnSaveCommandExecution(object o)
        {
            _messageBoxService.ShowMessageBox("This operation will override the currently loaded file.",
                "Save", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning,
                r =>
                {
                    if (r == System.Windows.MessageBoxResult.OK)
                        ImageModificationManager.LastModification.Save(_imageExportPath);
                });
        }

        private void OnSaveAsCommandExecution(object o)
        {
            _saveImageDialogService.ShowFileDialog("Save", "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                path =>
                {
                    ImageWriter writer = new ImageWriter(path);

                    writer.Write(ImageModificationManager.LastModification);

                    _imageExportPath = path;
                });
        }
    }
}
