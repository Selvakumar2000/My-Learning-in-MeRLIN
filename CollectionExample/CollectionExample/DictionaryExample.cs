using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionExample
{
    class DictionaryExample
    {
        public static void DictionaryWorking(Customer customer1, Customer customer2, Customer customer3)
        {
            Dictionary<int, Customer> DictionaryCustomers = new Dictionary<int, Customer>();
            DictionaryCustomers.Add(customer1.ID, customer1);
            DictionaryCustomers.Add(customer2.ID, customer2);
            DictionaryCustomers.Add(customer3.ID, customer3);
            //avoid duplicate key insertion
            if (!(DictionaryCustomers.ContainsKey(customer1.ID)))
            {
                DictionaryCustomers.Add(customer1.ID, customer1);
            }
            //Customer cust1 = DictionaryCustomers[111];
            //retrive a key only if it is available,if not don't do
            if (DictionaryCustomers.ContainsKey(111))
            {
                Customer cust2 = DictionaryCustomers[111];
            }

            //Console.WriteLine(customer1);
            foreach (KeyValuePair<int, Customer> customerKeyvaluePair in DictionaryCustomers)
            {
                Console.WriteLine("ID ={0}", customerKeyvaluePair.Key);
                Customer cust = customerKeyvaluePair.Value;
                Console.WriteLine("ID = {0} , Name = {1} , Salary = {2} ", cust.ID, cust.Name, cust.Salary);
                Console.WriteLine("...........................................");
            }
            Console.WriteLine("....print all the keys.....");
            foreach (var key in DictionaryCustomers.Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine("....print all the values.....");
            foreach (Customer cust in DictionaryCustomers.Values)
            {
                Console.WriteLine("ID = {0} , Name = {1} , Salary = {2} ", cust.ID, cust.Name, cust.Salary);
            }

            Console.WriteLine("....Dictionary Methods.....");
            //get the dictionary values using TryGetValue(key,out values) method
            //if the key is present,their values are stored in a varible which datatype is out. 
            Customer cust1;
            if (DictionaryCustomers.TryGetValue(1001, out cust1))
            {
                Console.WriteLine("ID = {0} Name = {1} Salary = {2}", cust1.ID, cust1.Name, cust1.Salary);
            }
            else
            {
                Console.WriteLine("The Key is not found");
            }
            Console.WriteLine("Count() is a LINQ extension method");
            Console.WriteLine("Total Items of a dictionary : {0}", DictionaryCustomers.Count);
            Console.WriteLine("Total customers whose salary is greater than 20k : {0}"
                               , DictionaryCustomers.Count(kvp => kvp.Value.Salary > 20000));

            //remove based on key.if the key is not presented no exception is thrown
            Console.WriteLine(DictionaryCustomers.Remove(101));
            //clear the dictionary
            //DictionaryCustomers.Clear();
        }
    }
}
