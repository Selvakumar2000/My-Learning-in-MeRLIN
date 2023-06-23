using System;

namespace CSharpSpecial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //accessing structure
            Books book1;
            Books book2;

            book1.title = "Learn C#";
            book1.author = "selvakumar";
            book1.subject = "programming";
            book1.book_id = 1;

            book2.title = "Learn Angular";
            book2.author = "wasim";
            book2.subject = "programming";
            book2.book_id = 2;

            /* print book1 info */
            Console.WriteLine("Book 1 title : {0}", book1.title);
            Console.WriteLine("Book 1 author : {0}", book1.author);
            Console.WriteLine("Book 1 subject : {0}", book1.subject);
            Console.WriteLine("Book 1 book_id :{0}", book1.book_id);
            Console.WriteLine();

            /* print book2 info */
            Console.WriteLine("Book 2 title : {0}", book2.title);
            Console.WriteLine("Book 2 author : {0}", book2.author);
            Console.WriteLine("Book 2 subject : {0}", book2.subject);
            Console.WriteLine("Book 2 book_id : {0}", book2.book_id);
            Console.WriteLine();

            /* book 1 specification */
            book1.getValues("C Programming",
            "Nuha Ali", "C Programming Tutorial", 6495407);

            /* book 2 specification */
            book2.getValues("Telecom Billing",
            "Zara Ali", "Telecom Billing Tutorial", 6495700);

            /* print Book1 info */
            book1.display();
            Console.WriteLine();

            /* print Book2 info */
            book2.display();
            Console.WriteLine();

            OopsExample obj = new OopsExample(52, 162);
            obj.display();

            //Encapsulation
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            obj.setName(name);
            Console.WriteLine(obj.getName());
            obj.setAge(age);
            Console.WriteLine(obj.getAge());

            //static example
            StaticExample s1 = new StaticExample();
            StaticExample s2 = new StaticExample();

            s1.count();
            s1.count();
            s1.count();

            s2.count();
            s2.count();
            s2.count();

            Console.WriteLine("Variable num for s1: {0}", s1.getNum());
            Console.WriteLine("Variable num for s2: {0}", s2.getNum());

            //Inheritance Example
            Rectangle Rect = new Rectangle();

            Rect.setWidth(5);
            Rect.setHeight(7);

            // Print the area of the object.
            Console.WriteLine("Total area: {0}", Rect.getArea());

            //Inheritance Example 2
            Tabletop t = new Tabletop(4.5, 7.5);
            t.Display();
            Console.ReadLine();
        }
    }
}
