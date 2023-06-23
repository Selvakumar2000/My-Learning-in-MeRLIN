using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning2
{
    class ParamsExample
    {
        public static void FindSum(params int[] arr)
        {
            int sum = 0;
            for(int i=0;i<arr.Length;i++)
            {
                sum = sum + arr[i];
            }
            Console.WriteLine("Sum of all the elements is {0}", sum);
        }
    }
}
