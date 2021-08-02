using System;
using System.Linq;

namespace GeomLAB.Services.Quadrangles
{
     /// <summary>
     /// Class of Kite or Delthoid, it is a quadrangle where two opposite sides are equal.
     /// </summary>
    public class Kite : Quadrangle
    {
        public float LongSide { get; protected set; }

        public float ShortSide { get; protected set; }

        public string EqualAngles { get; protected set; }

        public Kite() : base()
        {

        }

        public Kite(float longSide, float shortSide) : this()
        {
            LongSide = longSide;
            ShortSide = shortSide;

            Sides = new float[] { ShortSide, ShortSide, LongSide, LongSide };

            ThroughSides();
            SetHeights();
            SetDiagonales();
            SetRadiuses();
        }

        /// <summary>
        /// Set the Angles of this Kite through Sides.
        /// </summary>
        protected void ThroughSides()
        {
            if (Sides.Where(x => x != 0).Count() == 4)
            {
                string[] corners = new string[]
                {
                    ((180 - float.Parse(EqualAngles) / (LongSide + ShortSide)) * LongSide).ToString(),
                    ((180 - float.Parse(EqualAngles) / (LongSide + ShortSide)) * ShortSide).ToString()
                };

                for (byte i = 0; i < Angles.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        Angles[i] = EqualAngles;
                        continue;
                    }

                    for (byte j = (byte)(i < 2 ? 0 : 1); j < corners.Length; j++)
                    {
                        Angles[i] = (float.Parse(corners[j]) * 2).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Set heights of this Kite.
        /// </summary>
        protected override void SetHeights()
        {
            for (byte i = 0; i < Heights.Length; i++)
            {
                Heights[i] = Sides[i];
            }
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Kite.
        /// </summary>
        protected override void SetRadiuses()
        {
            if (Sides.Where(x => Array.IndexOf(Sides, x) % 2 == 1).Sum() == Sides.Where(x => Array.IndexOf(Sides, x) % 2 == 0).Sum())
            {
                InscribedRadius = Heights[3] / 2;
            }

            if (Array.ConvertAll(Angles, int.Parse).Where(x => Array.IndexOf(Angles, x) % 2 == 0).Sum() == 180)
            {
                CircumscribedRadius = Diagonales.Max() / 2;
            }
        }

        /// <summary>
        /// Set the diagonales of this Kite.
        /// </summary>
        protected override void SetDiagonales()
        {
            for (byte i = 0; i < Diagonales.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(LongSide, ShortSide, EqualAngles);
                    continue;
                }

                Diagonales[i] = Triangles.SinCosMethods.CosinesTheorem(LongSide, ShortSide, Array.ConvertAll(Angles, int.Parse).Min().ToString());
            }
        }

        /// <summary>
        /// Find the area of this Kite.
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            return LongSide * ShortSide * new Trigonometry(5).Sin(EqualAngles);
        }
    }
}
