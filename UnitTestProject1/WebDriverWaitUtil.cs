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
    public class WebDriverWaitUtil
    {
        public static void WaitForElementToBeVisible(By locator)
        {
            new WebDriverWait(WebDriverUtil.GetInstance(), TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(IWebElement element)
        {
            new WebDriverWait(WebDriverUtil.GetInstance(), TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForPageToLoad(string titleText)
        {
            new WebDriverWait(WebDriverUtil.GetInstance(), TimeSpan.FromSeconds(5)).Until(ExpectedConditions.TitleContains(titleText));
        }
    }
}
