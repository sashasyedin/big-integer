using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigInteger.Tests
{
    /// <summary>
    /// Tests the TryParse method.
    /// </summary>
    [TestClass]
    public class BigInteger_TryParse : UnitTestContainer
    {
        #region Fields

        /// <summary>
        /// The BigInteger argument.
        /// </summary>
        private BigInteger _bigInt;

        /// <summary>
        /// The string argument.
        /// </summary>
        private string _numString;

        #endregion Fields

        #region Test Initialise

        /// <summary>
        /// Executed before each unit test to initialise data.
        /// </summary>
        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();

            this._bigInt = default(BigInteger);
            this._numString = string.Empty;
        }

        #endregion Test Initialise

        #region Tests

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void TryParse_WhenStringArgumentIsNull_ExpectParsingFailed()
        {
            // Arrange:
            this._numString = null;
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsFalse(actual);
            Assert.AreEqual("0", this._bigInt.ToString());
            this.AssertCore();
        }

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void TryParse_WhenValidStringArgumentPassed_AndMinusSignIsUsed_ExpectSuccess_AndNumberIsNegative()
        {
            // Arrange:
            this._numString = "-789789";
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(actual);
            Assert.IsTrue(this._bigInt._isNegative);
            Assert.AreEqual("789789", this._bigInt.ToString());
            this.AssertCore();
        }

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void TryParse_UnderValidCircumstances_ExpectSuccess()
        {
            // Arrange:
            this._numString = "12345";
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(actual);
            Assert.AreEqual(this._numString, this._bigInt.ToString());
            this.AssertCore();
        }

        #endregion Tests

        #region Stub, AssertCore

        /// <summary>
        /// Sets up the mocks used in this test class.
        /// </summary>
        protected override void Stub()
        {
            base.Stub();
        }

        /// <summary>
        /// Performs assertions common to all tests.
        /// </summary>
        protected override void AssertCore()
        {
            base.AssertCore();
        }

        #endregion Stub, AssertCore

        #region Private methods

        /// <summary>
        /// Encapsulates the execution of the test.
        /// </summary>
        /// <returns>The result of the test execution</returns>
        private bool Act()
        {
            return BigInteger.TryParse(this._numString, out this._bigInt);
        }

        #endregion Private methods
    }
}
