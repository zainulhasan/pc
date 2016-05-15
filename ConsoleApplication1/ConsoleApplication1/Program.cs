using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            
            int[] arr = {0, 1, 2, 3, 4, 5, 6,7,8,9,10,11,12  };

            

            Shuffle(arr);
            foreach (int value in arr)
            {
                Console.Write(value+" ");
            }


            Console.WriteLine();
            Shuffle(arr);
            foreach (int value in arr)
            {
                Console.Write(value+" ");
            }




            Console.ReadKey();
        }



        static void Shuffle<T>(T[] array)
        {
            Random rand = new Random();
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int)(rand.NextDouble() * (n - i));
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }


    }
}
