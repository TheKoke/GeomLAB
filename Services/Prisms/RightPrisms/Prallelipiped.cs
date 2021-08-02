﻿using System;
using GeomLAB.Services.Quadrangles;

namespace GeomLAB.Services.Prisms
{
    public class Parallelipiped : Right
    {
        public Rectangle SideEdge { get; protected set; }

        public Parallelipiped() : base()
        {

        }

        public Parallelipiped(Rectangle basic, Rectangle face) : this()
        {
            Base = basic;
            SideFace = face;
            SideEdge = new Rectangle(Base.GetSides()[0], SideFace.Sides[0]);

            Height = SideFace.Sides[0];
            SideRibs = Height;
        }

        /// <summary>
        /// Set the diagonales of this Parallelipped.
        /// </summary>
        protected override void SetDiagonales()
        {
            base.SetDiagonales();
        }

        /// <summary>
        /// Find the Area of Side Surface of this Parallelipiped.
        /// </summary>
        /// <returns></returns>
        public override float SideSurfaceArea()
        {
            return base.SideSurfaceArea();
        }

        /// <summary>
        /// Find the Volume of this Parallelipiped.
        /// </summary>
        /// <returns></returns>
        public override float Volume()
        {
            return Base.Area() * Height;
        }
    }
}