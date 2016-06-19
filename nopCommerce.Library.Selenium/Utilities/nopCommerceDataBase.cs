using nopCommerce.Library.Selenium.Configuration;
using nopCommerce.Library.Selenium.SQLScripts;

namespace nopCommerce.Library.Selenium.Utilities
{
    public class nopCommerceDataBase
    {
        private readonly SqlClient _client;
        private readonly ResourceRepository _resources;

        public nopCommerceDataBase()
        {
            _client = new SqlClient(GlobalSettings.nopCommerceConnectionString);
            _resources = new ResourceRepository();
        }

        public string SelectAProduct()
        {
            return _client.ExecuteScalar(_resources.GetScript("SelectAFirstProductWithAMinimumQuantityOf1.txt"));
        }
    }
}
