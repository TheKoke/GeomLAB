using System;
using System.Linq;

namespace GeomLAB.services.Quadrangles
{
    public class ArbitraryQuadrangle : Quadrangle
    {
        public ArbitraryQuadrangle() : base()
        {

        }

        public ArbitraryQuadrangle(float[] sides, string[] angles) : this()
        {
            if (Array.ConvertAll(angles, int.Parse).Sum() == 360)
            {
                Array.Copy(sides, Sides, Sides.Length);
                Array.Copy(angles, Angles, Angles.Length);
            }

            SetHeights();
            SetDiagonales();
            SetRadiuses();
        }

        /// <summary>
        /// Set heights of this Quadrangle.
        /// </summary>
        protected override void SetHeights()
        {
            for (int i = 0; i < Heights.Length; i++)
            {
                if (i == 0 || i == 3)
                {
                    Heights[i] = Sides[MapperForIndex(i)] * new Trigonometry(5).Sin(Angles[0]);
                }
                else
                {
                    Heights[i] = Sides[MapperForIndex(i)] * new Trigonometry(5).Sin(Angles[2]);
                }
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
        /// Set the diagonales of this Quadrangle
        /// </summary>
        protected override void SetDiagonales()
        {
            for (int i = 0; i < Diagonales.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[0], Sides[1], Angles[1]);
                }
                else
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[1], Sides[2], Angles[2]);
                }
            }
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Quadrangle
        /// </summary>
        protected override void SetRadiuses()
        {
            if (Sides[1] + Sides[3] == Sides[0] + Sides[2])
            {
                InscribedRadius = Heights[3] / 2;
            }

            if (int.Parse(Angles[0]) + int.Parse(Angles[2]) == 180)
            {
                CircumscribedRadius = Diagonales[Array.IndexOf(Diagonales, Diagonales.Max())] / 2;
            }
        }

        /// <summary>
        /// Find the area of this Quadrangle
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            float formulaConst = 1;
            float multiply = 1;

            for (int i = 0; i < Sides.Length; i++)
            {
                formulaConst *= Perimeter() / 2 - Sides[i];
                multiply *= Sides[i];
            }

            string sumOfAngles = (int.Parse(Angles[1]) + int.Parse(Angles[3])).ToString();

            return (float)Math.Sqrt(formulaConst - multiply * Math.Pow(new Trigonometry(5).Cos(sumOfAngles), 2));
        }
    }
}
