using nopCommerce.Library.Selenium.Utilities;
using NUnit.Framework;

namespace nopCommerce.Tests.Selenium.Utilities
{
    public class TestBase : Browser
    {
        [SetUp]
        public void DriverInitialize()
        {
            Start();
        }

        [TearDown]
        public void DriverCleanup()
        {
            Quit();
        }
    }
}
