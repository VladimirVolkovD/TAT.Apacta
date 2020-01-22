using Core.WebDriver;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Base test for all web driver tests.
    /// Handles majority of basic set up for every test that uses a single WebDriver browser
    /// </summary>
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver WebDriver;

        [SetUp]
        public void SetUp()
        {
            WebDriver = DriverContext.Driver;
            WebDriver.Navigate().GoToUrl("https://apacta.com/");
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver?.Quit();
        }
    }
}