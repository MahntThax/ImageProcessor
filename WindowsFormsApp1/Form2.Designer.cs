namespace WindowsFormsApp1
{
    partial class ImagemOriginal
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
            this.CaixaImagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CaixaImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // CaixaImagem
            // 
            this.CaixaImagem.Location = new System.Drawing.Point(22, 12);
            this.CaixaImagem.Name = "CaixaImagem";
            this.CaixaImagem.Size = new System.Drawing.Size(447, 439);
            this.CaixaImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CaixaImagem.TabIndex = 0;
            this.CaixaImagem.TabStop = false;
            this.CaixaImagem.Click += new System.EventHandler(this.CaixaImagem_Click);
            // 
            // ImagemOriginal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(496, 473);
            this.Controls.Add(this.CaixaImagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImagemOriginal";
            this.Text = "Imagem Original";
            ((System.ComponentModel.ISupportInitialize)(this.CaixaImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CaixaImagem;
    }
}