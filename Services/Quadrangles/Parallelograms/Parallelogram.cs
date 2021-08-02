using System;
using System.Linq;

namespace GeomLAB.Services.Quadrangles
{
    public class Parallelogram : Quadrangle
    {
        public string BigAngle { get; protected set; }
        public string SmallerAngle { get; protected set; }

        public Parallelogram() : base()
        {

        }

        public Parallelogram(float longSide, float shortSide, string bigAngle, string smallerAngle) : this()
        {
            if (int.Parse(bigAngle) + int.Parse(smallerAngle) == 180 && longSide > shortSide)
            {
                BigAngle = bigAngle;
                SmallerAngle = smallerAngle;

                for (byte i = 0; i < Sides.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Sides[i] = shortSide;
                        Angles[i] = SmallerAngle;
                        continue;
                    }

                    Sides[i] = longSide;
                    Angles[i] = BigAngle;
                }

                SetHeights();
                SetDiagonales();
                SetRadiuses();
            }
        }

        /// <summary>
        /// Set the diagonales of this Parallelogram
        /// </summary>
        protected override void SetDiagonales()
        {
            for (byte i = 0; i < Diagonales.Length; i++)
            {
                Diagonales[i] = (float)Math.Pow(Sides[i], 2) + (float)Math.Pow(Sides[i + 1], 2);

                if (i % 2 == 0)
                {
                    Diagonales[i] -= 2 * Sides[i] * Sides[i + 1] * new Trigonometry(5).Cos(SmallerAngle);
                    continue;
                }

                Diagonales[i] -= 2 * Sides[i] * Sides[i + 1] * new Trigonometry(5).Cos(BigAngle);
            }
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Parallelogram
        /// </summary>
        protected override void SetRadiuses()
        {
            if (Sides.Where(x => Array.IndexOf(Sides, x) % 2 == 1).Sum() == Sides.Where(x => Array.IndexOf(Sides, x) % 2 == 0).Sum())
            {
                InscribedRadius = Heights[3] / 2;
            }

            CircumscribedRadius = 0;
        }

        /// <summary>
        /// Set the heights of this Parrallelogram
        /// </summary>
        protected override void SetHeights()
        {
            for (byte i = 0; i < Heights.Length; i++)
            {
                Heights[i] = Sides[MapperForIndex(i)] * new Trigonometry(5).Sin(SmallerAngle);
            }
        }

        private int MapperForIndex(int index) => index switch
        {
            0 => 3,
            1 => 2,
            2 => 1,
            3 => 0,
            _ => int.MaxValue
        };

        /// <summary>
        /// Find the area of this Parallelogram
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            return Sides[0] * Sides[1] * new Trigonometry(5).Sin(SmallerAngle);
        }
    }
}
