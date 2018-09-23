namespace WindowsFormsApp1
{
    partial class Main
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
            this.ButtonOpenImage = new System.Windows.Forms.Button();
            this.SaveCopyButton = new System.Windows.Forms.Button();
            this.Horizontal = new System.Windows.Forms.Button();
            this.Vertical = new System.Windows.Forms.Button();
            this.greyscaleButton = new System.Windows.Forms.Button();
            this.quantizacaoButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.redNumber = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.greenNumber = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.blueNumber = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lightNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.redNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonOpenImage
            // 
            this.ButtonOpenImage.Location = new System.Drawing.Point(12, 12);
            this.ButtonOpenImage.Name = "ButtonOpenImage";
            this.ButtonOpenImage.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenImage.TabIndex = 1;
            this.ButtonOpenImage.Text = "OpenImage";
            this.ButtonOpenImage.UseVisualStyleBackColor = true;
            this.ButtonOpenImage.Click += new System.EventHandler(this.ButtonOpenImage_Click);
            // 
            // SaveCopyButton
            // 
            this.SaveCopyButton.Location = new System.Drawing.Point(92, 12);
            this.SaveCopyButton.Name = "SaveCopyButton";
            this.SaveCopyButton.Size = new System.Drawing.Size(75, 23);
            this.SaveCopyButton.TabIndex = 3;
            this.SaveCopyButton.Text = "SaveCopy";
            this.SaveCopyButton.UseVisualStyleBackColor = true;
            this.SaveCopyButton.Click += new System.EventHandler(this.SaveCopyButton_Click);
            // 
            // Horizontal
            // 
            this.Horizontal.Location = new System.Drawing.Point(12, 41);
            this.Horizontal.Name = "Horizontal";
            this.Horizontal.Size = new System.Drawing.Size(155, 23);
            this.Horizontal.TabIndex = 4;
            this.Horizontal.Text = "Espelhar Horizontal";
            this.Horizontal.UseVisualStyleBackColor = true;
            this.Horizontal.Click += new System.EventHandler(this.Horizontal_Click);
            // 
            // Vertical
            // 
            this.Vertical.Location = new System.Drawing.Point(12, 70);
            this.Vertical.Name = "Vertical";
            this.Vertical.Size = new System.Drawing.Size(155, 23);
            this.Vertical.TabIndex = 5;
            this.Vertical.Text = "Espelhar Vertical";
            this.Vertical.UseVisualStyleBackColor = true;
            this.Vertical.Click += new System.EventHandler(this.Vertical_Click);
            // 
            // greyscaleButton
            // 
            this.greyscaleButton.Location = new System.Drawing.Point(12, 99);
            this.greyscaleButton.Name = "greyscaleButton";
            this.greyscaleButton.Size = new System.Drawing.Size(155, 23);
            this.greyscaleButton.TabIndex = 6;
            this.greyscaleButton.Text = "Escala cinza";
            this.greyscaleButton.UseVisualStyleBackColor = true;
            this.greyscaleButton.Click += new System.EventHandler(this.greyscaleButton_Click);
            // 
            // quantizacaoButton
            // 
            this.quantizacaoButton.Location = new System.Drawing.Point(12, 128);
            this.quantizacaoButton.Name = "quantizacaoButton";
            this.quantizacaoButton.Size = new System.Drawing.Size(155, 23);
            this.quantizacaoButton.TabIndex = 7;
            this.quantizacaoButton.Text = "quantização";
            this.quantizacaoButton.UseVisualStyleBackColor = true;
            this.quantizacaoButton.Click += new System.EventHandler(this.quantizacaoButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox1.Location = new System.Drawing.Point(12, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(16, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "R:";
            // 
            // redNumber
            // 
            this.redNumber.Location = new System.Drawing.Point(35, 157);
            this.redNumber.Name = "redNumber";
            this.redNumber.Size = new System.Drawing.Size(39, 20);
            this.redNumber.TabIndex = 9;
            this.redNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox2.Location = new System.Drawing.Point(13, 183);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(16, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "G:";
            // 
            // greenNumber
            // 
            this.greenNumber.Location = new System.Drawing.Point(35, 183);
            this.greenNumber.Name = "greenNumber";
            this.greenNumber.Size = new System.Drawing.Size(39, 20);
            this.greenNumber.TabIndex = 11;
            this.greenNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox3.Location = new System.Drawing.Point(13, 209);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(16, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "B:";
            // 
            // blueNumber
            // 
            this.blueNumber.Location = new System.Drawing.Point(35, 209);
            this.blueNumber.Name = "blueNumber";
            this.blueNumber.Size = new System.Drawing.Size(39, 20);
            this.blueNumber.TabIndex = 13;
            this.blueNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox4.Location = new System.Drawing.Point(13, 235);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(16, 20);
            this.textBox4.TabIndex = 14;
            this.textBox4.Text = "L:";
            // 
            // lightNumber
            // 
            this.lightNumber.Location = new System.Drawing.Point(35, 235);
            this.lightNumber.Name = "lightNumber";
            this.lightNumber.Size = new System.Drawing.Size(39, 20);
            this.lightNumber.TabIndex = 15;
            this.lightNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 302);
            this.Controls.Add(this.lightNumber);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.blueNumber);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.greenNumber);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.redNumber);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.quantizacaoButton);
            this.Controls.Add(this.greyscaleButton);
            this.Controls.Add(this.Vertical);
            this.Controls.Add(this.Horizontal);
            this.Controls.Add(this.SaveCopyButton);
            this.Controls.Add(this.ButtonOpenImage);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.redNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonOpenImage;
        private System.Windows.Forms.Button SaveCopyButton;
        private System.Windows.Forms.Button Horizontal;
        private System.Windows.Forms.Button Vertical;
        private System.Windows.Forms.Button greyscaleButton;
        private System.Windows.Forms.Button quantizacaoButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown redNumber;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown greenNumber;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.NumericUpDown blueNumber;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.NumericUpDown lightNumber;
    }
}

