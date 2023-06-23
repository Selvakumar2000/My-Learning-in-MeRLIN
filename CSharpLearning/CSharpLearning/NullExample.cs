using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning
{
    class NullExample
    {
        public static void Mynullfun()
        {
            int? num1 = null;
            int? num2 = 45;

            double? num3 = new double?();
            double? num4 = 3.14157;

            bool? boolval = new bool?();

            // display the values
            Console.WriteLine("Nullables at Show: {0}, {1}, {2}, {3}", num1, num2, num3, num4);
            Console.WriteLine("A Nullable boolean value: {0}", boolval);

            /*
             * Null Coalescing Operator (??)
If the value of the first operand is null, then the operator returns the value of the second operand, 
otherwise it returns the value of the first operand.
             */
            double? mnum1 = null;
            double? mnum2 = 3.14157;
            double mnum3;

            mnum3 = mnum1 ?? 5.34;
            Console.WriteLine(" Value of num3: {0}", mnum3);

            mnum3 = mnum2 ?? 5.34;
            Console.WriteLine(" Value of num3: {0}", mnum3);
        }
    }
}
