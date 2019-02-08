using System;
using System.Drawing;
using System.Windows.Forms;

namespace SemanticImages.View
{
    public partial class ImageResizeForm : Form
    {
        private ImageHandler _imageHandler;

        public ImageResizeForm()
        {
            InitializeComponent();

            _imageHandler = ImageHandler.GetInstance();
            ResizeTypeCheckBox.Checked = true;
        }

        private void ImageResizeForm_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;
            Left = (Owner.Left + Owner.Width) / 2;
            Top = (Owner.Top + Owner.Height) / 2;
        }

        private void ImageResizeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void ResizeTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WidthTextBox.Text = "";
            HeightTextBox.Text = "";
            ScaleTextBox.Text = "";

            if (ResizeTypeCheckBox.Checked)
            {
                WidthTextBox.Enabled = false;
                HeightTextBox.Enabled = false;
                ScaleTextBox.Enabled = true;
            }

            else
            {
                WidthTextBox.Enabled = true;
                HeightTextBox.Enabled = true;
                ScaleTextBox.Enabled = false;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (ResizeTypeCheckBox.Checked)
            {
                float.TryParse(ScaleTextBox.Text, out float scale);
                _imageHandler.Resize(scale);
            }

            else
            {
                int.TryParse(WidthTextBox.Text, out int width);
                int.TryParse(HeightTextBox.Text, out int height);
                _imageHandler.Resize(width, height);
            }

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
