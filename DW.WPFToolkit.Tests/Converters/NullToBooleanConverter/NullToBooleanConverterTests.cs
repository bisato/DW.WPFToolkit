#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2015 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

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
