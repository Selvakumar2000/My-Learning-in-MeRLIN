using System;
using System.Diagnostics;
using System.Threading;

namespace SharedResourceExample
{
    class Program
    {
        public static int total=0; //shared resource
        //static object _lock = new object(); //way2 and way3
        public static void AddOneThousand()
        {
            for (int i = 1; i <= 1000; i++)
            {
                total++;
            }
            //Way-1
            //for (int i = 1; i <= 1000; i++)
            //{
            //    Interlocked.Increment(ref total);
            //}

            //Way-2
            /*for (int i = 1; i <= 1000; i++)
            {
                lock(_lock) //it allows only one thread to access the data
                {
                    total++;
                }
            }*/
            //Way-3 using monitor  ..monitor and lock both are same
            /*for (int i = 1; i <= 1000; i++)
            {
                Monitor.Enter(_lock)
                try //it allows only one thread to access the data
                {
                    total++;
                }
                catch(Exception e
                {
                     Console.WriteLine(e);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }*/
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            //Console.WriteLine("Hello World!");
            Thread t1 = new Thread(Program.AddOneThousand);
            Thread t2 = new Thread(Program.AddOneThousand);
            Thread t3 = new Thread(Program.AddOneThousand);
            t1.Start();
            //t1.Join();
            t2.Start();
            //t2.Join();
            t3.Start();
            //t3.Join();
            t1.Join(); t2.Join(); t3.Join(); //one way
            Console.WriteLine("Total Sum = {0}",total);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
            //way2 is better ...it improves the performance
        }
    }
}
