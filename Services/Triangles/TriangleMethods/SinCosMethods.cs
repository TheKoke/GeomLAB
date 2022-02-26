using System;
using System.Linq;

namespace GeomLAB.services.Triangles
{
    public static class SinCosMethods
    {
        /// <summary>
        /// Method for Sines Theorem, this is define a triangle
        /// </summary>
        /// <param name="sides">known sides</param>
        /// <param name="angles">known angles</param>
        public static void SinesTheorem(ref float[] sides, ref string[] angles)
        {
            if (sides.Length == 3 || angles.Length == 3)
            {
                if (!sides.Where(x => x == 0).Any() && angles.Where(x => x == string.Empty).Count() <= 2)
                {
                    int appropriateIndex = Array.FindIndex(angles, x => x != string.Empty);

                    float doubleRadius = sides[appropriateIndex] / new Trigonometry(5).Sin(angles[appropriateIndex]);

                    for (byte i = 0; i < 3; i++)
                    {
                        if (i == appropriateIndex)
                        {
                            continue;
                        }

                        angles[i] = InverseTrigonometry.ToDegree(new InverseTrigonometry(5).Arcsin(sides[i] / doubleRadius));
                    }
                }

                if (!angles.Where(x => x == string.Empty).Any() && sides.Where(x => x == 0).Count() <= 2)
                {
                    int appropriateIndex = Array.FindIndex(sides, x => x != 0);

                    float doubleRadius = sides[appropriateIndex] / new Trigonometry(5).Sin(angles[appropriateIndex]);

                    for (byte i = 0; i < 3; i++)
                    {
                        if (i == appropriateIndex)
                        {
                            continue;
                        }

                        sides[i] = doubleRadius * new Trigonometry(5).Sin(angles[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Method for Cosines Theorem, this calculating a triangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="angleBetwee"></param>
        /// <returns></returns>
        public static float CosinesTheorem(float a, float b, string angleBetwee)
        {
            return (float)(Math.Pow(a, 2) + Math.Pow(b, 2) - a * b * new Trigonometry(5).Cos(angleBetwee));
        }
    }
}
