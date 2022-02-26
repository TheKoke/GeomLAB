using System;

namespace GeomLAB.services
{
    public class InverseTrigonometry
    {
        //Fields for use in class methods
        private long doubleFactorial;
        private float NumValue;

        public byte Rounding { get; set; }

        public InverseTrigonometry()
        {

        }

        public InverseTrigonometry(byte roundNum)
        {
            Rounding = roundNum;
        }

        private float GetDoubleFactorial(float x)
        {
            long factorial;

            if (x % 2 == 0)
            {
                factorial = 1;

                for (int i = 1; i <= x / 2; i++)
                {
                    factorial *= i;
                }

                doubleFactorial = (long)(Math.Pow(2, x / 2) * factorial);
            }
            else
            {
                factorial = 1;

                for (int i = 1; i <= x; i++)
                {
                    factorial *= i;
                }

                int secondFactorial = 1;

                for (int i = 1; i <= (x - 1) / 2; i++)
                {
                    secondFactorial *= i;
                }

                doubleFactorial = (long)(factorial / (Math.Pow(2, (x - 1) / 2) * secondFactorial));
            }

            return doubleFactorial;
        }

        public float Arcsin(float x)
        {
            NumValue = x;

            if (x >= -1 && x <= 1)
            {
                for (float i = 1; i <= 20; i++)
                {
                    NumValue += (float)(GetDoubleFactorial(2 * i - 1) * Math.Pow(x, 2 * i + 1) / (GetDoubleFactorial(2 * i) * (2 * i + 1)));
                }
            }
            else
            {
                NumValue = float.MinValue;
            }

            return NumValue;
        }

        public float Arccos(float x)
        {
            if (x >= -1 && x <= 1)
            {
                NumValue = (float)Math.PI / 2 - Arcsin(x);
            }
            else
            {
                NumValue = float.MinValue;
            }

            return NumValue;
        }

        public float Arctan(float x)
        {
            NumValue = 0;

            if (x >= -1 && x <= 1)
            {
                for (float i = 0; i <= 15; i++)
                {
                    NumValue += (float)(Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (1 + 2 * i));
                }
            }
            else
            {
                NumValue = (float)Math.PI / 2;

                for (double i = 0; i <= 15; i++)
                {
                    NumValue -= (float)(Math.Pow(-1, i) * Math.Pow(x, -1 - 2 * i) / (1 + 2 * i));
                }
            }

            return NumValue;
        }

        public float Arccot(float x)
        {
            return (float)Math.PI - Arctan(x);
        }

        public static string ToDegree(float radians)
        {
            radians = (float)(radians * 180 / Math.PI);

            if (radians - (int)radians <= 0)
            {
                return radians.ToString();
            }

            string result = $"{(int)radians}*";

            for (int i = 0; i < 2; i++)
            {
                radians -= (int)radians;
                result = string.Concat(result, $" {(int)(radians * 60)}{new string('\'', i + 1)}");

                radians *= 60;
            }

            return result;
        }
    }
}
