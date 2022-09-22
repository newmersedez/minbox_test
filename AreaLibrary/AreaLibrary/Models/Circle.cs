using System;
using AreaLibrary.Models.Base;

namespace AreaLibrary.Models
{
    public sealed class Circle : IFigure
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Negative or zero radius");
            _radius = radius;
        }

        public double GetFigureArea()
        {
            var area = _radius * _radius * Math.PI;
            if (double.IsPositiveInfinity(area))
                throw new OverflowException("Overflow occured");
            return area;
        }
    }
}