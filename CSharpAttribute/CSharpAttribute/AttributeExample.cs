using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    class AttributeExample : Attribute
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return "["+Name+" "+Age+"]";
        }
    }
    //we can pass the properties here
    [AttributeExample(Name="selva",Age =21)]
    class Myclass
    {
        [AttributeExample]
        public string MyProperty { get; set; }
        [AttributeExample]
        public void MyMethod()
        {

        }
    }
}
