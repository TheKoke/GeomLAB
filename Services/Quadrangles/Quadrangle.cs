using System;
using System.Linq;

namespace GeomLAB.services.Quadrangles
{
    public abstract class Quadrangle : IFigure
    {
        /// <summary>
        /// Lengths of Sides of Quadrangle.
        /// </summary>
        public float[] Sides { get; protected set; }

        /// <summary>
        /// Angles of Quadrangle.
        /// </summary>
        public string[] Angles { get; protected set; }

        /// <summary>
        /// Heights of Quadrangle.
        /// </summary>
        public float[] Heights { get; protected set; }

        /// <summary>
        /// Diagonales of Quagrangle.
        /// </summary>
        public float[] Diagonales { get; protected set; }

        /// <summary>
        /// Radius of Circumscribed Circle of a this Quadrangle.
        /// </summary>
        public float CircumscribedRadius { get; protected set; }

        /// <summary>
        /// Radius of Inscribed Circle of a this Quadrangle.
        /// </summary>
        public float InscribedRadius { get; protected set; }

        public Quadrangle()
        {
            Sides = new float[4];
            Angles = new string[4];
            Heights = new float[4];
            Diagonales = new float[2];
        }

        /// <summary>
        /// Returns the Shlafli Symbol of this Quadrangle.
        /// </summary>
        /// <returns></returns>
        public string ShlaflySymbol()
        {
            return string.Concat("{", $"{CountOfCorners()}", "}");
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
        /// Set heights of this Quadrangle.
        /// </summary>
        protected abstract void SetHeights();

        /// <summary>
        /// Set the diagonales of this Quadrangle
        /// </summary>
        protected abstract void SetDiagonales();

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Quadrangle
        /// </summary>
        protected abstract void SetRadiuses();

        /// <summary>
        /// Find the perimeter of this Quadrangle.
        /// </summary>
        /// <returns></returns>
        public float Perimeter()
        {
            return Sides.Sum();
        }

        /// <summary>
        /// Return Count of Corners of this Figure.
        /// </summary>
        /// <returns></returns>
        public int CountOfCorners()
        {
            return 4;
        }

        /// <summary>
        /// Finds the Area of this Quadrangle
        /// </summary>
        /// <returns></returns>
        public abstract float Area();
    }
}
