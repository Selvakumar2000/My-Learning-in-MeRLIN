using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionExample
{
    public class SortCustomerAttributes : IComparer<Customer>
    {
        public int Compare(Customer x,Customer y)
        {
            return x.Name.CompareTo(y.Name);
        }
        
    }
}
