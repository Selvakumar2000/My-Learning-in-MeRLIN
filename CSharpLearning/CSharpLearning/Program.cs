using System;

namespace CSharpLearning
{
    class Calculation
    {
        public int area, breath, height;
        public void AssignVal()
        {
            breath = 10;
            height = 10;
            Console.WriteLine("Size of int: {0}", sizeof(int));
        }
        public void Calculate()
        {
            area = breath * height;
        }
        public void Display()
        {
            Console.WriteLine(area);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Working with DateTime
            Console.WriteLine("Hello World!");
            var today = DateTime.Today;
            DateTime dob = new DateTime(2000, 10, 03);
            Console.WriteLine("Date:"+dob.Date);
            Console.WriteLine(today.Year+" "+dob.Year);
            var age = today.Year - dob.Year;
            Console.WriteLine("My age is "+age);
            Console.WriteLine("Today:"+today+" "+"AddYears Function:"+today.AddYears(-age));
            //double val = 12345.2332;
            //Console.WriteLine((int)val);
            //Calculation obj = new Calculation();
            //obj.AssignVal();
            //obj.Calculate();
            //obj.Display();

            //Console.WriteLine("..................................");

            //int i = 75;
            //float f = 53.005f;
            //double d = 2345.7652;
            //bool b = true;

            //Console.WriteLine(i.ToString());
            //Console.WriteLine(f.ToString());
            //Console.WriteLine(d.ToString());
            //Console.WriteLine(b.ToString());

            //Console.WriteLine("..................................");

            //Demo1 dobj = new Demo1();
            //dobj.EscapeSequence();

            //AccessExample aobj = new AccessExample();
            //aobj.PublicExample();
            //aobj.PrivateExample();
            //aobj.InternalExample();
            ////aobj.age = 21;
            ////var empage = aobj.age; we can't access them,because it is private
            //var company = aobj.companyname;
            //Console.WriteLine("Welcome to {0} ",company);
            //aobj.length = 4.5;
            //aobj.width = 3.5;
            //aobj.Display();
            ////aobj.GetArea();
            //aobj.Myfun();
            ////Console.WriteLine(aobj.password);
            //NullExample.Mynullfun();

        }
    }
}
