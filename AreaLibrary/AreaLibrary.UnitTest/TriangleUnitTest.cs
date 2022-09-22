using System;
using AreaLibrary.Models;

namespace AreaLibrary.UnitTest
{
    public class TriangleUnitTest
    {
        [Fact]
        public void ComputeTriangleArea()
        {
            var triangle = new Triangle(5.05, 5.15, 6.001);
            var expected = 12.37220697780412;
            var actual = triangle.GetFigureArea();
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(6.119473782801, 2.292395227273, 5.673877289858)]
        public void RightAngledTriangle(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            var expected = true;
            var actual = triangle.RightAngled();
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(2, 3, 4)]
        [InlineData(59.4672924, 35.1, 41.0005)]
        public void NotRightAngledTriangle(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            var expected = false;
            var actual = triangle.RightAngled();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 1, 1)]
        [InlineData(389.1, 74, 26.1123)]
        public void InvalidArguments(double a, double b, double c)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            
            Assert.Equal("This is not triangle", ex.Message);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-3, 4, 5)]
        [InlineData(double.MinValue, 34124124.78, 653547.000001)]
        public void NegativeZeroMinValue(double a, double b, double c)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            Assert.Equal("Negative or zero length", ex.Message);
        }
        
        [Fact]
        public void MaxValue()
        {
            var triangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);
            var ex = Assert.Throws<OverflowException>(() => triangle.GetFigureArea());
            Assert.Equal("Overflow occured", ex.Message);
        }
    }
}