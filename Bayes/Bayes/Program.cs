using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayes
{
    class Program
    {

        static void Main(string[] args)
        { 
            Bayes b = new Bayes();
            b.ReadFromFiles();
           
            b.Propability("pochmurno", "chłodno", "mocny");
            Console.ReadKey();
        }

    }
    class Bayes
    {
        int temp1 { get; set; }
        private string[] _lines = File.ReadAllLines(@"E:\SemestrIV\AI\Zajecia\Bayes\dane.txt");
        private string[][] _data;
        private double[] _counters=new double[5] {0,0,0,0,0};
        private double[] _counterOfSame = new double[3] { 0, 0, 0 };


        public void ReadFromFiles()
        {
            _data = new string[_lines.Length][];
            for (int i = 0; i < _lines.Length; i++)
            {
                string[] tmp = _lines[i].Split(';');
                _data[i] = new string[tmp.Length];
                for (int j = 0; j < tmp.Length; j++)
                {
                    _data[i][j] = tmp[j];
                    //Console.WriteLine(_data[i][j]);
                }
            }
        }
        public void Propability(string a1, string a2, string a3)
        {

            for (int i = 0; i < _lines.Length; i++)
            {
                if (_data[i][0] == a1) { _counters[0]++; }
                if (_data[i][1] == a2) { _counters[1]++; }
                if (_data[i][2] == a3) { _counters[2]++; }
                if (_data[i][0] == a1 && _data[i][3] == "tak") { _counterOfSame[0]++; }
                if (_data[i][1] == a2 && _data[i][3] == "tak") { _counterOfSame[1]++; }
                if (_data[i][2] == a3 && _data[i][3] == "tak") { _counterOfSame[2]++; }
                if (_data[i][3] == "tak") { _counters[3]++; }
                if (_data[i][3] == "nie") { _counters[4]++; }
            }

            double[] pC1a = new double[3];
            double[] pC2a = new double[3];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Liczniki" +i+" "+_counters[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                if (_counterOfSame[i]==0)
                {
                    pC1a[i] = 1 / (_counters[3] + 3);
                }
                else
                {
                    pC1a[i] = _counterOfSame[i] / _counters[3] ;
                }             
            }
            for (int i = 0; i < 3; i++)
            {
                if (_counters[i] -_counterOfSame[i] == 0)
                {
                    pC2a[i] = 1 / (_counters[4] + 3);
                }
                else
                {
                    pC2a[i] = (_counters[i] - _counterOfSame[i]) / _counters[4] ;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("PC1Ai" + i + " "+pC1a[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("PC1A2" + i + " " + pC2a[i]);
            }


            double pC1 = _counters[3] / _lines.Length;
            double pC2 = _counters[4] / _lines.Length;
            double propC1;
            double propC2;

            propC1 =  pC1a[0]*pC1a[1]* pC1a[2]*pC1;
            propC2 = pC2a[0] * pC2a[1] * pC2a[2] * pC2;

            Console.WriteLine(propC1);
            Console.WriteLine(propC2);
            if (propC1>propC2)
            {
                Console.WriteLine("Decyzja to TAK");
            }
            else 
            {
                Console.WriteLine("Decyzja to NIE");
            }
           
            
        }
    }
}

