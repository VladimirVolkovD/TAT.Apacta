using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests represents the main tests
    /// </summary>
    [TestFixture]
    public class MainTests : BaseTest
    {
        /// <summary>
        /// Navigate to the main url
        /// </summary>
        [Test]
        public void NavigateToBaseUrl()
        {
            Assert.AreEqual("https://apacta.com/",WebDriver.Url);
        }
    }
}