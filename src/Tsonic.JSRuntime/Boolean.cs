namespace Tsonic.JSRuntime
{
    /// <summary>
    /// JavaScript Boolean instance methods.
    /// Operates on native C# bool values while preserving JS string casing.
    /// </summary>
    public static class BooleanOps
    {
        public static string toString(this bool value)
        {
            return value ? "true" : "false";
        }

        public static bool valueOf(this bool value)
        {
            return value;
        }
    }
}
