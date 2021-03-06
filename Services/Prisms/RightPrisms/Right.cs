using System;
using GeomLAB.services.Quadrangles;

namespace GeomLAB.services.Prisms
{
    public class Right : Prism
    {
        public Right() : base()
        {

        }

        public Right(IFigure basic, float height)
        {
            Base = basic;
            Height = height;
            LateralRibs = height;

            LateralFace = new Rectangle(Base.Perimeter() / Base.CountOfCorners(), height);
        }

        /// <summary>
        /// Set the diagonales of this Right Prism.
        /// </summary>
        protected override void SetDiagonales()
        {
            for (byte i = 0; i < Diagonales.Length; i++)
            {
                Diagonales[i] = (float)Math.Sqrt(Math.Pow(Base.GetDiagonales()[i], 2) + Math.Pow(Base.GetSides()[i % 2], 2));
            }
        }

        /// <summary>
        /// Find the Area of Side Surface of this Right Prism.
        /// </summary>
        /// <returns></returns>
        public override float SideSurfaceArea()
        {
            return Base.CountOfCorners() * LateralFace.Area();
        }

        /// <summary>
        /// Find the Volume of this Right Prism.
        /// </summary>
        /// <returns></returns>
        public override float Volume()
        {
            return Base.Area() * Height;
        }
    }
}
