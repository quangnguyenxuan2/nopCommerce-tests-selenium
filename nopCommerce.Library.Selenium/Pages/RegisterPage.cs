using nopCommerce.Library.Selenium.Configuration;
using nopCommerce.Library.Selenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace nopCommerce.Library.Selenium.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(RemoteWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement firstNameInput;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement lastNameInput;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement confirmPasswordInput;

        [FindsBy(How = How.Id, Using = "register-button")]
        private IWebElement registerButton;

        public RegisterPage GoTo()
        {
            Driver.Navigate().GoToUrl(GlobalSettings.BaseAddress + "register");

            return this;
        }

        public RegisterPage Register(string firstName, string lastName, string email, string password)
        {
            firstNameInput.SendKeys(firstName);
            lastNameInput.SendKeys(lastName);
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            confirmPasswordInput.SendKeys(password);
            registerButton.Click();
            
            return this;
        }
    }
}
