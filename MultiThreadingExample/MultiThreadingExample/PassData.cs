using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadingExample
{
    class PassData
    {
        private int _target;
        public PassData(int target)
        {
            this._target = target;
        }

        public void PrintNumbers()
        {
            for(int i=1;i<=_target;i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
