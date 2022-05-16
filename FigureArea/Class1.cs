using System;

namespace FigureArea
{
    public abstract class Shape
    {
        public abstract double GetArea();
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(float radius)
        {
            Radius = radius;
        }

        public float Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius can't be negative!");
                }
                else
                {
                    radius = value;
                }
            }
        }

        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }

    public class Triangle : Shape
    {
        public float SideA { get; set; }

        public float SideB { get; set; }

        public float SideC { get; set; }

        public float SemiP { get; set; }

        public Triangle(float a, float b, float c)
        {
            if (IsPositive(a, b, c) && IsExist(a, b, c))
            {
                SideA = a;
                SideB = b;
                SideC = c;
                SemiP = (a + b + c) / 2;
            }
        }

        public override double GetArea() => Math.Sqrt(SemiP * (SemiP - SideA) * (SemiP - SideB) * (SemiP - SideC));

        public bool IsRectangular()
        {
            float hypotenuse = Math.Max(SideA, Math.Max(SideB, SideC));
            if (hypotenuse > SideA && hypotenuse > SideB)
            {
                if (Math.Pow(hypotenuse, 2) == Math.Pow(SideA, 2) + Math.Pow(SideB, 2))
                {
                    return true;
                }
            }
            else if (hypotenuse > SideA && hypotenuse > SideC)
            {
                if (Math.Pow(hypotenuse, 2) == Math.Pow(SideA, 2) + Math.Pow(SideC, 2))
                {
                    return true;
                }
            }
            else if (hypotenuse > SideB && hypotenuse > SideC)
            {
                if (Math.Pow(hypotenuse, 2) == Math.Pow(SideB, 2) + Math.Pow(SideC, 2))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsPositive(float a, float b, float c)
        {
            if (a >= 0 && b >= 0 && c >= 0)
            {
                return true;
            }

            throw new ArgumentException("All sides must be positive!");;
        }

        private static bool IsExist(float a, float b, float c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }

            throw new ArgumentException("Triangle does not exist!");
        }
    }
}
