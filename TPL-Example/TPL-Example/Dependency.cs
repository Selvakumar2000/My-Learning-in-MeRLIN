using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TPL_Example
{
    class Dependency
    {
        public static async Task CallMethod()
        {
            var count = await Method1();
            Method2(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}
