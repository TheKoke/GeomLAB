using System;
using System.Linq;

namespace GeomLAB.Services
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
        {

        }

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

                for (byte i = 0; i < Diagonales.Length; i++)
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(Sides[0], Sides[1], RightDegree());
                }
            }
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
        public byte CountOfCorners()
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
            float result;

            if (IsRegular)
            {
                result = (float)(AnglesNum / 4 * Math.Pow(Sides[0], 2) * new Trigonometry(3).Cot((float)Math.PI / AnglesNum));
            }
            else
            {
                result = uint.MaxValue;
            }

            return result;
        }
    }
}
