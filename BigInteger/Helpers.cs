using System;

namespace BigInteger
{
    /// <summary>
    /// BigInteger-related helper methods.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Repeats the action.
        /// </summary>
        /// <param name="repeatCount">The repeat count.</param>
        /// <param name="action">The action.</param>
        public static void RepeatAction(int repeatCount, Action action)
        {
            for (int i = 0; i < repeatCount; i++)
            {
                action();
            }
        }
    }
}
