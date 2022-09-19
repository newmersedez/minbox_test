using AreaLibrary.Models.Base;
using static AreaLibrary.Utils.Utils;

namespace AreaLibrary.Models
{
    public sealed class Triangle : IFigure
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Negative or zero length");
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("This is not triangle");
            _a = a;
            _b = b;
            _c = c;
        }

        public double GetFigureArea()
        {
            var p = (_a + _b + _c) / 2;
            return Math.Round(Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c)));
        }

        public bool RightAngled()
        {
            if (_a > _b && _a > _c)
                return Pythagorean(_a, _b, _c);
            if (_b > _a && _b > _c)
                return Pythagorean(_b, _a, _c);
            return Pythagorean(_c, _a, _b);
        }

        private bool Pythagorean(double hypotenuse, double side1, double side2) =>
            DoubleEquals(Math.Pow(hypotenuse, 2), Math.Pow(side1, 2) + Math.Pow(side2, 2), Precision);
    }
}