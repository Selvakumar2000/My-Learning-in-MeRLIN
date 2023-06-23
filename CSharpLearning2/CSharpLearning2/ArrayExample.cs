using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning2
{
    class ArrayExample
    {
        public static void Myfun()
        {
            int i,j;
            int[] arr = new int[5];
            //assigning
            for(i=0;i<5;i++)
            {
                arr[i] = i + 100;
            }
            //printing
            for(i=0;i<5;i++)
            {
                Console.WriteLine(arr[i]);
            }
            //printing using foreach
            Console.WriteLine("\nprinting using foreach loop");
            foreach (int val in arr)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("\nMultidimensional Array:");
            int[,] a = new int[5, 2] { { 0, 0 }, { 1, 2 }, { 2, 4 }, { 3, 6 }, { 4, 8 } };

            /* output each array element's value */
            for (i = 0; i < 5; i++)
            {

                for (j = 0; j < 2; j++)
                {
                    Console.WriteLine("a[{0},{1}] = {2}", i, j, a[i, j]);
                }
            }
        }
    }
}
