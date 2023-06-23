using System;
using System.Threading.Tasks;

namespace TPL_Example
{
    /*
     * Task Parallel Library - Advanced version of Threading Concept
     * Eliminate Overheaded lines of codes
     * By using Asynchronous programming, the Application can continue with the other work that does not depend on the
       completion of the entire task.
     */
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
             * 
            //Basic Example
            BasicExample.Method2();  //method 3 called only by method 2 finished it's entire process
            _ = BasicExample.Method1();  //It runs parallelly with another methods
            BasicExample.Method3();

            */


            //Dependency
            //await Dependency.CallMethod();

            //File Reading
            await FileReading.CallMethod();


        }
    }
}
