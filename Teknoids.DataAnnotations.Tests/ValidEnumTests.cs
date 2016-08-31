using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teknoids.DataAnnotations.Tests
{
    /// <summary>
    /// Summary description for ValidEnumTests
    /// </summary>
    [TestClass]
    public class ValidEnumTests
    {
        private ValidEnumValueAttribute attribute;

        public enum MyEnum
        {
            Apple = 0,
            Pear = 1,
            Banana = 3
        }

        [TestInitialize]
        public void Setup()
        {
            attribute = new ValidEnumValueAttribute();
        }
        [TestMethod]
        public void Attribute_Should_Not_allow_null_value()
        {
            var result = attribute.IsValid(null);

            Assert.IsFalse(result, "should not allow null value");
        }

        [TestMethod]
        public void Attribute_Should_Not_allow_Non_existing_Enum_value()
        {
            var result = attribute.IsValid(4);

            Assert.IsFalse(result, "should not allow missing enum value");
        }

        [TestMethod]
        public void Attribute_Should_Not_allow_Non_existing_Enum_value_string()
        {
            var result = attribute.IsValid("Car");

            Assert.IsFalse(result, "should not allow missing enum value");
        }

        [TestMethod]
        public void Attribute_Should__allow_existing_Enum_value_string()
        {
            var result = attribute.IsValid("Apple");

            Assert.IsTrue(result, "should allow enum value");
        }

        [TestMethod]
        public void Attribute_Should__allow_existing_Enum_value()
        {
            var result = attribute.IsValid(0);

            Assert.IsTrue(result, "should allow enum value");
        }
    }
}
