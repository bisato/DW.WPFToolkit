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
