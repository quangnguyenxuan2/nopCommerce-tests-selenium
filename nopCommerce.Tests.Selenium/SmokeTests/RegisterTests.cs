using nopCommerce.Library.Selenium.Pages;
using nopCommerce.Tests.Selenium.Utilities;
using NUnit.Framework;
using System;

namespace nopCommerce.Tests.Selenium.SmokeTests
{
    [TestFixture]
    public class RegisterTests : TestBase
    {
        #region TestData

        string userFirstName = "John";
        string userLastName = "Smith";
        string userEmail = "john.smith" + DateTime.Now.ToString("yyyyMMddHHmmss") + "@test.com";
        string userPassword = "password3";
        string userSuccessMessage = "Your registration completed";
        string existingEmail = "john.smith@test.com";
        string emailAlreadyExistsMessage = "The specified email already exists";

        #endregion

        [Test]
        public void User_Can_Register()
        {
            RegisterPage registerPage = new RegisterPage(Driver)
                .GoTo()
                .Register(userFirstName, userLastName, userEmail, userPassword);

            Assert.That(Driver.PageSource, Does.Contain(userSuccessMessage));
        }

        [Test]
        public void User_Tries_To_Register_With_An_Existing_Email()
        {
            RegisterPage registerPage = new RegisterPage(Driver)
                .GoTo()
                .Register(userFirstName, userLastName, existingEmail, userPassword);

            Assert.That(Driver.PageSource, Does.Contain(emailAlreadyExistsMessage));
        }
    }
}
