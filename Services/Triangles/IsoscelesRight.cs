using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomLAB.Services.Triangles
{
    public class IsoscelesRight : Isosceles
    {
        public IsoscelesRight() : base()
        {
            Angles = new string[3] { "45", "45", "90" };
        }

        public IsoscelesRight(float leg, float basicSide) : base(leg, basicSide)
        {

        }

        /// <summary>
        /// Find the Area of this IdoRight triangle
        /// </summary>
        /// <returns></returns>
        public override float Area()
        {
            //s = leg^2 / 2

            return (float)Math.Pow(Leg, 2) / 2;
        }
    }
}
