using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAttribute
{
    class ObseleteExample
    {
        [Obsolete("Use AddMore(List<int> Numbers) Method")]
        public static void AddFun(int FirstNumber,int SecondNumber)
        {
            Console.WriteLine("Sum is {0}", FirstNumber + SecondNumber);
        }
        [Obsolete("Use AddMore(List<int> Numbers) Method")]
        public static  void AddFun(int FirstNumber, int SecondNumber,int ThirdNumber)
        {
            Console.WriteLine("Sum is {0}", FirstNumber + SecondNumber+ThirdNumber);
        }
        public static void AddMoreNumbers(List<int> Numbers)
        {
            Console.WriteLine("Welcome to NewMethod!!!!!!");
            int Sum = 0;
            foreach(int Number in Numbers)
            {
                Sum = Sum + Number;
            }
            Console.WriteLine("Sum is {0}", Sum);
        }
    }
}
