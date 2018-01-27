﻿using System;
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
        private readonly LinkedList<byte> _contents;

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

            if (success == false)
                return;

            this._contents = contents;
            this.IsNegative = isNegative;
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

        #region Operators

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lOperand">The left operand.</param>
        /// <param name="rOperand">The right operand.</param>
        /// <returns>The result of the operator.</returns>
        public static BigInteger operator +(BigInteger lOperand, BigInteger rOperand)
        {
            if (lOperand.IsNegative || rOperand.IsNegative)
                throw new NotImplementedException();

            // Check if operand equals zero:
            var lOperandZero = !lOperand._contents?.Any() ?? true;
            var rOperandZero = !rOperand._contents?.Any() ?? true;
            
            if (lOperandZero == true && rOperandZero == true)
                return new BigInteger();
            else if (lOperandZero == true)
                return rOperand;
            else if (rOperandZero == true)
                return lOperand;
            
            // Equalize the number of digits:
            var lOperandSize = lOperand._contents.Count;
            var rOperandSize = rOperand._contents.Count;

            Helpers.RepeatAction(
                Math.Abs(lOperandSize - rOperandSize),
                () =>
                {
                    if (lOperandSize > rOperandSize)
                        rOperand._contents.AddFirst(0);
                    else if (rOperandSize > lOperandSize)
                        lOperand._contents.AddFirst(0);
                });

            // Addition process:
            var useCarry = false;
            var result = string.Empty;

            for (var i = lOperand._contents.Count - 1; i >= 0; i--)
            {
                var item1 = lOperand._contents.ElementAt(i);
                var item2 = rOperand._contents.ElementAt(i);
                var sum = item1 + item2 + (useCarry ? 1 : 0);

                useCarry = false;

                if (sum > 9)
                {
                    useCarry = true;
                    sum -= 10;
                }

                result = sum.ToString() + result;
            }

            if (useCarry == true)
                result = "1" + result;

            return new BigInteger(result);
        }

        /// <summary>
        /// Implements the operator ++.
        /// </summary>
        /// <param name="operand">The operand.</param>
        /// <returns>The result of the operator.</returns>
        public static BigInteger operator ++(BigInteger operand)
        {
            return operand + new BigInteger("1");
        }

        #endregion Operators

        #region Public Methods

        /// <summary>
        /// Converts the string representation of a number into digits.
        /// </summary>
        /// <param name="numString">A string containing a number to convert.</param>
        /// <param name="bigInt">The big int.</param>
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
            if (this._contents == null || this._contents.Any() == false)
                return "0";
            
            var sb = new StringBuilder();

            foreach (var digit in this._contents)
                sb.Append(digit.ToString());
            
            return sb.ToString();
        }

        #endregion Overrides

        #endregion Public Methods

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
                return false;

            if (numString[0] == BigInteger.NegativeSign)
            {
                if (numString.Length == 1)
                    return false;

                isNegative = true;
                numString = string.Concat(numString.Skip(1));
            }

            foreach (var digit in numString)
                contents.AddLast(Convert.ToByte(digit - '0'));

            return true;
        }

        #endregion Private Methods
    }
}
