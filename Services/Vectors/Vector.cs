using System;

namespace GeomLAB.services
{
    class Vector
    {
        /// <summary>
        /// bool field mains is this vector based on the Three-Dimensional space
        /// </summary>
        public bool IsThreeDimensional { get; private set; }

        /// <summary>
        /// Directional cosines of this vector, it is a cosines of angles between vector and axises
        /// </summary>
        public float[] DirectionalCosines { get; private set; }

        /// <summary>
        /// X - coordinate of vector
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Y - coordinate of vector
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Z - coordinate of vector
        /// If vector based on Second Dimensional space, this field will be null
        /// </summary>
        public float? Z { get; private set; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
            Z = null;

            IsThreeDimensional = false;

            DirectionalCosines = new float[2];
            SetCosines();
        }

        public Vector(float x, float y, float z) : this(x, y)
        {
            Z = z;
            IsThreeDimensional = true;

            DirectionalCosines = new float[3];
            SetCosines();
        }

        /// <summary>
        /// Find the length or module of this vector
        /// </summary>
        /// <returns></returns>
        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z ??= 0, 2));
        }

        /// <summary>
        /// Set the directional cosines of this vector
        /// </summary>
        private void SetCosines()
        {
            DirectionalCosines[0] = X / Length();
            DirectionalCosines[1] = Y / Length();

            if (IsThreeDimensional)
            {
                DirectionalCosines[2] = (float)(Z / Length());
            }
        }

        public override string ToString()
        {
            if (IsThreeDimensional)
            {
                return $"{X}i + {Y}j + {Z}k";
            }
            else
            {
                return $"{X}i + {Y}j";
            }
        }

        /// <summary>
        /// Find the cosine of angle between this and given vectors
        /// </summary>
        /// <param name="anotherVector">Given second vector</param>
        /// <returns></returns>
        public float CosAngleBetween(Vector anotherVector)
        {
            float numerator = anotherVector.X * X + anotherVector.Y * Y + (anotherVector.Z ??= 0) * (Z ??= 0);
            float denominator = anotherVector.Length() * Length();

            return numerator / denominator;
        }

        /// <summary>
        /// Find angle between this and given vectors
        /// </summary>
        /// <param name="anotherVector">Given vector</param>
        /// <returns></returns>
        public string AngleBetween(Vector anotherVector)
        {
            return InverseTrigonometry.ToDegree(new InverseTrigonometry(5).Arccos(CosAngleBetween(anotherVector)));
        }

        /// <summary>
        /// Find the dot product of this and given vector
        /// </summary>
        /// <param name="anotherVector"></param>
        /// <returns></returns>
        public float DotProduct(Vector anotherVector)
        {
            return anotherVector.Length() * Length() * CosAngleBetween(anotherVector);
        }

        /// <summary>
        /// Find the Vector of Cross Product of this and given Vector.
        /// </summary>
        /// <param name="anotherVector">Given another vector</param>
        /// <returns></returns>
        public Vector CrossProduct(Vector anotherVector)
        {
            float x = anotherVector.Y * (this.Z ??= 0) - (anotherVector.Z ??= 0) * this.Y;
            float y = (anotherVector.Z ??= 0) * this.X - anotherVector.X * (this.Z ??= 0);
            float z = anotherVector.X * this.Y - anotherVector.Y * this.X;

            return new Vector(x, y, z);
        }
    }
}
