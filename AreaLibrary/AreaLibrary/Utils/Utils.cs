using System;

namespace AreaLibrary.Utils
{
    public static class Utils
    {
        public const double Precision = 1e-6;

        public static bool DoubleEquals(double a, double b, double precision) => 
            Math.Abs(a - b) < precision;
    }
}