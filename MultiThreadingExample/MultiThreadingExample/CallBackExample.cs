using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadingExample
{
    class CallBackExample
    {
        private int _target;
        SumOfNumbersCallBack _callBackMethod;
        public CallBackExample(int target, SumOfNumbersCallBack CallBackMethod)
        {
            this._target = target;
            this._callBackMethod = CallBackMethod;
        }

        public void SumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i <= _target; i++)
            {
                sum += i;
            }
            if (_callBackMethod != null)
            {
                _callBackMethod(sum);
            }
        }
    }
}
