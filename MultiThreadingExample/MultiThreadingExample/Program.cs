using System;
using System.Threading;

namespace MultiThreadingExample
{
    delegate void SumOfNumbersCallBack(int SumOfNumbers);
    class Program
    {
        public static void PrintSum(int sum)
        {
            Console.WriteLine("Sum is {0}",sum);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ThreadStartExample obj = new ThreadStartExample();
            //Threadstart delegate(type safe function pointer). All thread require an entry point to start execution
            //thread always need a delegate,if i not mention it,framework creates for us

            //Thread t1 = new Thread((obj.PrintNumbers));
            Thread t1 = new Thread(new ThreadStart(obj.PrintNumbers));
            //Thread t1 = new Thread(() => obj.PrintNumbers());  //all are same
            t1.Start();
            t1.Join();

//If a thread function expect a input parameter,then use ParameterizedThread start otherwise we can use ThreadStart delegate
            Console.WriteLine("Enter a target value:");
            object target = Console.ReadLine();
            //ParameterizedThreadStart pt = new ParameterizedThreadStart(obj.PrintUptoTarget);
            //Thread t2 = new Thread(pt);
            //compiler add its implicitly ...signature must be same
            Thread t2 = new Thread(obj.PrintUptoTarget);
            t2.Start(target); //we can pass any datatype values
            Console.WriteLine(".....................");
            t2.Join();

            //passing data to a thread using helper class
            Console.WriteLine("Passing a Data:Enter a target value:");
            int target1 = Convert.ToInt32(Console.ReadLine());
            PassData obj1 = new PassData(target1);
            Thread t3 = new Thread(obj1.PrintNumbers);
            t3.Start();
            t3.Join();

            //main thread passing data to child thread and child thread computes a sum and return it to main thread using callback function
            SumOfNumbersCallBack callBack = new SumOfNumbersCallBack(PrintSum);
            Console.WriteLine("Retrive Data:Enter a target value:");
            int target2 = Convert.ToInt32(Console.ReadLine());
            CallBackExample obj2 = new CallBackExample(target2,callBack);
            Thread t4 = new Thread(obj2.SumOfNumbers);
            t4.Start();
            t4.Join();


            //join in thread
            Console.WriteLine("Main Thread Started....");

            Thread t5 = new Thread(Thread5Function);
            t5.Start();
            t5.Join();

            Thread t6 = new Thread(Thread6Function);
            t6.Start();
            t6.Join();

            Console.WriteLine("Main Thread Ended.....");
        }
        public static void Thread5Function()
        {
            Console.WriteLine("Thread5Function Started..........");
        }

        public static void Thread6Function()
        {
            Console.WriteLine("Thread6Function Started..........");
        }
    }
}
