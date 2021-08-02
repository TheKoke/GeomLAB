using System;
using System.Linq;

namespace GeomLAB.Services.Quadrangles
{
    public class Trapezoid : Quadrangle
    {
        public float[] Bases { get; protected set; }

        public float[] Legs { get; protected set; }

        public float MidSegment { get; protected set; }

        public Trapezoid() : base()
        {

        }

        public Trapezoid(float[] bases, float[] legs, string[] angles) : this()
        {
            if (Array.ConvertAll(angles, int.Parse).Sum() == 360)
            {
                Array.Copy(bases, Bases, 2);
                Array.Copy(legs, Legs, 2);

                MidSegment = Bases.Sum() / 2;

                Array.Copy(Bases, Sides, 2);
                Array.ConstrainedCopy(Legs, 0, Sides, 2, 2);

                for (byte i = 0; i < angles.Length; i++)
                {
                    string temp;
                    for (int j = 0; j < angles.Length; j++)
                    {
                        if (int.Parse(angles[i]) > int.Parse(angles[j]))
                        {
                            temp = angles[i];
                            angles[i] = angles[j];
                            angles[j] = temp;
                        }
                    }
                }

                Array.Copy(angles, Angles, 4);

                SetHeights();
                SetDiagonales();
            }
        }

        /// <summary>
        /// Set the diagonales of this Trapezoid.
        /// </summary>
        protected override void SetDiagonales()
        {
            for (byte i = 0; i < Diagonales.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[0], Sides[1], Angles[1]);
                    continue;
                }

                Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[0], Sides[3], Angles[0]);
            }
        }

        /// <summary>
        /// Set heights of this Trapezoid.
        /// </summary>
        protected override void SetHeights()
        {
            for (byte i = 0; i < Heights.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Heights[i] = Legs[0] * new Trigonometry(5).Sin(Angles[0]);
                    continue;
                }

                Heights[i] = Bases[0] * new Trigonometry(5).Sin(Angles[1]);
            }
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Trapezoid
        /// </summary>
        protected override void SetRadiuses()
        {
            if (Sides.Where(x => Array.IndexOf(Sides, x) % 2 == 1).Sum() == Sides.Where(x => Array.IndexOf(Sides, x) % 2 == 0).Sum())
            {
                InscribedRadius = Heights[3] / 2;
            }

            if (Legs[0] == Legs[1])
            {
                CircumscribedRadius = Diagonales[0] / 2;
            }
        }

        /// <summary>
        /// Find a Area of Trapezoid.
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            return Bases.Sum() * Heights[0] / 2;
        }
    }
}
