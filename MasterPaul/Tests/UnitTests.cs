using Calculation;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetQuantityForProduct_NonExistentProductType()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(8, 1, 15, 20, 45);
            int correctResult = -1;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_NonExistentMaterialType()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 8, 15, 20, 45);
            int correctResult = -1;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_NegativeProductQuantity()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 4, -4, 20, 45);
            int correctResult = -1;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_NegativeProductWidth()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 4, 15, -20, 45);
            int correctResult = -1;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_NegativeProductLength()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 4, 15, 20, -45);
            int correctResult = -1;
            Assert.AreEqual(actualResult, correctResult);
        }

        //���������� 5 ++
        [TestMethod]
        public void GetQuantityForProduct_MaterialType1ProductType1_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(1, 1, 15, 20, 45);
            int correctResult = 34897;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_MaterialType2ProductType1_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(2, 1, 15, 20, 45);
            int correctResult = 76477;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_MaterialType3ProductType1_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 1, 15, 20, 45);
            int correctResult = 64449;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_MaterialType1ProductType2_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(1, 2, 15, 20, 45);
            int correctResult = 61863;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_MaterialType2ProductType2_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(2, 2, 15, 20, 45);
            int correctResult = 135573;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_MaterialType3ProductType2_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 2, 15, 20, 45);
            int correctResult = 114250;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_ZeroWidthAndLength_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 2, 15, 0, 0);
            int correctResult = 0;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_SmallValues_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 2, 1, 1, 1);
            int correctResult = 7;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_LargeProduct_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 2, 2, 500, 500);
            int correctResult = 4231500;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_VeryDifferentWidthLength_CorrectResult()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(3, 2, 2, 1, 1000);
            int correctResult = 16926;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_NullValue_ReturnMinusOne()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(Convert.ToInt32(null), Convert.ToInt32(null),
                Convert.ToInt32(null), Convert.ToInt32(null), Convert.ToInt32(null));
            int correctResult = -1;
            Assert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void GetQuantityForProduct_ReturnInt()
        {
            CalculationClass calculation = new CalculationClass();
            int actualResult = calculation.GetQuantityForProduct(2, 1, 15, 20, 45);
            Assert.IsInstanceOfType<int>(actualResult);
        }
    }
}