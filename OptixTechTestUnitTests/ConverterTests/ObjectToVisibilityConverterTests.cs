using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptixTechTest.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OptixTechTestUnitTests.ConverterTests
{
    [TestClass]
    public class ObjectToVisibilityConverterTests
    {
        private ObjectToVisibilityConverter _visibilityConverter;

        [TestInitialize]
        public void Initialise()
        {
            _visibilityConverter = new ObjectToVisibilityConverter();
        }

        [TestMethod]
        public void ConvertingNullDoesNotThrowException()
        {
            _visibilityConverter.Invoking(v => v.Convert(null, null, null, null)).Should().NotThrow<NullReferenceException>();
        }

        [TestMethod]
        public void ConvertingNullReturnsHidden()
        {
            var visibility = _visibilityConverter.Convert(null, null, null, null);

            visibility.Should().Be(Visibility.Hidden);
        }

        [TestMethod]
        public void ConvertingObjectReturnsVisible()
        {
            Object obj = new Object();

            var visibility = _visibilityConverter.Convert(obj, null, null, null);

            visibility.Should().Be(Visibility.Visible);
        }
    }
}
