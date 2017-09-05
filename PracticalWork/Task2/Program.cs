using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        /*
         * С помощью класса StreamWriter записать в текстовый файл свое имя, 
         * фамилию и возраст. Каждая запись должна начинаться с новой строки.
         */ 
        static void Main(string[] args)
        {
            string path = @"F:\STEP\C#\Solutions\lesson0409\pwtask2.txt";
            using (StreamWriter stream = new StreamWriter(path))
            {
                stream.WriteLine("Zarina");
                stream.WriteLine("Raimkulova");
                stream.WriteLine("18");
            }
        }
    }
}
