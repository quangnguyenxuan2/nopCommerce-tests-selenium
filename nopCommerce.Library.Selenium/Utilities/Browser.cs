using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing.Imaging;
using GlobalSettings = nopCommerce.Library.Selenium.Configuration.GlobalSettings;

namespace nopCommerce.Library.Selenium.Utilities
{
    public abstract class Browser
    {
        private readonly string _screenshotsFolderPath = String.Format("{0}{1}{2:yyyyMMddHHmmss}.png",
            GlobalSettings.ScreenshotsFolderPath, TestContext.CurrentContext.Test.Name, DateTime.Now);

        public nopCommerceDataBase DataBase { get; set; }

        public RemoteWebDriver Driver { get; private set; }

        public Browser()
        {
            DataBase = new nopCommerceDataBase();
        }

        public void Start()
        {
            Driver = GetDriver();
        }

        public void Quit()
        {
            if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure))
            {
                Driver.GetScreenshot().SaveAsFile(_screenshotsFolderPath, ImageFormat.Png);
            }
            Driver.Close();
        }

        private RemoteWebDriver GetDriver()
        {
            // Add: Choosing different browsers

            if (GlobalSettings.RunRemote)
            {
                return new RemoteWebDriver(new Uri(GlobalSettings.RemoteAddress), DesiredCapabilities.Firefox());
            }
            else
            {
                var browserDriver = new FirefoxDriver(new FirefoxProfile { EnableNativeEvents = true });
                browserDriver.Manage().Window.Maximize();
                return browserDriver;
            }
        }
    }
}
