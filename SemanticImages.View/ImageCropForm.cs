using System;
using System.Drawing;
using System.Windows.Forms;

namespace SemanticImages.View
{
    public partial class ImageCropForm : Form
    {
        private readonly ImageHandler _imageHandler;
        private double _resizeFactor;   // the factor that determines how much the image has been scaled to fit the picture box
        private Rectangle _cropAreaBounds;  // stores the bounds of the image relative to the picture box
        private Rectangle _cropArea;    // is the current crop rectangle
        private bool _isMouseDown;  // true if the left mouse buttom is down

        public ImageCropForm(Form parent, Bitmap image)
        {
            InitializeComponent();

            Owner = parent;
            CropPictureBox.Image = image;
            _cropArea = new Rectangle(0, 0, 0, 0);
            _imageHandler = ImageHandler.GetInstance();
            _isMouseDown = false;

            OnCropPictureBoxResize();
        }

        private void ImageCropForm_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;
        }

        private void ImageCropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void CropPictureBox_SizeChanged(object sender, EventArgs e)
        {
            CropPictureBox.Invalidate();

            if (CropPictureBox.Image != null)
                OnCropPictureBoxResize();
        }

        private void CropPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Red, 1))
            {
                e.Graphics.DrawRectangle(p, _cropArea);
            }
        } 

        private void CropPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            CropPictureBox.Invalidate();

            _cropArea.X = e.X;
            _cropArea.Y = e.Y;
            _cropArea.Width = 0;
            _cropArea.Height = 0;
            _isMouseDown = true;
        }

        private void CropPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _cropArea.Width = (e.X - _cropArea.X);
                _cropArea.Height = (e.Y - _cropArea.Y);

                if (_cropAreaBounds.Contains(_cropArea))
                {
                    CropPictureBox.Invalidate();
                }
            }
        }

        private void CropPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (!(_cropArea.Width == 0 || _cropArea.Height == 0))
            {
                Rectangle scaledCropArea = new Rectangle
                {
                    X = (int)((_cropArea.X - _cropAreaBounds.X) * _resizeFactor),
                    Y = (int)((_cropArea.Y - _cropAreaBounds.Y) * _resizeFactor),
                    Width = (int)(_cropArea.Width * _resizeFactor),
                    Height = (int)(_cropArea.Height * _resizeFactor)
                };

                _imageHandler.Crop(scaledCropArea);
            }

            Close();
        }

        /// <summary>
        /// Called whenever the size of the crop picture box changes; it recalculates the resize factor used by the picture box
        /// to zoom image image and to determine the actual valid area where it is possible to crop (only on the image itself and
        /// not on the entirety of the picture box component).
        /// </summary>
        private void OnCropPictureBoxResize()
        {
            var widthFactor = (double)CropPictureBox.Image.Width / CropPictureBox.ClientSize.Width;
            var heightFactor = (double)CropPictureBox.Image.Height / CropPictureBox.ClientSize.Height;

            _resizeFactor = Math.Max(widthFactor, heightFactor);

            Size imageSize = new Size((int)(CropPictureBox.Image.Width / _resizeFactor), (int)(CropPictureBox.Image.Height / _resizeFactor));
            Size sizeDifference = new Size((CropPictureBox.Width - imageSize.Width) / 2, (CropPictureBox.Height - imageSize.Height) / 2);

            _cropAreaBounds = new Rectangle(sizeDifference.Width, sizeDifference.Height, imageSize.Width, imageSize.Height);
        }
    }
}
