using System;
using System.Collections.Generic;

namespace GeomLAB.services
{
    public static class ArithmeticMethods
    {
        public static int[] GetFactors(int number)
        {
            List<int> result = new();

            while (number % 2 == 0)
            {
                result.Add(2);

                number /= 2;
            }

            for (byte i = 3; i <= Math.Sqrt(number); i += 2)
            {
                while (number % i == 0)
                {
                    result.Add(i);
                    number /= i;
                }
            }

            if (number > 2)
            {
                result.Add(number);
            }

            return result.ToArray();
        }

        private static int[] GetCommonFactor(int[] First, int[] Second)
        {
            if (First is null || Second is null)
            {
                return Array.Empty<int>();
            }

            if (First == Array.Empty<int>())
            {
                return Second;
            }

            if (Second == Array.Empty<int>())
            {
                return First;
            }

            List<int> result = new();

            for (byte i = 0; i < First.Length; i++)
            {
                if (Array.IndexOf(Second, First[i]) != -1)
                {
                    result.Add(First[i]);
                }
            }

            return result.ToArray();
        }

        public static int[] GetCommonFactor(params int[][] Factors)
        {
            if (Factors is null)
            {
                return Array.Empty<int>();
            }

            int[] result = Array.Empty<int>();

            for (byte i = 0; i < Factors.Length; i++)
            {
                result = GetCommonFactor(result, Factors[i]);
            }

            return result;
        }
    }
}
