using System;

namespace AnonymousExample
{
    //delegates with lambda expresion (Anonymous Function)
    delegate void Operation(int Number);
    delegate int Operation1(int Number);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Operation op = Double;
            Operation op = delegate (int Number)
            {
                Console.WriteLine("Hii SK"); 
                Console.WriteLine("{0} x 2 = {1}", Number, Number * 2);
                Console.WriteLine("{0} x 3 = {1}", Number, Number * 3);
                Console.WriteLine("{0} x 4 = {1}", Number, Number * 4);
                Console.WriteLine("{0} x 5 = {1}", Number, Number * 5);
                Console.WriteLine("{0} x 6 = {1}", Number, Number * 6);
            };
            op(2);

            Console.WriteLine();
            Operation1 op1 = Number => { Console.WriteLine("Hii Selva"); return Number * 3;};
            int res = op1(3);
            Console.WriteLine(res);

            Console.WriteLine("....Delegates Declaration is Not Required.....");
            Action<int> op2 = Number => { Console.WriteLine("{0} x 10 = {1}",Number,Number*10); };
            op2(200);

            Func<int, int> Triple = x => { return x * 3; };
            Console.WriteLine(Triple(9));
        }
       /*
        public static void Double(int Number)
        {
            Console.WriteLine("{0} x 2 = {1}",Number,Number*2);
        }
       .....Generic Delegates....
        Action<input type> without return type
        Func<input type,output type> with return type
       */
    }
}
