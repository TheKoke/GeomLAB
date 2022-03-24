using System;
using System.Linq;

namespace GeomLAB.services.Quadrangles
{
    public class Rectangle : Parallelogram
    {
        public Rectangle() : base()
        {
            Angles = new string[4] { "90", "90", "90", "90" };
        }

        public Rectangle(float length, float width) : this()
        {
            for (int i = 0; i < Sides.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Sides[i] = width;
                }
                else
                {
                    Sides[i] = length;
                }
            }

            SetHeights();
            SetDiagonales();
            SetRadiuses();
        }

        /// <summary>
        /// Set the heights of this Rectangle
        /// </summary>
        protected override void SetHeights()
        {
            Array.Copy(Sides, Heights, 4);
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Rectangle
        /// </summary>
        protected override void SetRadiuses()
        {
            InscribedRadius = 0;

            CircumscribedRadius = Diagonales[0] / 2;
        }

        /// <summary>
        /// Set the diagonales of this Rectangle
        /// </summary>
        protected override void SetDiagonales()
        {
            for (int i = 0; i < Diagonales.Length; i++)
            {
                Diagonales[i] = (float)Math.Sqrt(Math.Pow(Sides[i], 2) + Math.Pow(Sides[i + 1], 2));
            }
        }

        /// <summary>
        /// Find the area of this Rectangle
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            return Sides[0] * Sides[1];
        }
    }
}
