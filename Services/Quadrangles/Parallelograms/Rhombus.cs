using System;

namespace GeomLAB.Services.Quadrangles
{
    public class Rhombus : Parallelogram
    {
        public Rhombus() : base()
        {

        }

        public Rhombus(float a, string bigangle, string smallangle) : this()
        {
            if (int.Parse(bigangle) + int.Parse(smallangle) == 180)
            {
                BigAngle = bigangle;
                SmallerAngle = smallangle;

                for (byte i = 0; i < Sides.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Angles[i] = smallangle;
                    }
                    else
                    {
                        Angles[i] = bigangle;
                    }

                    Sides[i] = a;
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
                Diagonales[i] = Sides[i] * (1 - new Trigonometry(5).Sin(SmallerAngle));
            }
        }

        /// <summary>
        /// Set the heights of this Parrallelogram
        /// </summary>
        protected override void SetHeights()
        {
            base.SetHeights();
        }

        /// <summary>
        /// Find the area of this Parallelogram
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            return Sides[0] * Sides[0] * new Trigonometry(5).Sin(SmallerAngle);
        }
    }
}
