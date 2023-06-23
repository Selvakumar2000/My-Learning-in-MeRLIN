using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionExample
{
    public class Customer : IComparable<Customer>  //now eligible for comparision
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return "[" + ID + " " + Name + " " + Salary + "]";
        }

        public int CompareTo(Customer cust)
        {
            if (this.Salary > cust.Salary)
                return 1;
            else if (this.Salary < cust.Salary)
                return -1;
            else //both are same
                return 0;
        }
    }
}
