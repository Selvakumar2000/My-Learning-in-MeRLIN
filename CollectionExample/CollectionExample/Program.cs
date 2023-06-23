using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer() { ID = 101, Name = "Selva", Salary = 20000 };
            Customer customer2 = new Customer() { ID = 102, Name = "Wasim", Salary = 25000 };
            Customer customer3 = new Customer() { ID = 103, Name = "Surya", Salary = 30000 };
            
            //Dictionary
            DictionaryExample.DictionaryWorking(customer1, customer2, customer3);

            //List
            ListandSorting.ListWorking(customer1, customer2, customer3);

        }
    }

}
