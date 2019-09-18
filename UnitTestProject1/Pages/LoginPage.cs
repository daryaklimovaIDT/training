using Mono.CSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject1;

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
            Clear(LoginField);
            SendText(LoginField, login);
            Click(EnterButton);
            WebDriverWaitUtil.WaitForElementToBeVisible(By.Id("mailbox:password"));
            SendText(PasswordField, password);
        }

        public MessagePage ClickEnterButton()
        {
            Click(EnterButton);
            return new MessagePage();
        }

        public bool IsLogoutDisplayed()
        {
            WebDriverWaitUtil.WaitForElementToBeVisible(By.Id("PH_logoutLink"));
            return LogoutLink.Displayed;
        }
    }
}
