using System;
using System.Linq;

namespace GeomLAB.Services
{
    public interface IFigure
    {
        // public void ParseToGraph(); - later

        // public Point[] ShowCoordinates(another CoordinateSystem object); - later

        /// <summary>
        /// Returns lengths of sides of this Figure.
        /// </summary>
        /// <returns></returns>
        public float[] GetSides();

        /// <summary>
        /// Returns leghts of Diagonales of this Figure.
        /// </summary>
        /// <returns></returns>
        public float[] GetDiagonales();

        /// <summary>
        /// Return count of Corners of this Figure.
        /// </summary>
        /// <returns></returns>
        public byte CountOfCorners();

        /// <summary>
        /// Method Perimeter.
        /// </summary>
        /// <returns>Perimeter of this Figure</returns>
        public float Perimeter();

        /// <summary>
        /// Method Area.
        /// </summary>
        /// <returns>Area of this Figure</returns>
        public float Area();
    }
}
