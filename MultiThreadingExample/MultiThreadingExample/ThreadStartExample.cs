using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadingExample
{
    public class ThreadStartExample
    {
        public void PrintNumbers()
        {
            for(int i=1;i<=10;i++)
            {
                Console.WriteLine(i);
            }
        }

        public void PrintUptoTarget(object target)
        {
            int number = 0;
            if (int.TryParse(target.ToString(), out number))
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
