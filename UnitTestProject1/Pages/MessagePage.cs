using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace UnitTestsMail.Pages
{
    public class MessagePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='js-item-checkbox b-datalist__item__cbx']")]
        private IList<IWebElement> MessagesChekBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"b-toolbar__right\"]/div[2]/div/div[2]/div[3]/div")]
        private IWebElement SpamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-id='approve']")]
        private IWebElement ApproveSpamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-id='950']")]
        private IWebElement SpamField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"b-toolbar__left\"]/div/div/div[2]/div/a/span")]
        private IWebElement CreateMessageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-bem='b-flag']")]
        private IList<IWebElement> MessagesFlags { get; set; }


        public MessagePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToLoad()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.TitleContains("Входящие"));
        }

        public void ChooseFirstMessage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            MessagesChekBoxes[0].Click();
        }

        public void СlickSpamButton()
        {
            SpamButton.Click();
        }

        public void ClickApproveSpamButton()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ApproveSpamButton.Click();
        }

        public void ClickSpamField()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SpamField.Click();
        }


        public bool IsMessageListEmty()
        {
            return MessagesChekBoxes.Count == 0;
        }

        public SendMessagePage ClickCreateMessageButton()
        {
            CreateMessageButton.Click();
            return new SendMessagePage(_driver);
        }

        public void ChooseSeveralMessagesFlags()
        {
            MessagesFlags[0].Click();
            MessagesFlags[1].Click();
            MessagesFlags[2].Click();
        }

    }
}