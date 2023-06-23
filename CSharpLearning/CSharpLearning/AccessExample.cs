using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning
{
    class AccessExample
    {
        string password = "123456";
        private string name = "selva";
        private int age = 21;
        public string companyname="RIC";
        internal double length; //internal is similar to default access specifier
        internal double width;

        internal void Myfun()
        {
            Console.WriteLine("Hi selva");
        }
        double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
        public void PublicExample()
        {
            Console.WriteLine("My Company Name is"+ companyname);
            Console.WriteLine("My age is {0}", age);
        }
        public void PrivateExample()
        {
            Console.WriteLine("My age After 5 years will be {0}", age + 5);
        }
        
        public void InternalExample()
        {

        }
    }
}
