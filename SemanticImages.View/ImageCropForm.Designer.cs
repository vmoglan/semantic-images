namespace SemanticImages.View
{
    partial class ImageCropForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CropPictureBox = new System.Windows.Forms.PictureBox();
            this.ButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CropPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.ApplyButton);
            this.ButtonsPanel.Controls.Add(this.CancelButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 388);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(776, 50);
            this.ButtonsPanel.TabIndex = 4;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(698, 3);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 37);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(617, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 37);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CropPictureBox
            // 
            this.CropPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CropPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CropPictureBox.Location = new System.Drawing.Point(12, 12);
            this.CropPictureBox.Name = "CropPictureBox";
            this.CropPictureBox.Size = new System.Drawing.Size(776, 370);
            this.CropPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CropPictureBox.TabIndex = 5;
            this.CropPictureBox.TabStop = false;
            this.CropPictureBox.SizeChanged += new System.EventHandler(this.CropPictureBox_SizeChanged);
            this.CropPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CropPictureBox_Paint);
            this.CropPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CropPictureBox_MouseDown);
            this.CropPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CropPictureBox_MouseMove);
            this.CropPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CropPictureBox_MouseUp);
            // 
            // ImageCropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CropPictureBox);
            this.Controls.Add(this.ButtonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ImageCropForm";
            this.Text = "Image Crop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageCropForm_FormClosed);
            this.Load += new System.EventHandler(this.ImageCropForm_Load);
            this.ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CropPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button ApplyButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.PictureBox CropPictureBox;
    }
}