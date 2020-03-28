using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace KluczowePunkty
{
    class Program
    {
        static void Main(string[] args)
        {
            PunktyKluczowe p = new PunktyKluczowe();
            p.AddMask();
            p.PotencialPoints(5000);
            Console.WriteLine("sdadasd");
        }
    }
    class PunktyKluczowe
    {
        public void AddMask()
        {
            Bitmap btm = new Bitmap(@"E:\SemestrIV\AI\Zajecia\KluczowePunkty\KluczowePunkty\photo.png");
            double[][] filterMatrix = new double[3][];
            filterMatrix[0] = new double[] { -1, -1, -1 };
            filterMatrix[1] = new double[] { -1, 8, -1 };
            filterMatrix[2] = new double[] { -1, -1, -1 };
            for (int i = 1; i < btm.Width-1; i++)
            {
                Console.WriteLine("asd");
                for (int j = 1; j < btm.Height-1; j++)
                {
                    int newR = 0;
                    int newG = 0;
                    int newB = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            int mask = (int)filterMatrix[k+1][l+1];
                            newR += btm.GetPixel(i + k, j + l).R * mask;
                            newG += btm.GetPixel(i + k, j + l).G * mask;
                            newB += btm.GetPixel(i + k, j + l).B * mask;
                        }
                    }
                    newR = CompareRGB(newR);
                    newG = CompareRGB(newG);
                    newB = CompareRGB(newB);
                    btm.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
                }
            }
            btm.Save(@"E:\SemestrIV\AI\Zajecia\KluczowePunkty\KluczowePunkty\NewPhoto1.png");
        }
        public int CompareRGB(int val)
        {
            if (val > 255)
                return 255;
            if (val < 0)
                return 0;
            return val;
        }
        public void PotencialPoints(int pointCount)
        {
            Bitmap btm = new Bitmap(@"E:\SemestrIV\AI\Zajecia\KluczowePunkty\KluczowePunkty\NewPhoto1.png");
            Bitmap result = new Bitmap(btm.Width, btm.Height);
            List<Point> keyPointCandidates = new List<Point>();


            for (int i = 1; i < btm.Width - 1; i++)
            {
                for (int k = 1; k < btm.Height - 1; k++)
                {
                    keyPointCandidates.Add(
                        new Point
                        {
                            x = i,
                            y = k,
                            brightness = CalculateBrightness(btm, i, k)
                        }
                        ); ;
                }
            }

            keyPointCandidates = keyPointCandidates.OrderByDescending(k => k.brightness).ToList();
            keyPointCandidates.RemoveRange(pointCount, keyPointCandidates.Count - pointCount);

            for (int i = 0; i < result.Width; i++)
            {
                for (int k = 0; k < result.Height; k++)
                {
                    CopyPixel(ref result, i, k, btm, i, k);
                }
            }

            foreach (var p in keyPointCandidates)
            {
                result.SetPixel(p.x, p.y, Color.FromArgb(255, 0, 0));
            }

            result.Save(@"E:\SemestrIV\AI\Zajecia\KluczowePunkty\KluczowePunkty\photoKeyPoints1.png");

        }
        public void CopyPixel(ref Bitmap dest, int x, int y, Bitmap source, int a, int b)
        {
            Color pxl = source.GetPixel(a, b);
            dest.SetPixel(x, y, pxl);
        }
        public float CalculateBrightness(Bitmap img, int x, int y)
        {
            float result = 0;

            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    result += img.GetPixel(x + a, y + b).GetBrightness();
                }
            }

            //We are calculating pixels in 3x3 matrix around pixel(x,y)
            return result / 9;
        }
        public struct Point
        {
            public int x;
            public int y;
            public float brightness;
        }
    }
    

}
