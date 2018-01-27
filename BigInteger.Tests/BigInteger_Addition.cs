using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigInteger.Tests
{
    /// <summary>
    /// Tests the Addition operator.
    /// </summary>
    [TestClass]
    public class BigInteger_Addition : UnitTestContainer
    {
        #region Fields

        /// <summary>
        /// The left operand.
        /// </summary>
        private BigInteger _lOperand;

        /// <summary>
        /// The right operand.
        /// </summary>
        private BigInteger _rOperand;

        #endregion Fields

        #region Test Initialise

        /// <summary>
        /// Executed before each unit test to initialise data.
        /// </summary>
        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();

            this._lOperand = default(BigInteger);
            this._rOperand = default(BigInteger);
        }

        #endregion Test Initialise

        #region Tests

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void Addition_UnderValidCircumstances_WithCarrying_ExpectSuccess()
        {
            // Arrange:
            this._lOperand = new BigInteger("550");
            this._rOperand = new BigInteger("550");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.AreEqual("1100", actual.ToString());
            this.AssertCore();
        }
        
        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void Addition_UnderValidCircumstances_NoCarrying_ExpectSuccess()
        {
            // Arrange:
            this._lOperand = new BigInteger("222");
            this._rOperand = new BigInteger("111");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.AreEqual("333", actual.ToString());
            this.AssertCore();
        }
        
        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void Addition_UnderValidCircumstances_BothNegative_ExpectSuccess()
        {
            // Arrange:
            this._lOperand = new BigInteger("-222");
            this._rOperand = new BigInteger("-555");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(actual.IsNegative);
            Assert.AreEqual("-777", actual.ToString());
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
            return this._lOperand + this._rOperand;
        }

        #endregion Private methods
    }
}
