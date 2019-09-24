using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsMail.Pages
{
    public abstract class BasePage 
    {
        public abstract bool IsPageLoaded();

        public void AssertPageIsLoaded()
        {
            Assert.IsTrue(IsPageLoaded());
        }
    }
}
