using System;
using System.Collections.Generic;
using System.Text;

namespace DeadlockExample
{
    public class Account
    {
        private double _balance;
        private int _id;
        public Account(int id,double balance)
        {
            this._id = id;
            this._balance = balance;
        }
        public int ID { get { return _id; } }
        public void WithDraw(double amount)
        {
            _balance -= amount;
        }
        public void Deposit(double amount)
        {
            _balance += amount;
        }
    }
}
