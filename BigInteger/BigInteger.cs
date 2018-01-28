using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigInteger
{
    /// <summary>
    /// Represents a large integer type.
    /// </summary>
    public struct BigInteger : IComparable<BigInteger>
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
            if (lOperand.IsNegative ^ rOperand.IsNegative)
                throw new NotImplementedException();
            
            // Check if operand equals zero:
            var lOperandZero = !lOperand._contents?.Any() ?? true;
            var rOperandZero = !rOperand._contents?.Any() ?? true;
            
            if (lOperandZero && rOperandZero)
                return new BigInteger();
            else if (lOperandZero)
                return rOperand;
            else if (rOperandZero)
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

            if (useCarry)
                result = "1" + result;
            
            if (lOperand.IsNegative && rOperand.IsNegative)
                result = NegativeSign + result;
            
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
        
        public static bool operator <(BigInteger lOperand, BigInteger rOperand)
        {
            return lOperand.CompareTo(rOperand) < 0;
        }
        
        public static bool operator >(BigInteger lOperand, BigInteger rOperand)
        {
            return lOperand.CompareTo(rOperand) > 0;
        }
        
        public static bool operator ==(BigInteger lOperand, BigInteger rOperand)
        {
            return lOperand.CompareTo(rOperand) == 0;
        }
        
        public static bool operator !=(BigInteger lOperand, BigInteger rOperand)
        {
            return lOperand.CompareTo(rOperand) != 0;
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
        
        public int CompareTo(BigInteger bigInt)
        {
            var bigIntCopy = this;
            var converse = default(bool);

            // Check if a number is negative:
            if (bigIntCopy.IsNegative && bigInt.IsNegative == false)
                return -1;
            
            if (bigIntCopy.IsNegative == false && bigInt.IsNegative)
                return 1;

            if (bigIntCopy.IsNegative && bigInt.IsNegative)
                converse = true;

            // Equalize the number of digits:
            var lOperandSize = bigIntCopy._contents.Count;
            var rOperandSize = bigInt._contents.Count;

            Helpers.RepeatAction(
                Math.Abs(lOperandSize - rOperandSize),
                () =>
                {
                    if (lOperandSize > rOperandSize)
                        bigInt._contents.AddFirst(0);
                    else if (rOperandSize > lOperandSize)
                        bigIntCopy._contents.AddFirst(0);
                });

            for (var i = 0; i < bigIntCopy._contents.Count; i++)
            {
                var item1 = bigIntCopy._contents.ElementAt(i);
                var item2 = bigInt._contents.ElementAt(i);

                if (item1 < item2)
                {
                    if (converse)
                        return 1;

                    return -1;
                }

                if (item1 > item2)
                {
                    if (converse)
                        return -1;

                    return 1;
                }
            }

            return 0;
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

            if (this.IsNegative)
                sb.Append(NegativeSign);

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

            if (string.IsNullOrWhiteSpace(numString))
                return false;

            if (numString[0] == NegativeSign)
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
