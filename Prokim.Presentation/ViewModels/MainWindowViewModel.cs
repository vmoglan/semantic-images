using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Prokim.Core.IO;
using Prokim.Service.Navigation;
using System.Collections.Generic;
using System.Drawing;

namespace Prokim.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Stack<Bitmap> _history;

        public Bitmap LastModification
        {
            get => _history.Count > 0 ? _history.Peek() : null;
            private set { }
        }

        private string _imageExportPath;

        private readonly IFileDialogService _fileDialogService;
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

        public RelayCommand ResizeCommand
        {
            get; private set;
        }

        public MainWindowViewModel() { }

        public MainWindowViewModel(IFileDialogService fileDialogService, IMessageBoxService messageBoxService)
        {
            _history = new Stack<Bitmap>();
            _fileDialogService = fileDialogService;
            _messageBoxService = messageBoxService;
            
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            OpenCommand = new RelayCommand(() => OnOpenCommandExecution(), true);
            SaveCommand = new RelayCommand(() => OnSaveCommandExecution(), 
                () => _history.Count > 0, true);
            SaveAsCommand = new RelayCommand(() => OnSaveAsCommandExecution(), 
                () => _history.Count > 0, true);
        }

        private void OnOpenCommandExecution()
        {
            _fileDialogService.ShowOpenFileDialog("Open", "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                path =>
                {
                    ImageReader reader = new ImageReader(path);

                    reader.Read();

                    _imageExportPath = path;
                    Bitmap image = reader.Image;

                    _history.Clear();
                    _history.Push(image);

                    RaisePropertyChanged(nameof(LastModification));
                });
        }

        private void OnSaveCommandExecution()
        {
            _messageBoxService.ShowWarningMessageBox("This operation will override the currently loaded file.", "Save",
                r =>
                {
                    if (r) LastModification.Save(_imageExportPath);
                });
        }

        private void OnSaveAsCommandExecution()
        {
            _fileDialogService.ShowSaveFileDialog("Save", "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                path =>
                {
                    ImageWriter writer = new ImageWriter(path);

                    writer.Write(LastModification);

                    _imageExportPath = path;
                });
        }
    }
}
