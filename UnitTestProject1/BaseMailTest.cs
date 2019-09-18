

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestsMail.Pages;

namespace UnitTestsMail
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public virtual void SetUp()
        {
            WebDriverUtil.GetInstance().Manage().Window.Maximize();
        }

        [TearDown]
        public virtual void TearDown()
        {
            WebDriverUtil.DisposeDriver();
        }

    }


}
