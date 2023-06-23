using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSpecial
{
    class StaticExample
    {
        public static int num;
        public void count()
        {
            num++;
        }
        public int getNum()
        {
            return num;
        }
    }
}
