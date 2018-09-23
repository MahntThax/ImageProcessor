using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ImagemOriginal : Form
    {
        Image imagemDaJanela;

        public ImagemOriginal()
        {
            InitializeComponent();
            
        }

        private void CaixaImagem_Click(object sender, EventArgs e)
        {

        }

        public void updateImage(Image Imagem)
        {
            this.imagemDaJanela = Imagem;
            this.CaixaImagem.Image = this.imagemDaJanela;
            this.Width = Imagem.Width + 50;
            this.Height = Imagem.Height + 50;
            this.CaixaImagem.Anchor = AnchorStyles.None;
            this.CaixaImagem.Location = new Point((CaixaImagem.Parent.ClientSize.Width / 2) - (Imagem.Width / 2), (CaixaImagem.Parent.ClientSize.Height / 2) - (Imagem.Height / 2));
        }
    }
}
