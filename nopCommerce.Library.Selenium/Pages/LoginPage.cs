using nopCommerce.Library.Selenium.Configuration;
using nopCommerce.Library.Selenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace nopCommerce.Library.Selenium.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(RemoteWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.XPath, Using = "//input[@value='Log in']")]
        private IWebElement loginButton;

        public LoginPage GoTo()
        {
            Driver.Navigate().GoToUrl(GlobalSettings.BaseAddress + "login");

            return this;
        }

        public LoginPage LoginAs(string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            loginButton.Click();

            return this;
        }
    }
}
