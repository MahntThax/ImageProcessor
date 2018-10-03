using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor
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

        private void zoomIn()
        {
            //inicialização do lockbits para poder manipular a imagem
            Bitmap tempImage = new Bitmap(imagemDaJanela);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);
            IntPtr ptrImage = TempImageData.Scan0;                              //ponteiro do inicio da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;      //quantidade de bytes na imagem
            byte[] imgArrayFinal = new byte[bytes];                             //array com os bytes da imagem
            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);
            Bitmap zoomImage = new Bitmap(imagemDaJanela, new Size(imagemDaJanela.Size.Width * 2, imagemDaJanela.Size.Height * 2));
            BitmapData zoomImageData = zoomImage.LockBits(new Rectangle(0, 0, zoomImage.Width, zoomImage.Height), ImageLockMode.ReadWrite, zoomImage.PixelFormat);

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            updateImage((Image)tempImage.Clone());
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            zoomIn();
        }
    }
}
