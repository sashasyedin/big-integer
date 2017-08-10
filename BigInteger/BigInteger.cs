using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigInteger
{
    /// <summary>
    /// Represents a large integer type.
    /// </summary>
    public struct BigInteger
    {
        private LinkedList<byte> _contents;

        #region Constructors

        public BigInteger(string numString)
            : this()
        {
            BigInteger.TryParse(numString, out LinkedList<byte> contents);
            this._contents = contents;
        }

        private BigInteger(LinkedList<byte> contents)
        {
            this._contents = contents;
        }

        #endregion Constructors

        /// <summary>
        /// Converts the string representation of a number into digits.
        /// </summary>
        /// <param name="numString">A string containing a number to convert.</param>
        /// <param name="contents">A set of digits.</param>
        /// <returns>True if string was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string numString, out BigInteger bigInt)
        {
            var success = BigInteger.TryParse(numString, out LinkedList<byte> contents);

            // Create the new struct object:
            bigInt = new BigInteger(contents);

            return success;
        }

        #region Overrides

        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            if (this._contents == null || this._contents.Any() == false)
            {
                return "0";
            }

            var sb = new StringBuilder();

            foreach (var digit in this._contents)
            {
                sb.Append(digit.ToString());
            }

            return sb.ToString();
        }

        #endregion Overrides

        #region Private Methods

        /// <summary>
        /// Converts the string representation of a number into digits.
        /// </summary>
        /// <param name="numString">A string containing a number to convert.</param>
        /// <param name="contents">A set of digits.</param>
        /// <returns>True if string was converted successfully; otherwise, false.</returns>
        private static bool TryParse(string numString, out LinkedList<byte> contents)
        {
            contents = new LinkedList<byte>();

            if (string.IsNullOrWhiteSpace(numString) == true)
            {
                return false;
            }

            foreach (var digit in numString)
            {
                contents.AddLast(Convert.ToByte(digit - '0'));
            }

            return true;
        }

        #endregion Private Methods
    }
}
