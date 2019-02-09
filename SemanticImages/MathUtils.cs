using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticImages
{
    public static class MathUtils
    {
        /// <summary>
        /// Finds the greatest common divisor of two integers.
        /// </summary>
        /// <param name="a">is the first integer</param>
        /// <param name="b">is the second integer</param>
        /// <returns>the greatest common divisor of two integers</returns>
        public static int GreatestCommonDivisor(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;

                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
    }
}
