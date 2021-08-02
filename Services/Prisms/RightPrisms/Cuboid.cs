using System;
using GeomLAB.Services.Quadrangles;

namespace GeomLAB.services.Prisms
{
    public class Cuboid : Right
    {
        public Cuboid() : base()
        {

        }

        public Cuboid(float a) : this()
        {
            Base = new Square(a);
            LateralFace = new Square(a);

            Height = a;
            LateralRibs = a;
        }

        /// <summary>
        /// Set the diagonales of this Cuboid.
        /// </summary>
        protected override void SetDiagonales()
        {
            for (byte i = 0; i < Diagonales.Length; i++)
            {
                Diagonales[i] = Base.GetSides()[0] * (float)Math.Sqrt(3);
            }
        }

        /// <summary>
        /// Find the Area of Side Surface of this Cuboid.
        /// </summary>
        /// <returns></returns>
        public override float SideSurfaceArea()
        {
            return base.SideSurfaceArea();
        }

        /// <summary>
        /// Find the Volume of this Cuboid.
        /// </summary>
        /// <returns></returns>
        public override float Volume()
        {
            return (float)Math.Pow(Base.GetSides()[0], 3);
        }
    }
}
