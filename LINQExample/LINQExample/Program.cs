using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
    /*LINQ -> Language Integrated Query
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
    from the input string,pick out only vowels and order it by ascending order.
             */
            var sample = "I love to code in CSharp programming language";
            var result = from c in sample.ToLower()
                         where c == 'a' ||c== 'e' ||c== 'i' ||c== 'o' ||c== 'u'
                         orderby c descending
                         select c;
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }

            var result1 = from c in sample.ToLower()
                         where c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
                         orderby c 
                         group c by c;

            foreach (var item in result1)
            {
                Console.WriteLine("{0} - {1}",item.Key,item.Count());
            }

            var persons = new List<Person>
            {
                new Person{FirstName="Selvakumar",LastName="Raman",Age=21 },
                new Person{FirstName="Wasim",LastName="Raja",Age=22 },
                new Person{FirstName="Surya",LastName="Sekar",Age=23 },
                new Person{FirstName="Sindhuja",LastName="Palanisamy",Age=24 },
            };

            var result2 = from person in persons
                          //where person.Age==21 
                          orderby person.FirstName ascending
                          select person;
            foreach(var res in result2)
            {
                Console.WriteLine("{0} - {1}",res.FirstName,res.LastName);
            }
        }
    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
