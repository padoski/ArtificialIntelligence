using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Data
    {
        public static void ReadData(string path, ref double[][] dane)
        {
            string[] linie = File.ReadAllLines(path);
            dane = new double[linie.Length][];
            for (int i = 0; i < linie.Length; i++)
            {
                string[] tmp = linie[i].Split(',');
                dane[i] = new double[tmp.Length + 2];
                
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    dane[i][j] = Convert.ToDouble(tmp[j].Replace('.',','));
                }
                if (tmp[4] == "Iris-setosa")
                {
                    dane[i][4] = 1;
                    dane[i][5] = 0;
                    dane[i][6] = 0;

                }
                else if (tmp[4] == "Iris-versicolor")
                {
                    dane[i][4] = 0;
                    dane[i][5] = 1;
                    dane[i][6] = 0;
                }
                else
                {
                    dane[i][4] = 0;
                    dane[i][5] = 0;
                    dane[i][6] = 1;
                }
            }
        }

        public static void Shuffle(ref double[][] data)
        {
            Random rnd = new Random();
            for (int i = data.Length - 1; i >= 0; i--)
            {
                int r = rnd.Next(0, data.Length);
                for (int j = 0; j < data[i].Length; j++)
                {
                    double tmp = data[i][j];
                    data[i][j] = data[r][j];
                    data[r][j] = tmp;
                }
            }
        }

        private static double FindMax(double[][] data, int columnIndex)
        {
            double max = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][columnIndex] > max)
                {
                    max = data[i][columnIndex];
                }
            }
            return max;
        }

        private static double FindMin(double[][] data, int columnIndex)
        {
            double min = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][columnIndex] < min)
                {
                    min = data[i][columnIndex];
                }
            }
            return min;
        }

        public static void Normalize(ref double[][] data)
        {
            double minValue = 0;
            double maxValue = 1;
            double min = 0;
            double max = 0;
            for (int i = 0; i < data[0].Length - 3; i++)
            {
                min = FindMin(data, i);
                max = FindMax(data, i);
                for (int j = 0; j < data.Length; j++)
                {
                    double temp = 0;
                    temp = (data[j][i] - min) / (max - min) * (maxValue - minValue);
                    data[j][i] = temp;
                }
            }
        }
    }
}

