using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousMethodWorking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Selva" },
                new Employee { ID = 102, Name = "Wasim" },
                new Employee { ID = 103, Name = "Surya" },
            };
            //step 2
            Predicate<Employee> pc = new Predicate<Employee>(Employee.FindEmployee);
            //step3
            Employee empdet=emplist.Find(e => Employee.FindEmployee(e));
            Console.WriteLine("ID={0}  Name={1}",empdet.ID,empdet.Name);

            //in simple just one line
            Employee details=emplist.Find(delegate(Employee x) { return x.ID == 103; });
            Console.WriteLine("ID={0}  Name={1}", details.ID, details.Name);

            //using lambda expression - more helpful in LINQ
            Employee details1 = emplist.Find(x => x.ID == 101 );
            Console.WriteLine("ID={0}  Name={1}", details1.ID, details1.Name);

            /* Func Delegate
             * Func<T,TResult> it is a generic delegate T is an input parameter and TResult is an output parameter
             * Ex:
             * Func<Employee,string> => it accepts Employee and returns a string as an output
            */
            Console.WriteLine("Using Func<T,TResult> delegate");
            //Func<Employee, string> selector = employee => "Name = "+employee.Name;
            IEnumerable<string> names = emplist.Select(employee => "Name = " + employee.Name);
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            Func<int, int, string> res = (number1, number2) => "Sum = "+(number1 + number2).ToString();
            string result = res(20, 30);
            Console.WriteLine(result);
        }
    }
}
