namespace CubeClash.Scripts.Assembly.Util
{
    public static class BitMaskHelper
    {
        /// <summary>
        /// bit mask operation
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int AddFlag(this int origin, int value)
        {
            origin |= 1 << value;
            return origin;
        }

        /// <summary>
        /// bit mask operation
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasFlag(this int origin, int value)
        {
            int v = 1 << value;
            return (origin & v) == v;
        }
    }
}