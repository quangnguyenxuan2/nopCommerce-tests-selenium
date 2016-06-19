using System;
using System.IO;
using System.Reflection;

namespace nopCommerce.Library.Selenium.SQLScripts
{
    public class ResourceRepository
    {
        public string GetScript(string fileName)
        {
            var resourceName = string.Format("{0}.{1}", GetType().Namespace, fileName);
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null) throw new NotSupportedException(string.Format("Not found resource file: {0}", resourceName));
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
