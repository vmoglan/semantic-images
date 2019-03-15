using Prokim.Core;
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
        private readonly IResizeWindowService _resizeWindowService;

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

        public MainWindowViewModel(IResizeWindowService resizeWindowService, IFileDialogService fileDialogService, IMessageBoxService messageBoxService)
        {
            _history = new Stack<Bitmap>();
            _fileDialogService = fileDialogService;
            _messageBoxService = messageBoxService;
            _resizeWindowService = resizeWindowService;
            
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            OpenCommand = new RelayCommand(o => true, o => OnOpenCommandExecution(o));
            SaveCommand = new RelayCommand(o => _history.Count > 0, o => OnSaveCommandExecution(o));
            SaveAsCommand = new RelayCommand(o => _history.Count > 0, o => OnSaveAsCommandExecution(o));
            ResizeCommand = new RelayCommand(o => _history.Count > 0, o => OnResizeCommandExecution(o));
        }

        private void OnOpenCommandExecution(object o)
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

        private void OnSaveCommandExecution(object o)
        {
            _messageBoxService.ShowWarningMessageBox("This operation will override the currently loaded file.", "Save",
                r =>
                {
                    if (r) LastModification.Save(_imageExportPath);
                });
        }

        private void OnSaveAsCommandExecution(object o)
        {
            _fileDialogService.ShowSaveFileDialog("Save", "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                path =>
                {
                    ImageWriter writer = new ImageWriter(path);

                    writer.Write(LastModification);

                    _imageExportPath = path;
                });
        }

        private void OnResizeCommandExecution(object o)
        {
            _resizeWindowService.ShowResizeWindow(
                _messageBoxService,
                LastModification,
                im =>
                {
                    _history.Push(im);
                    RaisePropertyChanged(nameof(LastModification));
                }
            );
        }
    }
}
