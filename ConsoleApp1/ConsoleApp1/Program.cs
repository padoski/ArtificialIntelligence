using System;
using System.IO;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\pawel\Desktop\baza.txt");
            Console.WriteLine(lines);
            double[][] data = new double[lines.Length][];
            for (int i=0;i<lines.Length;i++)
            {
                string[] tmp = lines[i].Split(',');
                data[i] = new double[tmp.Length +2 ];
                for(int j =0;j<tmp.Length-1;j++)
                {
                    data[i][j] = Convert.ToDouble(tmp[j].Replace('.',','));
                }
                if (tmp[4] == "Iris-setosa")
                {
                    data[i][4] = 1;
                    data[i][5] = 0;
                    data[i][6] = 0;

                }
                else if (tmp[4] == "Iris-versicolor")
                {
                    data[i][5] = 0;
                    data[i][5] = 1;
                    data[i][6] = 0;
                }
                else
                {
                    data[i][5] = 0;
                    data[i][5] = 0;
                    data[i][6] = 1;
                }
            }

            for(int i=0;i<7;i++)
            {
                Console.WriteLine(data[1][i]);
            }

            ////////////////////////////////////////
            Bitmap btm



        }
    }
}
