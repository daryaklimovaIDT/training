using Mono.CSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject1;
using UnitTestProject1.Utils;

namespace UnitTestsMail.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "mailbox:login")]
        private IWebElement LoginField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='mailbox:password']")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='o-control']")]
        private IWebElement EnterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='PH_logoutLink']")]
        private IWebElement LogoutLink { get; set; }

        public LoginPage()
        {
            PageFactory.InitElements(WebDriverUtil.GetInstance(), this);
        }

        public void LogIn(string login, string password)
        {
            LoginField.ClearAndSendText(login);
            EnterButton.ClickElement();
            WebDriverWaitUtil.WaitForElementToBeVisible(PasswordField);
            PasswordField.ClearAndSendText(password);
        }

        public MessagePage ClickEnterButton()
        {
            EnterButton.ClickElement();
            return new MessagePage();
        }

        public bool IsLogoutDisplayed()
        {
            WebDriverWaitUtil.WaitForElementToBeVisible(LogoutLink);
            return LogoutLink.Displayed;
        }

        public override bool IsPageLoaded()
        {
            return LoginField.IsElementDisplayed();
        }
    }
}
