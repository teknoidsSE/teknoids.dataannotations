using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teknoids.DataAnnotations.Tests
{
    [TestClass]
    public class CountryCodeTests
    {
        private CountryCodeAttribute attribute;

        [TestInitialize]
        public void Setup()
        {
            attribute = new CountryCodeAttribute();
        }
        [TestMethod]
        public void Attribute_Should_Allow_Valid_Codes()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid("US");
            //ASSET
            Assert.IsTrue(result, "This should be a valid code");
        }

        public void Attribute_Should_Fail_if_Code_is_Null()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid(null);
            //ASSET
            Assert.IsFalse(result, "This should not be a valid code");
        }

        public void Attribute_Should_Fail_if_Code_is_More_Than_two_Letters()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid("ABC");
            //ASSET
            Assert.IsFalse(result, "This should not be a valid code");
        }

        public void Attribute_Should_Fail_if_Code_is_Less_Than_two_Letters()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid("A");
            //ASSET
            Assert.IsFalse(result, "This should not be a valid code");
        }

        public void Attribute_Should_Fail_if_Code_is_not_Found()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid("QX");
            //ASSET
            Assert.IsFalse(result, "This should not be a valid code");
        }
    }
}
