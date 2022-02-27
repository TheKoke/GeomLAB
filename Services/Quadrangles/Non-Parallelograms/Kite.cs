using System;
using System.Linq;

namespace GeomLAB.services.Quadrangles
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
        {}

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
                string[] vertices = new string[]
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

                    for (byte j = (byte)(i < 2 ? 0 : 1); j < vertices.Length; j++)
                    {
                        Angles[i] = (float.Parse(vertices[j]) * 2).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Set heights of this Kite.
        /// </summary>
        protected override void SetHeights()
        {
            base.SetHeights();
        }

        /// <summary>
        /// Set the circumscribed circle radius and inscribed circle radius of this Kite.
        /// </summary>
        protected override void SetRadiuses()
        {
            InscribedRadius = Diagonales.Min();

            if (EqualAngles == "90")
            {
               CircumscribedRadius = Math.Sqrt(LongSide * LongSide + ShortSide * ShortSide) / 2;
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
            return LongSide * ShortSide * new Trigonometry(7).Sin(EqualAngles);
        }
    }
}
