using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSpecial
{
    /*
1)In C#, a structure is a value type data type. It helps you to make a single variable hold related data of various data types. 
The struct keyword is used for creating a structure.

2)classes are reference types and structs are value types
  structures do not support inheritance
  structures cannot have default constructor
  structure can implement one or more interfaces.
     */

    struct Books
    {
        public string title, author, subject;
        public int book_id;
        public void getValues(string t, string a, string s, int id)
        {
            title = t;
            author = a;
            subject = s;
            book_id = id;
        }

        public void display()
        {
            Console.WriteLine("Title : {0}", title);
            Console.WriteLine("Author : {0}", author);
            Console.WriteLine("Subject : {0}", subject);
            Console.WriteLine("Book_id :{0}", book_id);
        }
    };
    class StructureExample
    {

    }
}
