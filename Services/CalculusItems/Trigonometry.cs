using System;

namespace GeomLAB.Services
{
    public class Trigonometry
    {
        private float NumValue;

        public byte Rounding { get; set; }

        public Trigonometry(byte roundNum)
        {
            Rounding = roundNum;
        }

        public Trigonometry()
        {

        }

        //This Methods parameters in radians.
        public float Sin(float x)
        {
            if (Rounding == 0)
            {
                Rounding = 3;
            }

            NumValue = 0;
            float Factorian;

            if (x <= 10 && x >= -10)
            {
                for (float i = 0; i < 20; i++)
                {
                    Factorian = 1;

                    for (float j = 1; j <= 2 * i + 1; j++)
                    {
                        Factorian *= j;
                    }

                    NumValue += (float)(Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorian);
                }
            }
            else
            {
                string degree = (x * 180 / Math.PI).ToString();

                NumValue = Sin(degree);
            }

            return (float)Math.Round(NumValue, Rounding);
        }

        public float Cos(float x)
        {
            if (Rounding == 0)
            {
                Rounding = 3;
            }

            NumValue = 0;
            float Factorian;

            if (x <= 10 && x >= -10)
            {
                for (float i = 0; i < 20; i++)
                {
                    Factorian = 1;

                    for (float j = 1; j <= 2 * i; j++)
                    {
                        Factorian *= j;
                    }

                    NumValue += (float)(Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorian);
                }
            }
            else
            {
                string degree = (x * 180 / Math.PI).ToString();

                NumValue = Cos(degree);
            }

            return (float)Math.Round(NumValue, Rounding);
        }

        public float Tan(float x)
        {
            if (Rounding == 0)
            {
                Rounding = 3;
            }

            NumValue = Sin(x) / Cos(x);

            return (float)Math.Round(NumValue, Rounding);
        }

        public float Cot(float x)
        {
            if (Rounding == 0)
            {
                Rounding = 3;
            }

            NumValue = Cos(x) / Sin(x);

            return (float)Math.Round(NumValue, Rounding);
        }

        public float Sec(float x)
        {
            if (Rounding == 0)
            {
                Rounding = 3;
            }

            NumValue = 1 / Cos(x);

            return (float)Math.Round(NumValue, Rounding);
        }

        public float Cosec(float x)
        {
            if (Rounding == 0)
            {
                Rounding = 3;
            }

            NumValue = 1 / Sin(x);

            return (float)Math.Round(NumValue, Rounding);
        }

        //This Methods parametrs on degree
        public float Sin(string degree)
        {
            if (int.TryParse(degree, out int numdegree))
            {
                if (numdegree > 360)
                {
                    numdegree %= 180;
                }

                NumValue = Sin((float)(numdegree * Math.PI / 180));
            }
            else
            {
                NumValue = float.MinValue;
            }

            return NumValue;
        }

        public float Cos(string degree)
        {
            if (int.TryParse(degree, out int numdegree))
            {
                if (numdegree > 360)
                {
                    numdegree %= 180;
                }

                NumValue = Cos((float)(numdegree * Math.PI / 180));
            }
            else
            {
                NumValue = float.MinValue;
            }

            return NumValue;
        }

        public float Tan(string degree)
        {
            NumValue = Sin(degree) / Cos(degree);

            return NumValue;
        }

        public float Cot(string degree)
        {
            NumValue = Cos(degree) / Sin(degree);

            return NumValue;
        }

        public float Sec(string degree)
        {
            NumValue = 1 / Cos(degree);

            return NumValue;
        }

        public float Cosec(string degree)
        {
            NumValue = 1 / Sin(degree);

            return NumValue;
        }
    }
}
