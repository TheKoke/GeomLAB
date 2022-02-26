using System;

namespace GeomLAB.services.Quadrangles
{
    public class Square : Rectangle
    {
        public Square() : base()
        {

        }

        public Square(float a) : this()
        {
            for (byte i = 0; i < Sides.Length; i++)
            {
                Sides[i] = a;
            }

            SetHeights();
            SetDiagonales();
        }

        /// <summary>
        /// Set the heights of this Square
        /// </summary>
        protected override void SetHeights()
        {
            base.SetHeights();
        }

        /// <summary>
        /// Set the diagonales of this Square
        /// </summary>
        protected override void SetDiagonales()
        {
            for (byte i = 0; i < Diagonales.Length; i++)
            {
                Diagonales[i] = Sides[i] * (float)Math.Sqrt(2);
            }
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Square
        /// </summary>
        protected override void SetRadiuses()
        {
            InscribedRadius = Sides[0] / 2;
            CircumscribedRadius = Diagonales[0] / 2;
        }

        public override float Area()
        {
            return (float)Math.Pow(Sides[0], 2);
        }
    }
}
