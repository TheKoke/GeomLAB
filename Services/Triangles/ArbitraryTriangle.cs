using System;
using System.Linq;

namespace GeomLAB.services.Triangles
{
    public class ArbitraryTriangle : Triangle
    {
        public ArbitraryTriangle() : base()
        { }

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
            for (int i = 0; i < Altitudes.Length; i++)
            {
                Altitudes[i] = Area() / (2 * Sides[i]);
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
            float area = 1;
            float semiperimeter = Perimeter() / 2;
            
            for (int i = 0; i < Sides.Length; i++)
            {
                area *= semiperimeter - Sides[i];
            }
            
            return (float)Math.Sqrt(area);
        }
    }
}
