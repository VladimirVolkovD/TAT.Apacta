using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace  Core.WebDriver
{
    /// <summary>
    /// Represent process of creation WebDriver by browser type and set options
    /// </summary>
    public static class WebDriverFactory
    {
        public static IWebDriver GetDriver(BrowserType type, int timeOutSec = 30)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                {
                    var service = ChromeDriverService.CreateDefaultService();
                    var options = new ChromeOptions();
                    options.AddArguments("-incognito");
                    options.AddArguments("--start-maximized");
                    options.AddArgument("--privileged");
                    driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                    break;
                }
            }
            return driver;
        }
    }
}