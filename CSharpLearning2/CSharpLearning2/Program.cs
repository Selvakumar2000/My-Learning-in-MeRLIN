using System;

namespace CSharpLearning2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArrayExample.Myfun();
            Console.WriteLine("Enter size of an array:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for(int i=0;i<size;i++)
            {
                Console.Write("Enter element {0} ", ++i);
                arr[--i] = Convert.ToInt32(Console.ReadLine());
            }
            ArrayManupulation.FindAvg(arr, size);

            Console.WriteLine("Params Example=>passing any number of paramenters to a function....");
            ParamsExample.FindSum(1,2,3,4,5);
            Console.WriteLine("Using Arrays Class Function:");
            ArraysClass.ArrayFun();
        }
    }
}
