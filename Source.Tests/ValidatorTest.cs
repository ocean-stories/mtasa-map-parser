using Microsoft.VisualStudio.TestTools.UnitTesting;

using Parser;

namespace Source.Tests
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void AreCategoriesValid_AllInvalidCategories_ReturnFalse()
        {
            string[] categories = { "LOL", "OMG", "XD" };
            bool expected = false;

            bool actual = Validator.AreCategoriesValid(categories);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreCategoriesValid_AllValidCategories_ReturnTrue()
        {
            string[] categories = { Shared.ExistingCategories[0], Shared.ExistingCategories[1] };
            bool expected = true;

            bool actual = Validator.AreCategoriesValid(categories);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreCategoriesValid_ValidAndInvalidCategories_ReturnFalse()
        {
            string[] categories = { Shared.ExistingCategories[0], Shared.ExistingCategories[1], "OMG" };
            bool expected = false;

            bool actual = Validator.AreCategoriesValid(categories);

            Assert.AreEqual(expected, actual);
        }
    }
}
