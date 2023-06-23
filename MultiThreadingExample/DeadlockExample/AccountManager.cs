using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeadlockExample
{
    class AccountManager
    {
        Account _fromaccount;
        Account _toaccount;
        double _amounttransfer;
        public AccountManager(Account fromaccount,Account toaccount,double amounttransfer)
        {
            this._fromaccount = fromaccount;
            this._toaccount = toaccount;
            this._amounttransfer = amounttransfer;
        }
        public void transfer()
        {
            //Deadlock acquired
            //now deadlock is resolved using if-else block
            object _lock1, _lock2;
            if(_fromaccount.ID<_toaccount.ID)
            {
                _lock1 = _fromaccount;
                _lock2 = _toaccount;
            }
            else
            {
                _lock1 = _toaccount;
                _lock2 = _fromaccount;
            }
            //Console.WriteLine(Thread.CurrentThread.Name+ " Trying to Acquire a lock on "+_fromaccount.ID.ToString());
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to Acquire a lock on " + ((Account)_lock1).ID.ToString());
            Thread.Sleep(1000);
            //lock (_fromaccount)
            lock (_lock1)
            {
                //Console.WriteLine(Thread.CurrentThread.Name + " Acquired lock on " + _fromaccount.ID.ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " Trying to Acquire a lock on " + ((Account)_lock1).ID.ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " Suspended for one second");
                Thread.Sleep(1000);
                //Console.WriteLine(Thread.CurrentThread.Name + " Back in Action trying to acquire lock on "+_toaccount.ID.ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " Trying to Acquire a lock on " + ((Account)_lock2).ID.ToString());
                //lock (_toaccount)
                lock (_lock2)
                {
                    //Console.WriteLine("this code will not be executed");
                    Console.WriteLine(Thread.CurrentThread.Name + " Trying to Acquire a lock on " + ((Account)_lock2).ID.ToString());
                    _fromaccount.WithDraw(_amounttransfer);
                    _toaccount.Deposit(_amounttransfer);
                    Console.WriteLine(Thread.CurrentThread.Name+ "Transfered "+ _amounttransfer.ToString() + " From "+
                        _fromaccount.ID.ToString()+ " to "+_toaccount.ID.ToString());
                }
            }
        }
    }
}
