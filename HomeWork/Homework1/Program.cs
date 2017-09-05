﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    class Program
    {
        static bool IsFib(List<int> numbers)
        {
            bool res = false; //4 5 9 14 23
            for(int i = 0; i < numbers.Count - 2; i++)
            {
                if (numbers[i] + numbers[i + 1] == numbers[i + 2])
                    res = true;
                else
                    return false;
            }
            return res;
        }

        static List<int> MakeFib(List<int> numbers)
        {
            int size = numbers.Count;
            for(int i = size - 1; i < (size * 2) - 1; i++)
            {
                numbers.Add(numbers[i - 1] + numbers[i]);
            }
            return numbers;
        }

        static void Main(string[] args)
        {
            string path = @"F:\STEP\C#\Solutions\lesson0409\";

            string[] words;
            List<int> numbers = new List<int>();
            
            using (StreamReader stream = new StreamReader(path + "fib.txt"))
            {
                string text = stream.ReadLine();

                words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            bool isInt = false;
            foreach(string item in words)
            {
                int number;
                isInt = int.TryParse(item, out number);

                if (isInt)
                    numbers.Add(number);
            }

            if (IsFib(numbers))
            {
                numbers = MakeFib(numbers);
                
                foreach (int item in numbers)
                {
                    Console.Write(item + "  ");
                }


                using (FileStream stream = new FileStream(path + "fib2.txt", FileMode.Create))
                {
                    string data = String.Join<int>(" ", numbers);

                    byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);

                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            else
            {
                Console.WriteLine("Последовательность не является рядом Фибоначчи");
            }
            Console.ReadLine();            
        }
    }
}
