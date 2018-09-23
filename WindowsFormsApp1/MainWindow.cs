using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        Image OriginalImage;
        Image CopyImage;
        ImagemOriginal imagemOriginal;
        ImagemOriginal imagemCopia;
        bool janelaAberta;

        public Main()
        {
            InitializeComponent();
            janelaAberta = false;
        }

        private void ButtonOpenImage_Click(object sender, EventArgs e)
        {
            Stream streamImage = null;
            OpenFileDialog ImageSourceDialog = new OpenFileDialog();

            if(ImageSourceDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if((streamImage = ImageSourceDialog.OpenFile()) != null)
                    {
                        using (streamImage)
                        {
                            using (var bmpTemp = new Bitmap(ImageSourceDialog.FileName))
                            {
                                this.OriginalImage = new Bitmap(bmpTemp);
                                this.CopyImage = this.OriginalImage;
                                if (!janelaAberta)
                                {
                                    imagemOriginal = new ImagemOriginal();
                                    imagemOriginal.Show();
                                    imagemOriginal.updateImage(this.OriginalImage);
                                    imagemCopia = new ImagemOriginal();
                                    imagemCopia.Show();
                                    imagemCopia.updateImage(this.CopyImage);
                                    imagemCopia.Text = "Copia da imagem";
                                        
                                    janelaAberta = true;
                                }
                                else
                                {
                                    imagemOriginal.updateImage(this.OriginalImage);
                                    imagemCopia.updateImage(this.CopyImage);
                                }
                            }
                            streamImage.Dispose();

                            
                            
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SaveCopyButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveImage = new SaveFileDialog();
            SaveImage.Filter = "Images| *.jpg";
            
            if(SaveImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.CopyImage.Save(SaveImage.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Horizontal_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = new Bitmap(this.CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0 , tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);

            //ponteiro para o inicio da image
            IntPtr ptrImage = TempImageData.Scan0;
            //array com os bytes da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;
            byte[] imgArrayTemp = new byte[bytes];
            byte[] imgArrayFinal = new byte[bytes];

            Marshal.Copy(ptrImage, imgArrayTemp, 0, bytes);
            int pixelAtual, pixelVirado;

            for (int linha = 0; linha < tempImage.Height; linha++)
            {
                for (int coluna = 0; coluna < tempImage.Width; coluna++)
                {
                    pixelAtual = linha * TempImageData.Stride + coluna * 4;
                    pixelVirado = linha * TempImageData.Stride + (tempImage.Width - coluna) * 4 - 4;
                    for (int interno = 0; interno < 4; interno++)
                    {
                        imgArrayFinal[pixelVirado + interno] = imgArrayTemp[pixelAtual + interno];
                    }
                }
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            this.CopyImage = (Image)tempImage.Clone();
            this.imagemCopia.updateImage(this.CopyImage);
        }

        private void Vertical_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = new Bitmap(this.CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);

            //ponteiro para o inicio da image
            IntPtr ptrImage = TempImageData.Scan0;
            //array com os bytes da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;
            byte[] imgArrayTemp = new byte[bytes];
            byte[] imgArrayFinal = new byte[bytes];

            Marshal.Copy(ptrImage, imgArrayTemp, 0, bytes);
            int pixelAtual, pixelVirado;

            for (int linha = 0; linha < tempImage.Height; linha++)
            {
                pixelAtual = linha * TempImageData.Stride;
                pixelVirado = (tempImage.Height - linha) * TempImageData.Stride - TempImageData.Stride;
                for (int interno = 0; interno < TempImageData.Stride; interno++)
                {
                    imgArrayFinal[pixelVirado + interno] = imgArrayTemp[pixelAtual + interno];
                }
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            this.CopyImage = (Image)tempImage.Clone();
            this.imagemCopia.updateImage(this.CopyImage);
        }

        private void greyscaleButton_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = new Bitmap(this.CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);

            //ponteiro para o inicio da image
            IntPtr ptrImage = TempImageData.Scan0;
            //array com os bytes da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;
            byte[] imgArrayFinal = new byte[bytes];

            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);

            for(int pixel=3;pixel<imgArrayFinal.Length;pixel+=4)
            {
                double color = imgArrayFinal[pixel - 3] * 0.299;
                byte redByte = System.Convert.ToByte(color);
                color = imgArrayFinal[pixel - 2] * 0.587;
                byte greenByte = System.Convert.ToByte(color);
                color = imgArrayFinal[pixel - 1] * 0.114;
                byte blueByte = System.Convert.ToByte(color);

                imgArrayFinal[pixel] = System.Convert.ToByte(redByte + greenByte + blueByte);
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            this.CopyImage = (Image)tempImage.Clone();
            this.imagemCopia.updateImage(this.CopyImage);
        }

        private void quantizacaoButton_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = new Bitmap(this.CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);

            //ponteiro para o inicio da image
            IntPtr ptrImage = TempImageData.Scan0;
            //array com os bytes da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;
            byte[] imgArrayFinal = new byte[bytes];

            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);

            for (int pixel = 3; pixel < imgArrayFinal.Length; pixel += 4)
            {
                double color = imgArrayFinal[pixel - 3] * System.Convert.ToDouble(this.redNumber.Value / 100);
                byte redByte = System.Convert.ToByte(color);
                imgArrayFinal[pixel-3] = redByte;
                color = imgArrayFinal[pixel - 2] * System.Convert.ToDouble(this.greenNumber.Value) / 100;
                byte greenByte = System.Convert.ToByte(color);
                imgArrayFinal[pixel - 2] = greenByte;
                color = imgArrayFinal[pixel - 1] * System.Convert.ToDouble(this.blueNumber.Value) / 100;
                byte blueByte = System.Convert.ToByte(color);
                imgArrayFinal[pixel - 1] = blueByte;
                color = imgArrayFinal[pixel] * System.Convert.ToDouble(this.lightNumber.Value) / 100;
                byte lightByte = System.Convert.ToByte(color);
                imgArrayFinal[pixel] = lightByte;
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            this.CopyImage = (Image)tempImage.Clone();
            this.imagemCopia.updateImage(this.CopyImage);
        }
    }
}
