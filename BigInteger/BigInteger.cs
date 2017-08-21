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
        #region Fields

        /// <summary>
        /// The negative sign.
        /// </summary>
        private const char NegativeSign = '-';

        /// <summary>
        /// The contents.
        /// </summary>
        private LinkedList<byte> _contents;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BigInteger"/> struct.
        /// </summary>
        /// <param name="numString">The number string.</param>
        public BigInteger(string numString)
            : this()
        {
            var success = BigInteger.TryParse(numString, out var contents, out var isNegative);

            if (success == true)
            {
                this._contents = contents;
                this.IsNegative = isNegative;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigInteger" /> struct.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="isNegative">Is negative.</param>
        private BigInteger(LinkedList<byte> contents, bool isNegative)
        {
            this._contents = contents;
            this.IsNegative = isNegative;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates whether this instance is negative.
        /// </summary>
        public bool IsNegative { get; private set; }

        #endregion Properties

        /// <summary>
        /// Converts the string representation of a number into digits.
        /// </summary>
        /// <param name="numString">A string containing a number to convert.</param>
        /// <param name="contents">A set of digits.</param>
        /// <returns>True if string was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string numString, out BigInteger bigInt)
        {
            var success = BigInteger.TryParse(numString, out var contents, out var isNegative);

            // Create the new struct object:
            bigInt = new BigInteger(contents, isNegative);

            return success;
        }

        #region Overrides

        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            if (this._contents == null
                || this._contents.Any() == false)
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
        /// <param name="isNegative">Is negative.</param>
        /// <returns>True if string was converted successfully; otherwise, false.</returns>
        private static bool TryParse(string numString, out LinkedList<byte> contents, out bool isNegative)
        {
            contents = new LinkedList<byte>();
            isNegative = default(bool);

            if (string.IsNullOrWhiteSpace(numString) == true)
            {
                return false;
            }

            if (numString[0] == BigInteger.NegativeSign)
            {
                if (numString.Length == 1)
                {
                    return false;
                }

                isNegative = true;
                numString = string.Concat(numString.Skip(1));
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
