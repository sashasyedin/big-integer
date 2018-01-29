using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigInteger.Tests
{
    /// <summary>
    /// Tests the CompareTo method.
    /// </summary>
    [TestClass]
    public class BigInteger_CompareTo : UnitTestContainer
    {
        #region Fields

        /// <summary>
        /// The current BigInt.
        /// </summary>
        private BigInteger _bigInt1;

        /// <summary>
        /// The BigInt argument.
        /// </summary>
        private BigInteger _bigInt2;

        #endregion Fields

        #region Test Initialise

        /// <summary>
        /// Executed before each unit test to initialise data.
        /// </summary>
        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();

            this._bigInt1 = default(BigInteger);
            this._bigInt2 = default(BigInteger);
        }

        #endregion Test Initialise

        #region Tests

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenCurrentBigIntIsGreaterThanArgument_Expect1()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("12345");
            this._bigInt2 = new BigInteger("84");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt1 > this._bigInt2);
            Assert.AreEqual(1, actual);
            this.AssertCore();
        }
        
        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenCurrentBigIntIsGreaterThanArgument_AndBothNegative_Expect1()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("-123");
            this._bigInt2 = new BigInteger("-456");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt1.IsNegative);
            Assert.IsTrue(this._bigInt2.IsNegative);
            Assert.IsTrue(this._bigInt1 > this._bigInt2);
            Assert.AreEqual(1, actual);
            this.AssertCore();
        }
        
        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenArgumentIsNegative_Expect1()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("12345");
            this._bigInt2 = new BigInteger("-12345");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt2.IsNegative);
            Assert.IsTrue(this._bigInt1 > this._bigInt2);
            Assert.AreEqual(1, actual);
            this.AssertCore();
        }

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenCurrentBigIntIsLessThanArgument_ExpectMinus1()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("654");
            this._bigInt2 = new BigInteger("987");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt1 < this._bigInt2);
            Assert.IsTrue(this._bigInt1 != this._bigInt2);
            Assert.IsFalse(this._bigInt1 > this._bigInt2);
            Assert.IsFalse(this._bigInt1 == this._bigInt2);
            Assert.AreEqual(-1, actual);
            this.AssertCore();
        }
        
        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenCurrentBigIntIsLessThanArgument_AndBothNegative_ExpectMinus1()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("-567");
            this._bigInt2 = new BigInteger("-34");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt1.IsNegative);
            Assert.IsTrue(this._bigInt2.IsNegative);
            Assert.IsTrue(this._bigInt1 < this._bigInt2);
            Assert.IsFalse(this._bigInt1 > this._bigInt2);
            Assert.AreEqual(-1, actual);
            this.AssertCore();
        }
        
        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenCurrentBigIntIsNegative_ExpectMinus1()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("-654");
            this._bigInt2 = new BigInteger("12");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt1.IsNegative);
            Assert.IsTrue(this._bigInt1 < this._bigInt2);
            Assert.IsFalse(this._bigInt1 > this._bigInt2);
            Assert.AreEqual(-1, actual);
            this.AssertCore();
        }

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenCurrentBigIntIsEqualToArgument_Expect0()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("59090");
            this._bigInt2 = new BigInteger("59090");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt1 == this._bigInt2);
            Assert.IsFalse(this._bigInt1 != this._bigInt2);
            Assert.AreEqual(0, actual);
            this.AssertCore();
        }
        
        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [TestMethod]
        public void CompareTo_WhenCurrentBigIntIsEqualToArgument_AndBothNegative_Expect0()
        {
            // Arrange:
            this._bigInt1 = new BigInteger("-78911");
            this._bigInt2 = new BigInteger("-78911");
            this.Stub();

            // Act:
            var actual = this.Act();

            // Assert:
            Assert.IsTrue(this._bigInt1.IsNegative);
            Assert.IsTrue(this._bigInt2.IsNegative);
            Assert.IsTrue(this._bigInt1 == this._bigInt2);
            Assert.IsFalse(this._bigInt1 != this._bigInt2);
            Assert.AreEqual(0, actual);
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
        /// <returns>The result of the test execution.</returns>
        private int Act()
        {
            return this._bigInt1.CompareTo(this._bigInt2);
        }

        #endregion Private methods
    }
}
