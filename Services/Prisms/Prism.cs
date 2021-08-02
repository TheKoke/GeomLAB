using System;
using GeomLAB.Services.Quadrangles;

namespace GeomLAB.services.Prisms
{
    /* types of prism :
     * 1. Right
     * 2. Semi-Regular or Uniform
     * 3. Oblique (Lateral Face are Parallelogram)
     * 4. Truncated Prism (non - parallel bases)
     * 5. Frustum (Lateral Faces are Trapezoids)
     * 6. Prisms inheritance from rigth prism : 
     *      1. Paralellepiped
     *      2. Cuboid
     */
    public abstract class Prism
    {
        /// <summary>
        /// Base of this Prism.
        /// </summary>
        public IFigure Base { get; protected set; }

        /// <summary>
        /// Lateral Face of this Prism.
        /// </summary>
        public Quadrangle LateralFace { get; protected set; }

        /// <summary>
        /// Length of Lateral Ribs of this Prism.
        /// </summary>
        public float LateralRibs { get; protected set; }

        /// <summary>
        /// Length of Height of this Prism.
        /// </summary>
        public float Height { get; protected set; }

        /// <summary>
        /// Lengths of Diagonales of this Prism.
        /// </summary>
        public float[] Diagonales { get; protected set; }

        public Prism()
        {
            Diagonales = new float[Base.CountOfCorners() * (Base.CountOfCorners() - 3)];
        }

        /// <summary>
        /// Returns the Shlafli Symbol of this Prism.
        /// </summary>
        /// <returns></returns>
        public string ShlaflySymbol()
        {
            return string.Concat("{", $"{Base.CountOfCorners()}", "} X {}");
        }

        /// <summary>
        /// Area of base of this Prism.
        /// </summary>
        /// <returns></returns>
        public float BaseArea()
        {
            return Base.Area();
        }

        /// <summary>
        /// Returns Full Area of this Prism.
        /// </summary>
        /// <returns></returns>
        public float FullArea()
        {
            return 2 * BaseArea() + SideSurfaceArea();
        }

        /// <summary>
        /// Set the diagonales of this Prism.
        /// </summary>
        protected abstract void SetDiagonales();

        /// <summary>
        /// Find the Area of Side Surface of this Prism.
        /// </summary>
        /// <returns></returns>
        public abstract float SideSurfaceArea();

        /// <summary>
        /// Find the Volume of this Prism.
        /// </summary>
        /// <returns></returns>
        public abstract float Volume();
    }
}
