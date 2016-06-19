using System.Configuration;

namespace nopCommerce.Library.Selenium.Configuration
{
    public static class GlobalSettings
    {
        public static string BaseAddress
        {
            get { return ConfigurationManager.AppSettings["BaseAddress"]; }
        }

        public static bool RunRemote
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["RunRemote"]); }
        }

        public static string RemoteAddress
        {
            get { return ConfigurationManager.AppSettings["RemoteAddress"]; }
        }

        public static string nopCommerceConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ConnectionDB"]].ConnectionString; }
        }

        public static string SqlScriptsPath
        {
            get { return ConfigurationManager.AppSettings["SqlScriptsPath"]; }
        }

        public static string ScreenshotsFolderPath
        {
            get { return ConfigurationManager.AppSettings["ScreenshotsFolderPath"]; }
        }
    }
}
