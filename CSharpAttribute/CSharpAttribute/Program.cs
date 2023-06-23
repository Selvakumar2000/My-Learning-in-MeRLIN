using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpAttribute
{
    class Program
    {
/*
Attributes:
Allows us to add declarative information to our methods,classes,properties.This information can be queried during runtime.
Obsolete     -> marks types and type members outdated
WebMethod    -> to expose a method as an xml webservice method
Serializable -> indicated that the class can be serialized
*/
        static void Main(string[] args)
        {
            //Attribute
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                     where t.GetCustomAttributes<AttributeExample>().Count() > 0
                     select t;

            foreach (var t in types)
            {
                Console.WriteLine(t.Name);

                foreach (var p in t.GetProperties())
                {
                    Console.WriteLine(p.Name);
                }
            }

            Console.WriteLine("Hello World!");
            //Attribute Example -- Obselete
            ObseleteExample.AddFun(10, 20);
            ObseleteExample.AddFun(10, 20, 30);
            //the above two methods are used by users for a long time..
            //if user want to add 5 numbers,we must write another using advanced concepts like list or params
            //if i remove those two overrided method in my class,it throws compilation error here,instead we provide it as onsolete
            ObseleteExample.AddMoreNumbers(new List<int>(){10,20,20,30,10,230 });
            ObseleteExample.AddFun(10, 20);

            //Reflection
            /*
            Reflection objects are used for obtaining type information at runtime.
            The classes that give access to the metadata of a running program are in the System.Reflection namespace.
            */
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("Assembly Name:{0}",assembly.FullName);

            var types1 = assembly.GetTypes();
            foreach (var type in types1)
            {
                Console.WriteLine("type name:" + type.Name);

                var props = type.GetProperties();
                foreach (var prop in props)
                {
                    Console.WriteLine("PropertyName:" + prop.Name);
                }

                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine("FieldName:" + field.Name);
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("MethodName:" + method.Name);
                }
            }
            AttributeExample obj = new AttributeExample { Name="SK",Age=23};
            Console.WriteLine("...............");
            Console.WriteLine(obj);

            Console.WriteLine("...............");
            //Generics
            var res1 = new GenericsExample<int, string> { Success = true, Data1 = 12, Data2 = 32, Data3 = "Selva" };
            var res2 = new GenericsExample<int, int> { Success = true, Data1 = 42, Data2 = 52, Data3 =84 };
            Console.WriteLine(res1);
            Console.WriteLine(res1);
            Console.WriteLine("...............");

            //Delegate Example
            MyDelegate del = DelegateExample.Hello;
            //del.Invoke();
            //del("selva");
            //DelegateExample.Hello();
            DelegateExample.Test(del);
            
            Operation op = DelegateExample.Double;
            //delegate chaining
            op = op + DelegateExample.Triple;
            op = op + DelegateExample.Triple;
            op = op + DelegateExample.Triple;
            op = op + DelegateExample.Double;
            op = op + DelegateExample.Double;
            op = op + DelegateExample.Double;
            op = op - DelegateExample.Double;
            //DelegateExample.ExecuteOperation(2,op);
            //Operation op2 = DelegateExample.Triple;
            //DelegateExample.ExecuteOperation(2, op2);
            DelegateExample.ExecuteOperation(2, op);
        }
    }
}
