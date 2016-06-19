using nopCommerce.Library.Selenium.Pages;
using nopCommerce.Tests.Selenium.Utilities;
using NUnit.Framework;

namespace nopCommerce.Tests.Selenium.SmokeTests
{
    [TestFixture]
    public class ProductTests : TestBase
    {
        [Test]
        public void User_Can_Add_A_Product_To_Cart()
        {
            #region TestData
            string productName = DataBase.SelectAProduct(); // Select a first product that has a minimum quantity of 1
            string successMessage = "The product has been added";

            #endregion

            DataBase.SelectAProduct();
            ProductPage productsPage = new ProductPage(Driver)
            .GoTo()
            .SearchForAProduct(productName)
            .AddToCart();

            Assert.That(Driver.PageSource, Does.Contain(successMessage));
        }
    }
}
