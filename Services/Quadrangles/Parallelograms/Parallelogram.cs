using System;

namespace GeomLAB.services.Quadrangles
{
    public class Parallelogram : Quadrangle
    {
        public string BigAngle { get; protected set; }
        public string SmallerAngle { get; protected set; }

        public Parallelogram() : base()
        { }

        public Parallelogram(float longSide, float shortSide, string bigangle, string smallerangle) : this()
        {
            if (int.Parse(bigangle) + int.Parse(smallerangle) == 180 && longSide > shortSide)
            {
                BigAngle = bigangle;
                SmallerAngle = smallerangle;

                for (byte i = 0; i < Sides.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Sides[i] = shortSide;
                        Angles[i] = SmallerAngle;
                    }
                    else
                    {
                        Sides[i] = longSide;
                        Angles[i] = BigAngle;
                    }
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
                if (i % 2 == 0)
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[i], Sides[i + 1], SmallerAngle);
                }
                else
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[i], Sides[i + 1], BigAngle);
                }
            }
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Parallelogram
        /// </summary>
        protected override void SetRadiuses()
        {
            InscribedRadius = 0;

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

        private static int MapperForIndex(int index) => index switch
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
