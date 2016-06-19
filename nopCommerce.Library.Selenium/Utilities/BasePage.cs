using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace nopCommerce.Library.Selenium.Utilities
{
    public class BasePage
    {
        protected RemoteWebDriver Driver { get; private set; }

        protected BasePage(RemoteWebDriver driver)
        {
            Driver = driver;

            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(10)));
        }
    }
}
