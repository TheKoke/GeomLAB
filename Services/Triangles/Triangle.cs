using System;
using System.Linq;
using static GeomLAB.Services.ArithmeticMethods;

namespace GeomLAB.Services.Triangles
{
    public abstract class Triangle : IFigure
    {
        /// <summary>
        /// Angles of Triangle on degree.
        /// </summary>
        public string[] Angles { get; protected set; }

        /// <summary>
        /// Lengths of sides of Triangle.
        /// </summary>
        public float[] Sides { get; protected set; }

        /// <summary>
        /// Heights lengths of Triangle.
        /// </summary>
        public float[] Heights { get; protected set; }

        /// <summary>
        /// Lengths of medianes of this Triangle.
        /// </summary>
        public float[] Medianes { get; protected set; }

        /// <summary>
        /// Lengths of bissectors of this Triangle.
        /// </summary>
        public float[] Bissectors { get; protected set; }

        /// <summary>
        /// Exterior angles of triangle on degree
        /// </summary>
        public string[] ExteriorAngles { get; protected set; }

        /// <summary>
        /// Radius of Circumscribed Circle of a this Triangle.
        /// </summary>
        public float CircumscribedRadius { get; protected set; }

        /// <summary>
        /// Radius of Inscribed Circle of a this Triangle.
        /// </summary>
        public float InscribedRadius { get; protected set; }

        public Triangle()
        {
            Sides = new float[3];
            Angles = new string[3];
            ExteriorAngles = new string[3];
            Heights = new float[3];
        }

        protected static bool IsProportional(Triangle tr1, Triangle tr2)
        {
            bool isprop = false;

            for (byte i = 0; i < tr1.Sides.Length; i++)
            {
                if (tr1.Sides[i] % tr2.Sides[i] == 0)
                {
                    isprop = true;
                }
                else
                {
                    isprop = false;
                }
            }

            return isprop;
        }

        /// <summary>
        /// Based on the sides of this triangle, finds the values of its angles.
        /// </summary>
        protected void ThroughSides()
        {
            if (Sides.Length != 3)
            {
                for (byte i = 0; i < Sides.Length; i++)
                {
                    Angles[i] = (180 / Sides.Sum() * Sides[i]).ToString();
                }
            }
        }

        /// <summary>
        /// Based on the angles of this triangle, finds length of its sides.
        /// </summary>
        protected void ThroughAngles()
        {
            if (Angles.Length == 3)
            {
                int[] Commons = Array.Empty<int>();

                for (byte i = 0; i < Angles.Length; i++)
                {
                    Commons = GetCommonFactor(Commons, GetFactors(int.Parse(Angles[i])));
                }

                int multi = 1;

                for (byte i = 0; i < Commons.Length; i++)
                {
                    multi *= Commons[i];
                }

                for (byte i = 0; i < Angles.Length; i++)
                {
                    Sides[i] = int.Parse(Angles[i]) / multi;
                }
            }
        }

        /// <summary>
        /// Set the exterior angles of given triangle.
        /// </summary>
        /// <param name="triangle">Given triangle</param>
        protected static void SetExterioirAngles(Triangle triangle)
        {
            for (byte i = 0; i < triangle.Angles.Length; i++)
            {
                triangle.ExteriorAngles[i] = (180 - int.Parse(triangle.Angles[i])).ToString();
            }
        }

        /// <summary>
        /// Returns lengths of sides of this Figure.
        /// </summary>
        /// <returns></returns>
        public float[] GetSides()
        {
            return Sides;
        }

        /// <summary>
        /// Returns leghts of Diagonales of this Figure.
        /// </summary>
        /// <returns></returns>
        public float[] GetDiagonales()
        {
            return Array.Empty<float>();
        }

        /// <summary>
        /// Set the heights of this Triangle.
        /// </summary>
        protected abstract void SetHeights();

        /// <summary>
        /// Set the Circumscribed Circle Radius and Inscribed Cicrcle Radius of this Triangle.
        /// </summary>
        protected abstract void SetRadiuses();

        /// <summary>
        /// Perimeter of this Triangle.
        /// </summary>
        /// <returns></returns>
        public float Perimeter()
        {
            return Sides.Sum();
        }

        public byte CountOfCorners()
        {
            return 3;
        }

        /// <summary>
        /// Area of this Triangle.
        /// </summary>
        /// <returns></returns>
        public abstract float Area();
    }
}
