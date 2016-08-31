using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teknoids.DataAnnotations.Tests
{
    [TestClass]
    public class RequiredIfTests
    {
        private RequiredIfAttribute attribute;

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void Required_Condition_Is_is_Met()
        {
            attribute = new RequiredIfAttribute((1 + 1 == 2));
            var result = attribute.IsValid(null);

            Assert.IsFalse(result, "is required");
        }

        [TestMethod]
        public void Required_If_Condition_Is_true_and_has_data()
        {
            attribute = new RequiredIfAttribute((1 + 1 == 2));
            var result = attribute.IsValid("value");

            Assert.IsTrue(result, "is valid");
        }

        [TestMethod]
        public void Not_Required_If_Condition_Is_false()
        {
            attribute = new RequiredIfAttribute((1 + 1 == 3));
            var result = attribute.IsValid(null);

            Assert.IsTrue(result, "is not required");
        }

        [TestMethod]
        public void Not_Required_If_Condition_Is_false_but_has_data()
        {
            attribute = new RequiredIfAttribute((1 + 1 == 3));
            var result = attribute.IsValid(null);

            Assert.IsTrue(result, "should be valid");
        }
    }
}
