using System;
using System.Collections.Generic;
using System.Text;

namespace AnonymousMethodWorking
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //step 1
        public static bool FindEmployee(Employee emp)
        {
            return emp.ID == 102;
        }
    }
}
