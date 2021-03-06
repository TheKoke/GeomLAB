using System;
using System.Linq;

namespace GeomLAB.services
{
    public class Polygon : IFigure
    {
        /// <summary>
        /// bool field mains is this polygon are regular.
        /// </summary>
        private bool IsRegular;

        /// <summary>
        /// Lengths of sides this polygon.
        /// </summary>
        public float[] Sides { get; private set; }

        public float[] Diagonales { get; private set; }

        /// <summary>
        /// Number of sides or angles.
        /// </summary>
        public byte AnglesNum { get; set; }

        public Polygon()
        { }

        public Polygon(byte angles)
        {
            if (angles >= 5)
            {
                AnglesNum = angles;
                Sides = new float[angles];
            }
        }

        public Polygon(byte angles, bool IsRegular, params float[] SideLengths) : this(angles)
        {
            this.IsRegular = IsRegular;

            if (this.IsRegular)
            {
                for (int i = 0; i < Sides.Length; i++)
                {
                    Sides[i] = SideLengths[0];
                }

                SetDiagonales();
            }
            else
            {
                for (int i = 0; i < Sides.Length; i++)
                {
                    Sides[i] = SideLengths[i];
                }
            }
        }

        private string DegreeSum()
        {
            return (180 * (AnglesNum - 2)).ToString();
        }

        private string RightDegree()
        {
            return (int.Parse(DegreeSum()) / AnglesNum).ToString();
        }

        /// <summary>
        /// Set the Diagonales lengths of this Polygone.
        /// </summary>
        private void SetDiagonales()
        {
            if (IsRegular)
            {
                Diagonales = new float[AnglesNum * ((AnglesNum - 3) / 2)];

                for (int i = 0; i < Diagonales.Length; i++)
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[0], Sides[1], RightDegree());
                }
            }
        }

        /// <summary>
        /// Returns the Shlafli Symbol of this Polygon.
        /// </summary>
        /// <returns></returns>
        public string ShlaflySymbol()
        {
            return string.Concat("{", $"{CountOfCorners()}", "}");
        }

        /// <summary>
        /// Find the perimeter of this polygon.
        /// </summary>
        /// <returns></returns>
        public float Perimeter()
        {
            return Sides.Sum();
        }

        /// <summary>
        /// Returns count of corners this Figure
        /// </summary>
        /// <returns></returns>
        public int CountOfCorners()
        {
            return AnglesNum;
        }

        /// <summary>
        /// Returns lengths of sides of this Figure.
        /// </summary>
        /// <returns></returns>
        public float[] GetSides()
        {
            return Sides;
        }

        /// <summary>
        /// Returns leghts of Diagonales of this Figure.
        /// </summary>
        /// <returns></returns>
        public float[] GetDiagonales()
        {
            return Diagonales;
        }

        /// <summary>
        /// Find the area of this Polygon.
        /// </summary>
        /// <returns></returns>
        public float Area()
        {
            if (IsRegular)
            {
                return AnglesNum / 4 * (float)Math.Pow(Sides[0], 2) * new Trigonometry(5).Cot((float)Math.PI / AnglesNum);
            }
            else
            {
                return uint.MaxValue;
            }
        }
    }
}
