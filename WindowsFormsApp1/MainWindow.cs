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

namespace ImageProcessor
{
    public partial class Main : Form
    {
        Image OriginalImage;
        Image CopyImage;
        Image posHistogramaEqual;
        ImagemOriginal imagemOriginal;
        ImagemOriginal imagemCopia;
        bool janelaAberta;
        
        private struct ImageType
        {
            public bool colored;
            public bool grayscale;
        }

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
                                OriginalImage = new Bitmap(bmpTemp);
                                CopyImage = OriginalImage;
                                if (!janelaAberta)
                                {
                                    imagemOriginal = new ImagemOriginal();
                                    imagemOriginal.Show();
                                    imagemOriginal.updateImage(OriginalImage);
                                    imagemCopia = new ImagemOriginal();
                                    imagemCopia.Show();
                                    imagemCopia.updateImage(CopyImage);
                                    imagemCopia.Text = "Copia da imagem";
                                        
                                    janelaAberta = true;
                                }
                                else
                                {
                                    imagemOriginal.updateImage(OriginalImage);
                                    imagemCopia.updateImage(CopyImage);
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
                    CopyImage.Save(SaveImage.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Horizontal_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = new Bitmap(CopyImage);
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
            CopyImage = (Image)tempImage.Clone();
            imagemCopia.updateImage(CopyImage);
        }

        private void Vertical_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = new Bitmap(CopyImage);
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
            CopyImage = (Image)tempImage.Clone();
            imagemCopia.updateImage(CopyImage);
        }

        private void grayscaleButton_Click(object sender, EventArgs e)
        {
            grayscale();
        }

        private ImageType ColorCheck()
        {
            ImageType result;
            result.colored = false;
            result.grayscale = false;
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);

            //ponteiro para o inicio da image
            IntPtr ptrImage = TempImageData.Scan0;
            //array com os bytes da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;
            byte[] imgArrayFinal = new byte[bytes];

            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);
            if (imgArrayFinal[0] == imgArrayFinal[1] && imgArrayFinal[0] == imgArrayFinal[2])
                result.grayscale = true;
            else
                result.colored = true;

            return result;
        }

        private void grayscale()
        {
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);

            //ponteiro para o inicio da image
            IntPtr ptrImage = TempImageData.Scan0;
            //array com os bytes da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;
            byte[] imgArrayFinal = new byte[bytes];

            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);

            for (int pixel = 3; pixel < imgArrayFinal.Length; pixel += 4)
            {
                double color = imgArrayFinal[pixel - 3] * 0.299;
                byte redByte = System.Convert.ToByte(color);
                color = imgArrayFinal[pixel - 2] * 0.587;
                byte greenByte = System.Convert.ToByte(color);
                color = imgArrayFinal[pixel - 1] * 0.114;
                byte blueByte = System.Convert.ToByte(color);

                imgArrayFinal[pixel - 1] = imgArrayFinal[pixel - 2] = imgArrayFinal[pixel - 3] = Convert.ToByte(redByte + greenByte + blueByte);
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            CopyImage = (Image)tempImage.Clone();
            imagemCopia.updateImage(CopyImage);
        }

        private void quantizacaoButton_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);

            //ponteiro para o inicio da image
            IntPtr ptrImage = TempImageData.Scan0;
            //array com os bytes da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;
            byte[] imgArrayFinal = new byte[bytes];

            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);

            for (int pixel = 3; pixel < imgArrayFinal.Length; pixel += 4)
            {
                double color = imgArrayFinal[pixel - 3] * Convert.ToDouble(redNumber.Value / 100);
                byte redByte = Convert.ToByte(color);
                imgArrayFinal[pixel-3] = redByte;
                color = imgArrayFinal[pixel - 2] * Convert.ToDouble(greenNumber.Value) / 100;
                byte greenByte = Convert.ToByte(color);
                imgArrayFinal[pixel - 2] = greenByte;
                color = imgArrayFinal[pixel - 1] * Convert.ToDouble(blueNumber.Value) / 100;
                byte blueByte = Convert.ToByte(color);
                imgArrayFinal[pixel - 1] = blueByte;
                color = imgArrayFinal[pixel] * Convert.ToDouble(lightNumber.Value) / 100;
                byte lightByte = Convert.ToByte(color);
                imgArrayFinal[pixel] = lightByte;
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            CopyImage = (Image)tempImage.Clone();
            imagemCopia.updateImage(CopyImage);
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            ImageType type = ColorCheck();
            if(type.grayscale)
            {
                histogramGenerate();
            }
            else
            {
                grayscale();
                histogramGenerate();
            }

        }

        private void histogramGenerate()
        {
            //inicialização do lockbits para poder calcular o histograma
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);
            IntPtr ptrImage = TempImageData.Scan0;                              //ponteiro do inicio da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;      //quantidade de bytes na imagem
            byte[] imgArrayFinal = new byte[bytes];                             //array com os bytes da imagem
            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);
            int[] histograma = new int[256];
            int pixel = 0;

            for(int pos = 0; pos < imgArrayFinal.Length; pos+=4)
            {
                pixel = imgArrayFinal[pos];
                histograma[pixel] = histograma[pixel] + 1;
            }

            tempImage.UnlockBits(TempImageData);
            HistogramWindow janela = new HistogramWindow(histograma);
            janela.Show();
        }

        private void change_brightness()
        {
            //inicialização do lockbits para poder alterar brilho
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);
            IntPtr ptrImage = TempImageData.Scan0;                              //ponteiro do inicio da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;      //quantidade de bytes na imagem
            byte[] imgArrayFinal = new byte[bytes];                             //array com os bytes da imagem
            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);
            int pular = 0;                                                      //controla se deve pular o bit atual, para evitar de mudar o bit de alpha da imagem

            for(int i = 0; i < imgArrayFinal.Length; i++)
            {
                if (pular == 2)
                {
                    pular = 0;
                    i++;
                }
                else
                {
                    pular++;

                    if (imgArrayFinal[i] + brightnessSetting.Value < 0)
                        imgArrayFinal[i] = 0;
                    else
                        if (imgArrayFinal[i] + brightnessSetting.Value > 255)
                        imgArrayFinal[i] = 255;
                    else
                        imgArrayFinal[i] = Convert.ToByte(imgArrayFinal[i] + brightnessSetting.Value);
                }
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            CopyImage = (Image)tempImage.Clone();
            imagemCopia.updateImage(CopyImage);
        }

        private void brightness_Click(object sender, EventArgs e)
        {
            change_brightness();
        }

        private void change_contrast()
        {
            //inicialização do lockbits para poder alterar brilho
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);
            IntPtr ptrImage = TempImageData.Scan0;                              //ponteiro do inicio da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;      //quantidade de bytes na imagem
            byte[] imgArrayFinal = new byte[bytes];                             //array com os bytes da imagem
            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);
            int pular = 0;                                                      //controla se deve pular o bit atual, para evitar de mudar o bit de alpha da imagem

            for (int i = 0; i < imgArrayFinal.Length; i++)
            {
                if (pular == 3)
                {
                    pular = 0;
                }
                else
                {
                    pular++;

                    if (imgArrayFinal[i] * ContrastSetting.Value < 0)
                        imgArrayFinal[i] = 0;
                    else
                        if (imgArrayFinal[i] * ContrastSetting.Value > 255)
                        imgArrayFinal[i] = 255;
                    else
                        imgArrayFinal[i] = Convert.ToByte(imgArrayFinal[i] * ContrastSetting.Value);
                }
                    
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            CopyImage = (Image)tempImage.Clone();
            imagemCopia.updateImage(CopyImage);
        }

        private void Contrast_Click(object sender, EventArgs e)
        {
            change_contrast();
        }

        private void Negative_Image()
        {
            //inicialização do lockbits para poder alterar brilho
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);
            IntPtr ptrImage = TempImageData.Scan0;                              //ponteiro do inicio da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;      //quantidade de bytes na imagem
            byte[] imgArrayFinal = new byte[bytes];                             //array com os bytes da imagem
            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);
            int pular = 0;                                                      //controla se deve pular o bit atual, para evitar de mudar o bit de alpha da imagem

            for (int i = 0; i < imgArrayFinal.Length; i++)
            {
                if (pular == 3)
                {
                    pular = 0;
                }
                else
                {
                    pular++;

                    imgArrayFinal[i] = Convert.ToByte(255 - imgArrayFinal[i]);
                }
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);

            tempImage.UnlockBits(TempImageData);
            CopyImage = (Image)tempImage.Clone();
            imagemCopia.updateImage(CopyImage);
        }

        private void NegativeButton_Click(object sender, EventArgs e)
        {
            Negative_Image();
        }

        private void Equalization()
        {
            //inicialização do lockbits para poder alterar brilho
            Bitmap tempImage = new Bitmap(CopyImage);
            BitmapData TempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, tempImage.PixelFormat);
            IntPtr ptrImage = TempImageData.Scan0;                              //ponteiro do inicio da imagem
            int bytes = Math.Abs(TempImageData.Stride) * tempImage.Height;      //quantidade de bytes na imagem
            byte[] imgArrayFinal = new byte[bytes];                             //array com os bytes da imagem
            Marshal.Copy(ptrImage, imgArrayFinal, 0, bytes);

            float alfa = 255;
            alfa = alfa / (imgArrayFinal.Length / 4);
            int pixel = 0;

            
            int[] histograma = new int[256], histograma_acumulado = new int[256];
            int[] histogramaPosicao = new int[imgArrayFinal.Length / 4];
            int index = 0;

            for (int pos = 0; pos < imgArrayFinal.Length; pos += 4)     //calcula histograma
            {
                pixel = imgArrayFinal[pos];
                histograma[pixel] = histograma[pixel] + 1;
                histogramaPosicao[index] = pixel;
                index++;
            }
            float aux = alfa * histograma[0];
            histograma_acumulado[0] = (int)aux;
            for(int pos = 1; pos < histograma.Length;pos++)
            {
                aux = histograma_acumulado[pos - 1] + alfa * histograma[pos];
                histograma_acumulado[pos] = (int)aux;
            }
            index = 0;
            for (int pos = 0; pos < imgArrayFinal.Length; pos += 4)
            {
                imgArrayFinal[pos] = imgArrayFinal[pos + 1] = imgArrayFinal[pos + 2] = (byte)histograma_acumulado[histogramaPosicao[index]];
                index++;
            }

            Marshal.Copy(imgArrayFinal, 0, ptrImage, bytes);
            tempImage.UnlockBits(TempImageData);


            ImagemOriginal imagemExtra = new ImagemOriginal();
            imagemExtra.Show();
            posHistogramaEqual = (Image)tempImage.Clone();
            imagemExtra.updateImage(posHistogramaEqual);
            imagemExtra.updateImage(posHistogramaEqual);
            imagemExtra.updateImage(posHistogramaEqual);
        }

        private void EqualHistogrambutton_Click(object sender, EventArgs e)
        {
            Equalization();
        }
    }
}
