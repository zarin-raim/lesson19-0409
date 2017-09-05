using System;
using System.IO;
using System.Collections.Generic;

namespace Task1_framework_
{
    class Program
    {
        /*
         * Написать программу, читающую побайтно заданный файл
         * и подсчитывающую число появлений каждого из 256 возможных знаков.
         */

        static void Main(string[] args)
        {
            Dictionary<char, int> stat = new Dictionary<char, int>();

            string path = @"F:\STEP\C#\Solutions\lesson0409\2.txt";

            using (FileStream stream = 
                new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] bytes = new byte[stream.Length];

                stream.Read(bytes, 0, bytes.Length);

                string data = System.Text.Encoding.Unicode.GetString(bytes);
                foreach (char symbol in data)
                {
                    if (stat.ContainsKey(symbol))
                    {
                        stat[symbol]++;
                    }
                    else
                    {
                        stat[symbol] = 0;
                    }
                }
                //Console.WriteLine(data);
            }
            foreach (KeyValuePair<char, int> item in stat)
            {
                Console.WriteLine(item.Key + "\t\t" + item.Value);
            }
            Console.ReadLine();
        }
    }
}