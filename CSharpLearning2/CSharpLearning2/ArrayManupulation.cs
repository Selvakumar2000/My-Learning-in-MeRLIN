using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning2
{
    class ArrayManupulation
    {
        public static void FindAvg(int[] a,int arrsize)
        {
            int sum = 0;
            for(int i=0;i<arrsize;i++)
            {
                sum = sum + a[i];
            }
            Console.WriteLine("Average is: {0}", sum / arrsize);
        }
    }
}
