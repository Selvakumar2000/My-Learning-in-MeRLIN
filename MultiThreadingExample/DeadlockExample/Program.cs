using System;
using System.Threading;

namespace DeadlockExample
{
    /*Deadlock:
     * A deadlock is a condition where a program cannot access a resource it needs to continue.
     * There is a Resource 1 and Resource 2 and Thread 1 and Thread 2
     * Thread 1 currently accessing a Resource 1 and want to access Resource 2.
     * Thread2 currently accessing Resource 2 and want to access Resource 1
     * In this situation both the threads are waiting for accessing the other resource that time deadlock occurs.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");
            Account accountA = new Account(101, 5000);
            Account accountB = new Account(102, 3000);

            AccountManager accountManagerA = new AccountManager(accountA, accountB,1000);
            Thread t1 = new Thread(accountManagerA.transfer);
            t1.Name = "T1";

            AccountManager accountManagerB = new AccountManager(accountB, accountA, 2000);
            Thread t2 = new Thread(accountManagerB.transfer);
            t2.Name = "T2";

            t1.Start();
            t2.Start();
            t1.Join();t2.Join();
            Console.WriteLine("Main Completed");

        }
    }
}
