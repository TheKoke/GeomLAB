using System;
using System.Linq;

namespace GeomLAB.Services.Triangles
{
    public class Right : Triangle
    {
        public Right() : base()
        {
            Angles[2] = "90";
            ExteriorAngles[2] = "90";
        }

        public Right(float FirstLeg, float SecondLeg, float Hypotenuse) : this()
        {
            if (Math.Pow(FirstLeg, 2) + Math.Pow(SecondLeg, 2) == Math.Pow(Hypotenuse, 2))
            {
                Sides = new float[] { FirstLeg, SecondLeg, Hypotenuse };

                Angles[0] = InverseTrigonometry.ToDegree(new InverseTrigonometry(5).Arcsin(FirstLeg / Hypotenuse));
                Angles[1] = InverseTrigonometry.ToDegree(new InverseTrigonometry(5).Arcsin(SecondLeg / Hypotenuse));
                SetHeights();
                SetExterioirAngles(this);
            }
        }

        public Right(string FirstAngle, string SecondAngle) : this()
        {
            if (Array.ConvertAll(new string[] { FirstAngle, SecondAngle }, int.Parse).Sum() + 90 == 180)
            {
                Angles = new string[3] { FirstAngle, SecondAngle, "90" };

                ThroughAngles();
                SetHeights();
                SetExterioirAngles(this);
            }
        }

        /// <summary>
        /// Set the heights of this right triangle
        /// </summary>
        protected override void SetHeights()
        {
            for (byte i = 0; i < Heights.Length; i++)
            {
                if (Sides[i] == Sides.Max())
                {
                    Heights[i] = 2 * Area() / Sides[i];

                    continue;
                }

                Heights[i] = Sides[i];
            }
        }

        /// <summary>
        /// Set the Circumscribed Circle Radius and Inscribed Cicrcle Radius of this Right Triangle
        /// </summary>
        protected override void SetRadiuses()
        {
            CircumscribedRadius = Sides.Max() / 2;

            InscribedRadius = Area() / (Perimeter() / 2);
        }

        /// <summary>
        /// Find the area of this right triangle
        /// </summary>
        public override float Area()
        {
            float result = 1;

            for (byte i = 1; i < Sides.Where(x => x != Sides.Max()).Count(); i++)
            {
                result *= Sides.Where(x => x != Sides.Max()).ElementAt(i);
            }

            return result / 2;
        }
    }
}
