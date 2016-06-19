using nopCommerce.Library.Selenium.Configuration;
using nopCommerce.Library.Selenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace nopCommerce.Library.Selenium.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(RemoteWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "small-searchterms")]
        private IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//input[@value='Search']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add to cart']")] 
        private IWebElement addToCartButton;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add to cart']")]
        private IWebElement addToCartDetailsButton;

        public ProductPage GoTo()
        {
            Driver.Navigate().GoToUrl(GlobalSettings.BaseAddress);

            return this;
        }

        public ProductPage SearchForAProduct(string productName)
        {
            searchInput.SendKeys(productName);
            searchButton.Click();

            return this;
        }

        public ProductPage AddToCart()
        {
            addToCartButton.Click();
            addToCartDetailsButton.Click();
            return this;
        }
    }
}
