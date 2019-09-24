using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsMail;

namespace UnitTestProject1
{
    public static class WebDriverWaitUtil
    {
        public static void WaitForElementToBeVisible(this IWebElement element, int timeOut = 5)
        {
            new WebDriverWait(WebDriverUtil.GetInstance(), TimeSpan.FromSeconds(timeOut)).Until(ElementIsVisible(element));
        }

        public static void WaitForElementToBeClickable(this IWebElement element, int timeOut = 5)
        {
            new WebDriverWait(WebDriverUtil.GetInstance(), TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementToBeClickable(element));
        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver=>
            {
                try
                {
                    return element.Displayed;                    
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }
    }
}
