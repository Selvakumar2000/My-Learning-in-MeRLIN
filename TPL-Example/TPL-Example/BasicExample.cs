using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TPL_Example
{
    class BasicExample
    {
        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    // Do something
                    Task.Delay(100).Wait();
                }
            });
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
                // Do something
                Task.Delay(100).Wait();
            }
        }

        public static void Method3()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 3");
                // Do something
                Task.Delay(100).Wait();
            }
        }
    }
}
