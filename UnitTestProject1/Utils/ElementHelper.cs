using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Utils
{
    public static class ElementHelper
    {
        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }

        public static void ClearAndSendText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void SendText(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static bool IsElementDisplayed(this IWebElement element)
        {
            try
            {
                WebDriverWaitUtil.WaitForElementToBeVisible(element);
            }
            catch (TimeoutException)
            {
                return false;
            }

            return true;
        }
    }
}
