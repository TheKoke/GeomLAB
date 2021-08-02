using System;
using System.Linq;

namespace GeomLAB.Services.Triangles
{
    public class Isosceles : Triangle
    {
        /// <summary>
        /// Leg - a length of two equal sides of Isosceles triangle 
        /// </summary>
        public float Leg { get; private set; }

        /// <summary>
        /// Base side not equal of two otherwise sides
        /// </summary>
        public float BaseSide { get; private set; }

        public Isosceles() : base()
        {

        }

        public Isosceles(float leg, float basic)
        {
            if (2 * leg! >= basic)
            {
                Leg = leg;
                BaseSide = basic;

                Sides = new float[3] { leg, leg, basic };
                ThroughSides();
                SetHeights();
                SetRadiuses();
                SetExterioirAngles(this);
            }
        }

        public Isosceles(string apexAngle, string equalAngle)
        {
            if (int.Parse(equalAngle) * 2 + int.Parse(apexAngle) == 180)
            {
                Angles = new string[3] { equalAngle, equalAngle, apexAngle };
                ThroughAngles();
                SetHeights();
                SetExterioirAngles(this);
                SetRadiuses();
            }
        }

        /// <summary>
        /// Set the heigths of this Isosceles triangle
        /// </summary>
        protected override void SetHeights()
        {
            for (byte i = 0; i < Altitudes.Length; i++)
            {
                if (Sides[i] == BaseSide)
                {
                    Altitudes[i] = (float)Math.Sqrt(4 * Leg * Leg + BaseSide * BaseSide);
                    continue;
                }

                Altitudes[i] = Leg * new Trigonometry(3).Sin(Angles[2]);
            }
        }

        /// <summary>
        /// Set the Circumscribed Circle Radius and Inscribed Cicrcle Radius of this Isoscles Triangle
        /// </summary>
        protected override void SetRadiuses()
        {
            Trigonometry trg = new(5);

            CircumscribedRadius = Perimeter() / 2 * (2 * trg.Sin(Angles[0]) + trg.Sin(Angles[2]));
            InscribedRadius = (BaseSide / 2) * (float)Math.Sqrt((2 * Leg - BaseSide) / (2 * Leg + BaseSide));
        }

        /// <summary>
        /// Find the area of this isosceles triangle
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            //1 / 2 * base * h, where h = 1/2sqrt(4leg^2 - b^2)

            return BaseSide * Altitudes[Array.IndexOf(Sides, BaseSide)] / 2;
        }
    }
}
