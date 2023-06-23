using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAttribute
{
    class GenericsExample<T,U>
    {
        public bool Success { get; set; }
        public T Data1 { get; set; }
        public T Data2 { get; set; }
        public U Data3 { get; set; }

        public override string ToString()
        {
            return "[" + Success + " " + Data1 + " " + Data2 + " " + Data3 + "]";
        }
    }
}
