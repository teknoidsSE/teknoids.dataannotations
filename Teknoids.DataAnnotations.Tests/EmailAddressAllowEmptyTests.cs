using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teknoids.DataAnnotations.Tests
{
    /// <summary>
    /// Summary description for EmailAddressAllowEmptyTests
    /// </summary>
    [TestClass]
    public class EmailAddressAllowEmptyTests
    {
        private EmailAddressAllowEmptyAttribute attribute;

        [TestInitialize]
        public void Setup()
        {
            attribute = new EmailAddressAllowEmptyAttribute();
        }
        [TestMethod]
        public void Attribute_Should_allow_null_value()
        {
            var result = attribute.IsValid(null);

            Assert.IsTrue(result, "should allow null value");
        }

        [TestMethod]
        public void Attribute_Should_allow_Empty_String()
        {
            var result = attribute.IsValid(string.Empty);

            Assert.IsTrue(result, "should allow empty value");
        }

        [TestMethod]
        public void Attribute_Should_allow_email()
        {
            var result = attribute.IsValid("test@test.com");

            Assert.IsTrue(result, "should allow email");
        }

        [TestMethod]
        public void Attribute_Should_Not_allow_bad_email()
        {
            var result = attribute.IsValid("test.test.com");

            Assert.IsFalse(result, "should not allow bad email");
        }
    }
}
