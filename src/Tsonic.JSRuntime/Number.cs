/**
 * JavaScript Number static methods
 * Provides Number.parseInt, Number.parseFloat, Number.isNaN, Number.isFinite, Number.isInteger
 */

namespace Tsonic.JSRuntime
{
    /// <summary>
    /// JavaScript Number object static methods.
    /// Note: Number.parseInt and Number.parseFloat are aliases for the global functions.
    /// </summary>
    public static class Number
    {
        // Number constants
        public const double MAX_VALUE = double.MaxValue;
        public const double MIN_VALUE = double.Epsilon; // Smallest positive value
        public const double MAX_SAFE_INTEGER = 9007199254740991; // 2^53 - 1
        public const double MIN_SAFE_INTEGER = -9007199254740991; // -(2^53 - 1)
        public const double POSITIVE_INFINITY = double.PositiveInfinity;
        public const double NEGATIVE_INFINITY = double.NegativeInfinity;
        public const double NaN = double.NaN;
        public const double EPSILON = 2.220446049250313e-16; // 2^-52

        /// <summary>
        /// Parse string to integer with optional radix.
        /// Alias for the global parseInt function.
        /// </summary>
        public static long? parseInt(string str, int? radix = null)
        {
            return Globals.parseInt(str, radix);
        }

        /// <summary>
        /// Parse string to floating point number.
        /// Alias for the global parseFloat function.
        /// </summary>
        public static double parseFloat(string str)
        {
            return Globals.parseFloat(str);
        }

        /// <summary>
        /// Check if value is NaN.
        /// Unlike global isNaN, this does NOT convert the argument.
        /// </summary>
        public static bool isNaN(double value)
        {
            return double.IsNaN(value);
        }

        /// <summary>
        /// Check if value is finite (not infinite or NaN).
        /// Unlike global isFinite, this does NOT convert the argument.
        /// </summary>
        public static bool isFinite(double value)
        {
            return !double.IsInfinity(value) && !double.IsNaN(value);
        }

        /// <summary>
        /// Check if value is an integer (no fractional part).
        /// </summary>
        public static bool isInteger(double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
            {
                return false;
            }
            return System.Math.Floor(value) == value;
        }

        /// <summary>
        /// Check if value is a safe integer (can be exactly represented).
        /// Safe integers are integers in the range -(2^53-1) to 2^53-1.
        /// </summary>
        public static bool isSafeInteger(double value)
        {
            if (!isInteger(value))
            {
                return false;
            }
            return value >= MIN_SAFE_INTEGER && value <= MAX_SAFE_INTEGER;
        }
    }
}
