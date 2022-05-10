using System;
using GeomLAB.services.Quadrangles;

namespace GeomLAB.services.Prisms
{
    // <summary>
    /// This class of Uniform or Semi-Regular Polyhedron.
    /// </summary>
    public class Uniform : Prism
    {
        public Uniform() : base()
        {

        }

        public Uniform(IFigure basic) : this()
        {
            Base = basic;
            LateralFace = new Square(Base.GetSides()[0]);

            Height = Base.GetSides()[0];
            LateralRibs = Height;
        }

        /// <summary>
        /// Set the diagonales of this Uniform Polyhedron.
        /// </summary>
        protected override void SetDiagonales()
        {
            for (byte i = 0; i < Base.GetDiagonales().Length; i++)
            {
                for (byte j = 1, k = (byte)(i * 2); j <= 2; j++, k++)
                {
                    Diagonales[k] = (float)Math.Sqrt(Math.Pow(Base.GetDiagonales()[i], 2) + Math.Pow(Height, 2));
                }
            }
        }

        /// <summary>
        /// Find the Area of Side Surface of this Uniform Polyhedron.
        /// </summary>
        /// <returns></returns>
        public override float SideSurfaceArea()
        {
            return Base.CountOfCorners() * LateralFace.Area();
        }

        /// <summary>
        /// Find the Volume of this Semi-Regular Polyhedron.
        /// </summary>
        /// <returns></returns>
        public override float Volume()
        {
            return Base.Area() * Height;
        }
    }
}
