using System;

namespace GeomLAB.services.Triangles
{
    public class Equilateral : Triangle
    {
        public Equilateral()
        {
            Angles = new string[] { "60", "60", "60" };
            ExteriorAngles = new string[] { "120", "120", "120" };
            Sides = new float[3];
        }

        public Equilateral(float a) : this()
        {
            for (byte i = 0; i < Sides.Length; i++)
            {
                Sides[i] = a;
            }

            SetHeights();
            SetRadiuses();
        }

        /// <summary>
        /// Set the heights of this equilateral triangle
        /// </summary>
        protected override void SetHeights()
        {
            for (int i = 0; i < Altitudes.Length; i++)
            {
                Altitudes[i] = Sides[i] * (float)Math.Sqrt(3) / 2;
            }
        }

        /// <summary>
        /// Set the Circumscribed Circle Radius and Inscribed Cicrcle Radius of this Equilateral Triangle
        /// </summary>
        protected override void SetRadiuses()
        {
            CircumscribedRadius = Sides[0] * (float)Math.Sqrt(3) / 3;
            InscribedRadius = Sides[0] * (float)Math.Sqrt(3) / 6;
        }

        /// <summary>
        /// Find the Area of this equilateral triangle
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            return (float)(Math.Pow(Sides[0], 2) * Math.Sqrt(3) / 4);
        }
    }
}
