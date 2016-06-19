using nopCommerce.Library.Selenium.Pages;
using nopCommerce.Tests.Selenium.Utilities;
using NUnit.Framework;

namespace nopCommerce.Tests.Selenium.SmokeTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        #region TestData

        string adminEmail = "admin@yourStore.com";
        string adminPassword = "password";
        string adminSuccessMessage = "admin@yourStore.com";
        string userEmail = "test@test.com";
        string userPassword = "password2";
        string userSuccessMessage = "test@test.com";

        #endregion


        [Test]
        public void Administrator_Can_Login()
        {
            LoginPage loginPage = new LoginPage(Driver)
                .GoTo()
                .LoginAs(adminEmail, adminPassword);

            Assert.That(Driver.PageSource, Does.Contain(adminSuccessMessage));
        }

        [Test]
        public void User_Can_Login()
        {
            LoginPage loginPage = new LoginPage(Driver)
                .GoTo()
                .LoginAs(userEmail, userPassword);

            Assert.That(Driver.PageSource, Does.Contain(userSuccessMessage));
        }
    }
}
