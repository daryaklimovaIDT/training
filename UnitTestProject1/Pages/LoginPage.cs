using Mono.CSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace UnitTestsMail.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "mailbox:login")]
        private IWebElement LoginField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='mailbox:password']")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='o-control']")]
        private IWebElement EnterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='PH_logoutLink']")]
        private IWebElement LogoutLink { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogIn(string login, string password)
        {
            LoginField.Clear();
            LoginField.SendKeys(login);
            EnterButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PasswordField.SendKeys(password);
        }

        public MessagePage ClickEnterButton()
        {
            EnterButton.Click();
            return new MessagePage(_driver);
        }

        public bool IsLogoutDisplayed()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return LogoutLink.Displayed;
        }
    }
}
