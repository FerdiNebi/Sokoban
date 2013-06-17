using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public struct Vector2D
    {
        // Fields
        private readonly int x;
        private readonly int y;

        // Properties
        public int X
        {
            get
            {
                return this.x;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
        }

        // Special Vectors
        public static Vector2D ZeroVector
        {
            get
            {
                return new Vector2D(0, 0);
            }
        }

        public static Vector2D LeftVector
        {
            get
            {
                return new Vector2D(-1, 0);
            }
        }

        public static Vector2D RightVector
        {
            get
            {
                return new Vector2D(1, 0);
            }
        }

        public static Vector2D UpVector
        {
            get
            {
                return new Vector2D(0, -1);
            }
        }

        public static Vector2D DownVector
        {
            get
            {
                return new Vector2D(0, 1);
            }
        }

        


        // Methods
        // --- Constructors
        public Vector2D(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }



        // --- Overrided operators
        // --- --- Static
        // --- --- --- Comparison Operators
        public static bool operator ==(Vector2D vect1, object vect2)
        {
            return vect1.Equals(vect2);
        }

        public static bool operator !=(Vector2D vect1, object vect2)
        {
            return !(vect1.Equals(vect2));
        }

        public static bool operator ==(Vector2D vect1, Vector2D vect2)
        {
            return vect1.Equals(vect2);
        }

        public static bool operator !=(Vector2D vect1, Vector2D vect2)
        {
            return !(vect1.Equals(vect2));
        }

        // --- --- --- Arithmetic Operators
        public static Vector2D operator +(Vector2D vect1, object vect2)
        {
            if (vect2 == null || !(vect2 is Vector2D))
            {
                throw new ArithmeticException();
            }
            else
            {
                Vector2D vector2 = (Vector2D)vect2;
                return new Vector2D(vect1.X + vector2.X, vect1.Y + vector2.Y);
            }
        }

        public static Vector2D operator -(Vector2D vect1, object vect2)
        {
            if (vect2 == null || !(vect2 is Vector2D))
            {
                throw new ArithmeticException();
            }
            else
            {
                Vector2D vector2 = (Vector2D)vect2;
                return new Vector2D(vect1.X - vector2.X, vect1.Y - vector2.Y);
            }
        }

        public static Vector2D operator *(Vector2D vect, int scalar)
        {
            return new Vector2D(vect.X * scalar, vect.Y * scalar);
        }


        // --- --- --- Unary Operators
        public static Vector2D operator +(Vector2D vect)
        {
            return vect;
        }

        public static Vector2D operator -(Vector2D vect)
        {
            return new Vector2D((vect.X * (-1)), (vect.Y * (-1)));
        }

        // --- --- Instance
        // Comparison
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter is not Vector2D - return false.
            if (obj is Vector2D)
            {
                return false;
            }


            // Cast the object to Vector2D
            Vector2D vect2 = (Vector2D)obj;

            // Return true if the fields match
            return this.Equals(vect2);
        }

        public bool Equals(Vector2D otherVector)
        {
            return (this.X == otherVector.X && this.Y == otherVector.Y);
        }

        // --- --- --- Hash Code
        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }


        // --- --- --- To String
        public override string ToString()
        {
            string strVector= this.X + ", " + this.Y;
            return strVector;
        }
    }
}
