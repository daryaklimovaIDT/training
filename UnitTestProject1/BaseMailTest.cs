

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestsMail.Pages;

namespace UnitTestsMail
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver _driver;
        protected LoginPage loginPage;


        [SetUp]
        public virtual void SetUp()
        {
            _driver = WebDriverUtil.GetInstance();
            _driver.Manage().Window.Maximize();
         
        }

        [TearDown]
        public virtual void TearDown()
        {
            WebDriverUtil.DisposeDriver();
        }

    }


}
