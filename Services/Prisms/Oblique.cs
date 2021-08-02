using System;
using System.Linq;
using GeomLAB.Services.Quadrangles;

namespace GeomLAB.Services.Prisms
{
    public class Oblique : Prism
    {
        public Oblique() : base()
        {

        }

        public Oblique(IFigure basic, Parallelogram sideface) : this()
        {
            Base = basic;
            LateralFace = sideface;

            LateralRibs = sideface.Sides.Min();

            Height = LateralRibs * new Trigonometry(5).Sin(sideface.Angles[0]);
        }

        /// <summary>
        /// Set the diagonales of this Oblique Prism.
        /// </summary>
        protected override void SetDiagonales()
        {
            //new triangle of base diagonals, latarel ribe and this.diagonal
        }

        /// <summary>
        /// Find the Area of Side Surface of this Oblique Prism.
        /// </summary>
        /// <returns></returns>
        public override float SideSurfaceArea()
        {
            return LateralFace.Area() * Base.CountOfCorners();
        }

        /// <summary>
        /// Find the Volume of this Oblique Prism.
        /// </summary>
        /// <returns></returns>
        public override float Volume()
        {
            return Base.Area() * Height;
        }
    }
}
