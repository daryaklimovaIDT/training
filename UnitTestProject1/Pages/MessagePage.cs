using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using UnitTestProject1;

namespace UnitTestsMail.Pages
{
    public class MessagePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='js-item-checkbox b-datalist__item__cbx']")]
        private IList<IWebElement> MessagesChekBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='b-sticky']//span[contains(text(), 'пам')]")]
        private IWebElement SpamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-id='approve']")]
        private IWebElement ApproveSpamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-id='950']")]
        private IWebElement SpamField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='b-sticky']//a[@data-bem='b-toolbar__btn']")]
        private IWebElement CreateMessageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-bem='b-flag']")]
        private IList<IWebElement> MessagesFlags { get; set; }

        public MessagePage()
        {
            PageFactory.InitElements(WebDriverUtil.GetInstance(), this);
        }

        public void ChooseFirstMessage()
        {
            WebDriverWaitUtil.WaitForElementToBeClickable(MessagesChekBoxes[0]);
            Click(MessagesChekBoxes[0]);
        }

        public void СlickSpamButton()
        {
            Click(SpamButton);
        }

        public void ClickApproveSpamButton()
        {
            WebDriverWaitUtil.WaitForElementToBeClickable(ApproveSpamButton);
            Click(ApproveSpamButton);
        }

        public void ClickSpamField()
        {
            WebDriverWaitUtil.WaitForElementToBeClickable(SpamField);
            Click(SpamField);
        }


        public bool IsMessageListEmty()
        {
            return MessagesChekBoxes.Count == 0;
        }

        public SendMessagePage ClickCreateMessageButton()
        {
            Click(CreateMessageButton);
            return new SendMessagePage();
        }

        public void ChooseSeveralMessagesFlags()
        {
            Click(MessagesFlags[0]);
            Click(MessagesFlags[1]);
            Click(MessagesFlags[2]);
        }

    }
}