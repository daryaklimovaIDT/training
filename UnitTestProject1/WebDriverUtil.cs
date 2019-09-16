using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsMail
{
    public class WebDriverUtil
    {
        private static IWebDriver instance;

        private WebDriverUtil()
        {

        }

        public static IWebDriver GetInstance()
        {
            if (instance == null)
            {
                instance = new ChromeDriver();
            }
            return instance;
        }

        public static void DisposeDriver()
        {
            instance.Quit();
            instance = null;
        }

    }
}
