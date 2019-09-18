using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsMail.Pages
{
    public class BasePage
    {
        protected void Click(IWebElement element)
        {
            element.Click();
        }
        protected void Clear(IWebElement element)
        {
            element.Clear();
        }
        protected void SendText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
    }
}
