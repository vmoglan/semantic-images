using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SemanticImages.View
{
    public partial class MainForm : Form, IObserver<Bitmap>
    {
        private ImageHandler _imageHandler;
        private IDisposable _unsubscriber;

        public MainForm()
        {
            InitializeComponent();

            _imageHandler = ImageHandler.GetInstance();
            _unsubscriber = _imageHandler.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void OnNext(Bitmap value)
        {
            if (value == null)
            {
                ResizeToolStripMenuItem.Enabled = false;
                CropToolStripMenuItem.Enabled = false;
                UndoToolStripMenuItem.Enabled = false;
                UndoAllToolStripMenuItem.Enabled = false;
                SaveToolStripMenuItem.Enabled = false;
                SaveAsToolStripMenuItem.Enabled = false;
            }

            else
            {
                ResizeToolStripMenuItem.Enabled = true;
                CropToolStripMenuItem.Enabled = true;
                UndoToolStripMenuItem.Enabled = true;
                UndoAllToolStripMenuItem.Enabled = true;
                SaveToolStripMenuItem.Enabled = true;
                SaveAsToolStripMenuItem.Enabled = true;
            }

            MainPictureBox.Image = value;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog {
                Title = "Load Image",
                InitialDirectory = ".",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fd.ShowDialog() == DialogResult.OK)
                _imageHandler.Load(fd.FileName);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageHandler.Save();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
            };

            if (sd.ShowDialog() == DialogResult.OK)
            {
                _imageHandler.SaveAs(sd.FileName);
            }
        }

        private void ResizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ImageResizeForm(this);

            form.Show();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageHandler.Undo();
        }

        private void UndoAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Undo all changes? This operation is irreversible.", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                _imageHandler.UndoAll();
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ImageCropForm(this, (Bitmap) MainPictureBox.Image.Clone());

            form.Show();
        }
    }
}
