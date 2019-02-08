namespace SemanticImages.View
{
    partial class ImageResizeForm
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
            this.ResizeControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.ScaleTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.ResizeTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.ButtonsPanel.SuspendLayout();
            this.ResizeControlsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.ApplyButton);
            this.ButtonsPanel.Controls.Add(this.CancelButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 195);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(253, 50);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(175, 3);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 37);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(4, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 37);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ResizeControlsGroupBox
            // 
            this.ResizeControlsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResizeControlsGroupBox.Controls.Add(this.ScaleLabel);
            this.ResizeControlsGroupBox.Controls.Add(this.HeightLabel);
            this.ResizeControlsGroupBox.Controls.Add(this.ScaleTextBox);
            this.ResizeControlsGroupBox.Controls.Add(this.HeightTextBox);
            this.ResizeControlsGroupBox.Controls.Add(this.WidthTextBox);
            this.ResizeControlsGroupBox.Controls.Add(this.WidthLabel);
            this.ResizeControlsGroupBox.Controls.Add(this.ResizeTypeCheckBox);
            this.ResizeControlsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ResizeControlsGroupBox.Name = "ResizeControlsGroupBox";
            this.ResizeControlsGroupBox.Size = new System.Drawing.Size(253, 174);
            this.ResizeControlsGroupBox.TabIndex = 2;
            this.ResizeControlsGroupBox.TabStop = false;
            this.ResizeControlsGroupBox.Text = "Resize Image";
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Location = new System.Drawing.Point(6, 83);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(45, 17);
            this.ScaleLabel.TabIndex = 6;
            this.ScaleLabel.Text = "scale:";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(6, 54);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(51, 17);
            this.HeightLabel.TabIndex = 5;
            this.HeightLabel.Text = "height:";
            // 
            // ScaleTextBox
            // 
            this.ScaleTextBox.Location = new System.Drawing.Point(67, 80);
            this.ScaleTextBox.Name = "ScaleTextBox";
            this.ScaleTextBox.Size = new System.Drawing.Size(100, 22);
            this.ScaleTextBox.TabIndex = 4;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(67, 51);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.HeightTextBox.TabIndex = 3;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(67, 21);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.WidthTextBox.TabIndex = 2;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(6, 24);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(44, 17);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "width:";
            // 
            // ResizeTypeCheckBox
            // 
            this.ResizeTypeCheckBox.AutoSize = true;
            this.ResizeTypeCheckBox.Location = new System.Drawing.Point(6, 147);
            this.ResizeTypeCheckBox.Name = "ResizeTypeCheckBox";
            this.ResizeTypeCheckBox.Size = new System.Drawing.Size(161, 21);
            this.ResizeTypeCheckBox.TabIndex = 0;
            this.ResizeTypeCheckBox.Text = "Maintain aspect ratio";
            this.ResizeTypeCheckBox.UseVisualStyleBackColor = true;
            this.ResizeTypeCheckBox.CheckedChanged += new System.EventHandler(this.ResizeTypeCheckBox_CheckedChanged);
            // 
            // ImageResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 257);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.ResizeControlsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageResizeForm";
            this.Text = "ImageResizeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageResizeForm_FormClosed);
            this.Load += new System.EventHandler(this.ImageResizeForm_Load);
            this.ButtonsPanel.ResumeLayout(false);
            this.ResizeControlsGroupBox.ResumeLayout(false);
            this.ResizeControlsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox ResizeControlsGroupBox;
        private System.Windows.Forms.Label ScaleLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox ScaleTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.CheckBox ResizeTypeCheckBox;
    }
}