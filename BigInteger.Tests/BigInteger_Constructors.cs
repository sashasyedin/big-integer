using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigInteger.Tests
{
    /// <summary>
    /// Tests the Constructors.
    /// </summary>
    [TestClass]
    public class BigInteger_Constructors : UnitTestContainer
    {
        #region Fields

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

            this._numString = string.Empty;
        }

        #endregion Test Initialise

        #region Tests

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void Constructors_WhenStringArgumentIsNull_ExpectParsingFailed()
        {
            // Arrange:
            this._numString = null;
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.AreEqual("0", actual.ToString());
            this.AssertCore();
        }

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void Constructors_UnderValidCircumstances_ExpectSuccess()
        {
            // Arrange:
            this._numString = "12345";
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsFalse(actual.IsNegative);
            Assert.AreEqual(this._numString, actual.ToString());
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
        private BigInteger Act()
        {
            return new BigInteger(this._numString);
        }

        #endregion Private methods
    }
}
