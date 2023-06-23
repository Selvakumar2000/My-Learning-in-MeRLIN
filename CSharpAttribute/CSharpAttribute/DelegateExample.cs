using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAttribute
{
    //delegate return_type name(our wish); it is like class MyDelegate{}
    //delegate void MyDelegate();
    delegate void MyDelegate(string Name);
    delegate void Operation(int Number);
    class DelegateExample
    {
        public static void  Hello(string Name)
        {
            Console.WriteLine("Hii"+Name);
        }
        public static void Double(int Number)
        {
            Console.WriteLine("{0}x2={1}",Number,Number*2);
        }
        public static void Triple(int Number)
        {
            Console.WriteLine("{0}x3={1}",Number,Number*3);
        }
            
        public static void Test(MyDelegate del)
        {
            del("Selva");
        }
        public static void ExecuteOperation(int num,Operation operation)
        {
            operation(num);
        }
    }
}
