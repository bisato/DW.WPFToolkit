using System;
using System.Globalization;
using DW.WPFToolkit.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.WPFToolkit.Tests.Converters
{
    [TestClass]
    public class NullToBooleanConverterTests
    {
        private NullToBooleanConverter _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new NullToBooleanConverter();
        }

        [TestMethod]
        public void Convert_NullAndNullIsTrue_ReturnsTrue()
        {
            var result = _target.Convert(null, typeof(bool), NullToBooleanDirection.NullIsTrue, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void Convert_NullAndNullIsFalse_ReturnsFalse()
        {
            var result = _target.Convert(null, typeof(bool), NullToBooleanDirection.NullIsFalse, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Convert_NullWithoutParameter_ReturnsFalse()
        {
            var result = _target.Convert(null, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Convert_NullWithUnexpectedParameter_ReturnsFalse()
        {
            var result = _target.Convert(null, typeof(bool), "hans", CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Convert_NotNullAndNullIsTrue_ReturnsFalse()
        {
            var result = _target.Convert("hans", typeof(bool), NullToBooleanDirection.NullIsTrue, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Convert_NotNullAndNullIsFalse_ReturnsTrue()
        {
            var result = _target.Convert("hans", typeof(bool), NullToBooleanDirection.NullIsFalse, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void Convert_NotNullWithoutParameter_ReturnsTrue()
        {
            var result = _target.Convert("hans", typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void Convert_NotNullWithUnexpectedParameter_ReturnsTrue()
        {
            var result = _target.Convert("hans", typeof(bool), "hans", CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod, ExpectedException(typeof(NotImplementedException))]
        public void ConvertBack_Called_ThrowsException()
        {
            _target.ConvertBack(null, typeof(object), null, CultureInfo.InvariantCulture);
        }
    }
}
