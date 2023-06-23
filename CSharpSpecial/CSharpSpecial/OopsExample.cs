using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSpecial
{
    /*
     * the default access specifier for a class type is internal. Default access for the members is private.
     *  A destructor has exactly the same name as that of the class with a prefixed tilde (~)
     *  Destructor can be very useful for releasing memory resources before exiting the program
     */
    class OopsExample
    {
        public int weight;
        public int height;
       
        public OopsExample(int weight,int height)
        {
            this.weight = weight;
            this.height = height;
        }
        //destructor
        ~ OopsExample()
        {
            Console.WriteLine("Object is being deleted");
        }
        public void display()
        {
            Console.WriteLine("{0}", height * weight);
        }

        //Encapsulation
        private string name = "selva";
        private int age = 21;
        public void setName(string name)
        {
            this.name = name;
        }

        public void setAge(int age)
        {
            this.age = age;
        }
        public string getName()
        {
            return name;
        }
        public int getAge()
        {
            return age;
        }
        
    }
}
