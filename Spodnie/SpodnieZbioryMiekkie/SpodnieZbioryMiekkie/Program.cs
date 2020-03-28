using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpodnieZbioryMiekke
{
    class Program
    {
        //Paweł Gładysz Adam Kierat (pair programming)
        static void Main(string[] args)
        {
            int[] nike_tablica = new int[11] { 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0 };
            int[] adidas_tablica = new int[11] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1 };
            int[] levis_tablica = new int[11] { 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1 };
            int[] zara_tablica = new int[11] { 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1 };
            int[] lee_tablica = new int[11] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0 };

            double[] klientA = new double[11] { 0, 0, 0.3, 0, 0, 0.5, 0, 0, 0, 0.7, 0 };
            double[] klientB = new double[11] { 0, 0, 0.5, 0, 0.6, 0, 0, 0, 0, 0, 0.8 };

            int[][] data_array = new int[][] { nike_tablica, adidas_tablica, levis_tablica, zara_tablica, lee_tablica };

            double[] klientA_wagi = new double[] { 0, 0, 0, 0, 0 };
            double[] klientB_wagi = new double[] { 0, 0, 0, 0, 0 };

            string[] wybor_Klientow = new string[] { "", ""};

            int licznik = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 11; j++)
                {

                    klientA_wagi[licznik] += data_array[i][j] * klientA[j];
                    klientB_wagi[licznik] += data_array[i][j] * klientB[j];
                    licznik++;
                    if (licznik == 5) licznik = 0;
                }
            }

           /* for (int p = 0; p < klientA_wagi.Length; p++)
            {
                Console.WriteLine(klientA_wagi[p]);
            }
            for (int p = 0; p < klientB_wagi.Length; p++)
            {
                Console.WriteLine(klientB_wagi[p]);
            }*/

            double KlientA_wartosc_max = klientA_wagi.Max();
            int KlientA_wartosc_max_index = Array.IndexOf(klientA_wagi, KlientA_wartosc_max);

            for (int y = 0; y < klientA_wagi.Length; y++)
            {

                if (KlientA_wartosc_max == klientA_wagi[y])
                {
                    wybor_Klientow[0] += "Wybór Klienta A to: " + NajlepszeGacie(y);
                }
                if (y + 1 == klientA_wagi.Length)
                {
                    wybor_Klientow[0] += "\r\n";
                }

            }

            double KlientB_wartosc_max = klientB_wagi.Max();
            int KlientB_wartosc_max_index = Array.IndexOf(klientB_wagi, KlientB_wartosc_max);

            for (int y = 0; y < klientB_wagi.Length; y++)
            {
                if (KlientB_wartosc_max == klientB_wagi[y])
                {
                    wybor_Klientow[0] += "Wybór Klienta B to: " + NajlepszeGacie(y);
                }
                if (y + 1 == klientA_wagi.Length)
                {
                    wybor_Klientow[0] += "\r\n";
                }


            }
            foreach (string x in wybor_Klientow)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }
        static string NajlepszeGacie(int wartosc_max_Klienta)
        {
            string nazwa = "";
            switch (wartosc_max_Klienta)
            {
                case 0:
                    nazwa = "Nike";
                    break;
                case 1:
                    nazwa = "addidas";
                    break;
                case 2:
                    nazwa = "levis";
                    break;
                case 3:
                    nazwa = "zara";
                    break;
                case 4:
                    nazwa = "lee";
                    break;

            }

            return nazwa;
        }

    }
}