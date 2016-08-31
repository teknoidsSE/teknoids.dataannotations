using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teknoids.DataAnnotations.Tests
{
    [TestClass]
    public class DateTimeOffsetTests
    {
        private DateTimeOffsetAttribute attribute;

        [TestInitialize]
        public void Setup()
        {
            attribute = new DateTimeOffsetAttribute();
        }
        [TestMethod]
        public void Attribute_Is_Not_Valid_Id_Null()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid(null);
            //ASSET
            Assert.IsFalse(result, "This should not be a datetimeoffset");
        }

        [TestMethod]
        public void Attribute_Is_Not_Valid_if_Not_Valid_Date()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid("2018-01-32");
            //ASSET
            Assert.IsFalse(result, "This should not be a datetimeoffset");
        }

        [TestMethod]
        public void Attribute_Is_Not_Valid_if_Date_min()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid(DateTimeOffset.MinValue);
            //ASSET
            Assert.IsFalse(result, "This should not be a datetimeoffset");
        }

        [TestMethod]
        public void Attribute_Is_Valid_if_Valid_Date()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid(DateTimeOffset.Now);
            //ASSET
            Assert.IsTrue(result, "This should be a datetimeoffset");
        }

        [TestMethod]
        public void Attribute_Is_Valid_if_Valid_Date_string()
        {
            //ARRANGE

            //ACT
            var result = attribute.IsValid("2018-01-01");
            //ASSET
            Assert.IsTrue(result, "This should be a datetimeoffset");
        }
    }
}
