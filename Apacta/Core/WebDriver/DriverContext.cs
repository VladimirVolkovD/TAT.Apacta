using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Framework.Internal;

namespace Core.WebDriver
{
    /// <summary>
    /// Represent WebDriver
    /// </summary>
    public static class DriverContext
    {
        private static IWebDriver _driver;
        
        public static IWebDriver Driver
        {
            get
            {
                lock (TestContext.CurrentContext.Test.Name)
                {
                    if (Browser.BrowserAlreadyExist(_driver))
                    {
                        _driver = WebDriverFactory.GetDriver(Configuration.Browser, Configuration.ElementTimeout);
                        TestExecutionContext.CurrentContext.CurrentTest.Properties.Add(
                            $"{TestContext.CurrentContext.Test.Name}_driver", _driver);
                    }
                }

                return TestContext.CurrentContext.GetDriver();
            }
        }

        private static IWebDriver GetDriver(this TestContext context)
        {
            return (IWebDriver) TestContext.CurrentContext.Test.Properties.Get($"{TestContext.CurrentContext.Test.Name}_driver");
        }
    }
}