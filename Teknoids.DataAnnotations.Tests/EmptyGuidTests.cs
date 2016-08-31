using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teknoids.DataAnnotations.Tests
{
    /// <summary>
    /// Summary description for EmptyGuidTests
    /// </summary>
    [TestClass]
    public class EmptyGuidTests
    {

        private NonEmptyGuidAttribute attribute;

        [TestInitialize]
        public void Setup()
        {
            attribute = new NonEmptyGuidAttribute();
        }
        [TestMethod]
        public void Attribute_Should_allow_null_value()
        {
            var result = attribute.IsValid(null);

            Assert.IsTrue(result, "should allow null value");
        }

        [TestMethod]
        public void Attribute_Not_Allow_bad_Guid()
        {
            var result = attribute.IsValid("D1EF4E7C-FD3B-46C7-AC5D");

            Assert.IsFalse(result, "should not allow bad value");
        }

        [TestMethod]
        public void Attribute_Not_Allow_Empty_Guid()
        {
            var result = attribute.IsValid(Guid.Empty);

            Assert.IsFalse(result, "should not allow empty value");
        }
    }
}
