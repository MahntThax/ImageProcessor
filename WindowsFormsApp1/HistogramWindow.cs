using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessor
{
    public partial class HistogramWindow : Form
    {
        public HistogramWindow(int[] histogram)
        {
            InitializeComponent();

            var normalize = histogram;
            var max = histogram.Max();
            var min = histogram.Min();
            var variacao = max - min;

            for (int i = 0; i < normalize.Length; i++)
            {
                normalize[i] = ((histogram[i] - min) * 255 / variacao) + 1;
            }

            histograma.Series[0].Points.DataBindY(histogram);
            histograma.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            histograma.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            histograma.MouseWheel += histograma_MouseWheel;

        }

        private void histograma_MouseWheel(object sender, MouseEventArgs e)
        {
            var grafico = (Chart)sender;
            var xAxis = grafico.ChartAreas[0].AxisX;
            var yAxis = grafico.ChartAreas[0].AxisY;
            var xMin = xAxis.ScaleView.ViewMinimum;
            var xMax = xAxis.ScaleView.ViewMaximum;
            var yMin = yAxis.ScaleView.ViewMinimum;
            var yMax = yAxis.ScaleView.ViewMaximum;
            int zoomCount = 0;

            int zoomIntervalo = 100;

            try
            {
                if (e.Delta < 0 && zoomCount > 0) //Scroll down
                {
                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - zoomIntervalo * 2 / Math.Pow(2, zoomCount);
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + zoomIntervalo * 2 / Math.Pow(2, zoomCount);
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - zoomIntervalo * 2 / Math.Pow(2, zoomCount);
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + zoomIntervalo * 2 / Math.Pow(2, zoomCount);

                    if (posXStart < 0) posXStart = 0;
                    if (posYStart < 0) posYStart = 0;
                    if (posYFinish > yAxis.Maximum) posYFinish = yAxis.Maximum;
                    if (posXFinish > xAxis.Maximum) posYFinish = xAxis.Maximum;
                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                    zoomCount--;
                }
                else if (e.Delta < 0 && zoomCount == 0) //Não tem como dar mais zoomout
                {
                    yAxis.ScaleView.ZoomReset();
                    xAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) //Scroll up
                {

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - zoomIntervalo / Math.Pow(2, zoomCount);
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + zoomIntervalo / Math.Pow(2, zoomCount);
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - zoomIntervalo / Math.Pow(2, zoomCount);
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + zoomIntervalo / Math.Pow(2, zoomCount);

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                    zoomCount++;
                }

                if (zoomCount < 0)
                    zoomCount = 0;
            }
            catch { }
        }
    }
}
