using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.WebDriver
{
    /// <summary>
    /// Represents browser instance and base methods
    /// </summary>
    public static class Browser
    {
        public static void NavigateTo(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public static bool UrlContains(this IWebDriver webDriver, string partialUrl)
        {
            return webDriver.Url.Contains(partialUrl);
        }
        
        internal static bool BrowserAlreadyExist(IWebDriver driver)
        {
            var browserProperty = TestContext.CurrentContext.Test.Properties.Keys;
            return !browserProperty.Any(e => e.Contains($"{TestContext.CurrentContext.Test.Name}_driver")) ||
                   browserProperty.FirstOrDefault(e => e.Contains($"{TestContext.CurrentContext.Test.Name}_driver")) ==
                   null || driver == null;
        }
    }
}