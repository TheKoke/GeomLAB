using System;
using System.Linq;

#pragma warning disable CS0659

namespace GeomLAB.services.Triangles
{
    public class ArbitraryTriangle : Triangle
    {
        public ArbitraryTriangle() : base()
        {

        }

        public ArbitraryTriangle(float a, float b, float c) : this()
        {
            if (a + b! <= c || a + c! <= b || b + c! <= a)
            {
                Sides[0] = a;
                Sides[1] = b;
                Sides[2] = c;

                ThroughSides();
                SetHeights();
                SetRadiuses();
                SetExterioirAngles(this);
            }
        }

        public ArbitraryTriangle(string A, string B, string C) : this()
        {
            while (int.Parse(A) + int.Parse(B) + int.Parse(C) > 180)
            {
                A = (int.Parse(A) / 2).ToString();
                B = (int.Parse(B) / 2).ToString();
                C = (int.Parse(C) / 2).ToString();
            }

            Angles[0] = A;
            Angles[1] = B;
            Angles[2] = C;

            ThroughAngles();
            SetHeights();
            SetRadiuses();
            SetExterioirAngles(this);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(ArbitraryTriangle))
            {
                ArbitraryTriangle triangle = (ArbitraryTriangle)obj;

                return IsProportional(this, triangle);
            }

            return false;
        }

        /// <summary>
        /// Set the heights of this triangle
        /// </summary>
        protected override void SetHeights()
        {
            Trigonometry trg = new(5);

            float[] AnglesInRadians = Array.ConvertAll(Angles, float.Parse);

            for (byte i = 0; i < AnglesInRadians.Length; i++)
            {
                AnglesInRadians[i] *= (float)Math.PI / 180;
            }

            for (byte i = 0; i < Altitudes.Length; i++)
            {
                Altitudes[i] = Sides[i] / trg.Sin(AnglesInRadians.Where(x => Array.IndexOf(AnglesInRadians, x) != i).Sum());

                for (byte j = 0; j < AnglesInRadians.Where(x => Array.IndexOf(AnglesInRadians, x) != i).Count(); j++)
                {
                    Altitudes[i] *= trg.Sin(AnglesInRadians.Where(x => Array.IndexOf(AnglesInRadians, x) != i).ElementAt(j));
                }
            }
        }

        /// <summary>
        /// Set the Circumscribed Circle Radius and Inscribed Radius
        /// </summary>
        protected override void SetRadiuses()
        {
            CircumscribedRadius = Sides[0] / (2 * new Trigonometry(5).Sin(Angles[0]));
            InscribedRadius = Area() / (Perimeter() / 2);
        }

        /// <summary>
        /// Find the Area of this triangle
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            float smallerSidesMultiply = 1;

            for (byte i = 0; i < Sides.Where(x => x != Sides.Max()).Count(); i++)
            {
                smallerSidesMultiply *= Sides.Where(x => x != Sides.Max()).ElementAt(i);
            }

            byte indexOfMaxDegree = (byte)Array.IndexOf(Array.ConvertAll(Angles, int.Parse), Array.ConvertAll(Angles, int.Parse).Max());

            return (float)(smallerSidesMultiply * new Trigonometry(5).Sin(Angles[indexOfMaxDegree]));
        }
    }
}
