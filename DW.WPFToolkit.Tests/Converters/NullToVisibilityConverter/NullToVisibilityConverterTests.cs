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
using System.Windows;
using DW.WPFToolkit.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.WPFToolkit.Tests.Converters
{
    [TestClass]
    public class NullToVisibilityConverterTests
    {
        private NullToVisibilityConverter _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new NullToVisibilityConverter();
        }

        [TestMethod]
        public void Convert_NullAndNullIsVisible_ReturnsVisible()
        {
            var result = _target.Convert(null, typeof(Visibility), NullToVisibilityDirection.NullIsVisible, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_NullAndNullIsCollapsed_ReturnsCollapsed()
        {
            var result = _target.Convert(null, typeof(Visibility), NullToVisibilityDirection.NullIsCollapsed, CultureInfo.InvariantCulture);
            
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_NullAndNullIsHidden_ReturnsHidden()
        {
            var result = _target.Convert(null, typeof(Visibility), NullToVisibilityDirection.NullIsHidden, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Hidden, result);
        }

        [TestMethod]
        public void Convert_NullAndNoParameter_ReturnsCollapsed()
        {
            var result = _target.Convert(null, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_NullAndUnknownParameter_ReturnsCollapsed()
        {
            var result = _target.Convert(null, typeof(Visibility), "hans", CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_NotNullAndNullIsVisible_ReturnsCollapsed()
        {
            var result = _target.Convert("hans", typeof(Visibility), NullToVisibilityDirection.NullIsVisible, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_NotNullAndNullIsCollapsed_ReturnsVisible()
        {
            var result = _target.Convert("hans", typeof(Visibility), NullToVisibilityDirection.NullIsCollapsed, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_NotNullAndNullIsHidden_ReturnsVisible()
        {
            var result = _target.Convert("hans", typeof(Visibility), NullToVisibilityDirection.NullIsHidden, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_NotNullAndNoParameter_ReturnsVisible()
        {
            var result = _target.Convert("hans", typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_NotNullAndUnknownParameter_ReturnsVisible()
        {
            var result = _target.Convert("hans", typeof(Visibility), "hans", CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod, ExpectedException(typeof(NotImplementedException))]
        public void ConvertBack_Called_ThrowsException()
        {
            _target.ConvertBack(null, typeof(Visibility), null, CultureInfo.InvariantCulture);
        }
    }
}
