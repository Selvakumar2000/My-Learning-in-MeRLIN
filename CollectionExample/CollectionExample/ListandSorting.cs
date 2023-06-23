using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionExample
{
    public class ListandSorting
    {
        public static void ListWorking(Customer customer1, Customer customer2, Customer customer3)
        {
            List<Customer> mylist = new List<Customer>(3);
            mylist.Add(customer1);
            mylist.Add(customer2);
            mylist.Add(customer3);
            //mylist.Add(customer3); list size can be increased
            Console.WriteLine();
            foreach(var m in mylist)
            {
                Console.WriteLine(m);
            }
            //sorting customer class
            //mylist.Sort();
            mylist.Reverse();
            Console.WriteLine("Sorting based on Salary");
            foreach (var m in mylist)
            {
                Console.WriteLine(m.Salary);
            }

            //sort customer
            SortCustomerAttributes obj = new SortCustomerAttributes();
            mylist.Sort(obj);
            Console.WriteLine("Sorting based on Name");
            foreach (var m in mylist)
            {
                Console.WriteLine(m.Name);
            }

            //comparision delegate(a function pointer)
            Comparison<Customer> comparefun1 = new Comparison<Customer>(ComparebyID);
            int ComparebyID(Customer x,Customer y)
            {
                return x.ID.CompareTo(y.ID);
            }
            mylist.Sort(comparefun1);
            Console.WriteLine("\nSorting based on ID using Comparision");
            foreach (var m in mylist)
            {
                Console.WriteLine(m.ID);
            }
            Console.WriteLine(".....................................");

            /*Comparison<Customer> comparefun2 = new Comparison<Customer>(ComparebyName);
            int ComparebyName(Customer a,Customer b)
            {
                return b.Name.CompareTo(a.Name);
            }
            mylist.Sort(comparefun2);
            Console.WriteLine("\nSorting based on Name using Comparision");
            foreach (var m in mylist)
            {
                Console.WriteLine(m.Name);
            }*/
            //simplifies....
            mylist.Sort(delegate (Customer x, Customer y) { return x.Name.CompareTo(y.Name); });
            Console.WriteLine("\nSorting based on Name using Comparision");
            foreach (var m in mylist)
            {
                Console.WriteLine(m.Name);
            }
            Console.WriteLine(".....................................");
            mylist.Sort((x , y)=> { return x.Salary.CompareTo(y.Salary); });
            Console.WriteLine("\nSorting based on Salary using Comparision");
            Console.WriteLine(string.Format("Here's the list: ({0}).", string.Join(", ", mylist)));
            Console.WriteLine(".....................................");



















            //sorting alphabets and integers   "IComparable interface"
            List<int> numbers = new List<int>() {12,42,545,234,22,46,23 };
            numbers.Sort();
            Console.WriteLine("\nAscending Order:");
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
            numbers.Reverse();
            Console.WriteLine("Reverse Order:");
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }

            //sorting strings
            List<string> NameString = new List<string>() {"Selva","Surya","Wasim","Raman","Anand","Muthu" };
            NameString.Sort();
            Console.WriteLine("String Sorting:");
            foreach (var name in NameString)
            {
                Console.WriteLine(name);
            }

        }
    }
}
