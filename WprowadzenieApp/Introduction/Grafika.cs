using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Grafika
    {
        private string filePath = "..//photo.jpg";
        private Color[][] btmmatrixColor;
        private Bitmap img = new Bitmap(@"..//photo.jpg");
        
        public Grafika()
        {
            btmmatrixColor = getBitmapColorMatrix(filePath);
            LoadMatrixRGB();
            Filtering(Sharp(),"_Sharp_filer");
            Filtering(Blur(), "_Blur_filer");
            Filtering(EdgeDetection(),"EdgeDetector_filer");
            Filtering(Gauss(), "_Gauss_filer");
        }

        private void LoadMatrixRGB()
        {
            Bitmap maskImg = new Bitmap(filePath);
            Bitmap result = new Bitmap(maskImg.Width, maskImg.Height);
            List<Color> pixelsList = new List<Color>();

            for (int i = 1; i < img.Width - 1; i++)
            {
                for (int k = 1; k < img.Height - 1; k++)
                {
                    pixelsList.Add(btmmatrixColor[i][k]);
                   // Console.WriteLine(btmmatrixColor[i][k]);
                }
            }

        }
        private double[][] Sharp()
        {
            double[][] filtr = new double[3][];
            filtr[0] = new double[] { -1, -1, -1 };
            filtr[1] = new double[] { -1, 9, -1 };
            filtr[2] = new double[] { -1, -1, -1 };
            return filtr;
        }
        private double[][] Gauss()
        {
            double[][] filtr = new double[3][];
            filtr[0] = new double[] { 0.075, 0.124, 0.075 };
            filtr[1] = new double[] { 0.124, 0.204, 0.124 };
            filtr[2] = new double[] { 0.075, 0.124, 0.075 };
            return filtr;
        }
        private double[][] Blur()
        {
            double[][] filtr = new double[3][];
            double number = 1.0 / 9.0;
            filtr[0] = new double[] { number, number, number };
            filtr[1] = new double[] { number, number, number };
            filtr[2] = new double[] { number, number, number };
            return filtr;
        }
        private double[][] EdgeDetection()
        {
            double[][] filtr = new double[3][];
            filtr[0] = new double[] { 0, 1, 0 };
            filtr[1] = new double[] { 1, -4, 1 };
            filtr[2] = new double[] { 0, 1, 0 };
            return filtr;
        }

        private void Filtering(double[][] maska,string filename)
        {
            Bitmap newimage = new Bitmap(img.Width, img.Height);
            double[][] filtr = maska;
            for (int i = 1; i < img.Width - 1; i++)
            {
                for (int j = 1; j < img.Height - 1; j++)
                {
                    double RValue = 0;
                    double GValue = 0;
                    double BValue = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            double mask = filtr[k + 1][l + 1];
                            RValue += img.GetPixel(i + k, j + l).R * mask;
                            GValue += img.GetPixel(i + k, j + l).G * mask;
                            BValue += img.GetPixel(i + k, j + l).B * mask;
                        }
                    }
                    if (RValue > 255)
                    { RValue = 255; }
                    else if (RValue < 0)
                    { RValue = 0; }

                    if (GValue > 255)
                    { GValue = 255; }
                    else if (GValue < 0)
                    { GValue = 0; }

                    if (BValue > 255)
                    { BValue = 255; }
                    else if (BValue < 0)
                    { BValue = 0; }

                    RValue = Math.Round(RValue);
                    GValue = Math.Round(GValue);
                    BValue = Math.Round(BValue);
                    Convert.ToInt32(RValue);
                    Convert.ToInt32(GValue);
                    Convert.ToInt32(BValue);
                    
                    newimage.SetPixel(i, j, Color.FromArgb((int)RValue, (int)GValue, (int)BValue));
                }
            }
            string file = Path.GetFileNameWithoutExtension(filePath);
            string NewPath = filePath.Replace(file, file + filename);
            newimage.Save(NewPath);
            
        }
        private Color[][] getBitmapColorMatrix(string filePath)
        {
            Color[][] matrix;
            int height = img.Height;
            int width = img.Width;
            if (height > width)
            {
                matrix = new Color[img.Width][];
                for (int i = 0; i <= img.Width - 1; i++)
                {
                    matrix[i] = new Color[img.Height];
                    for (int j = 0; j < img.Height - 1; j++)
                    {
                        matrix[i][j] = img.GetPixel(i, j);
                    }
                }
            }
            else
            {
                matrix = new Color[img.Height][];
                for (int i = 0; i <= img.Height - 1; i++)
                {
                    matrix[i] = new Color[img.Width];
                    for (int j = 0; j < img.Width - 1; j++)
                    {
                        matrix[i][j] = img.GetPixel(i, j);
                    }
                }
            }
            
            return matrix;
        }
        
        
    }
}

