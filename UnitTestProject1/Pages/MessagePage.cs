using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using UnitTestProject1;

using UnitTestProject1.Utils;
namespace UnitTestsMail.Pages
{
    public class MessagePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-nav_folders')]//a[@href='/messages/inbox/']")]
        private IWebElement InboxButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='js-item-checkbox b-datalist__item__cbx']")]
        private IList<IWebElement> MessagesCheckboxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='b-sticky']//span[contains(text(), 'пам')]")]
        private IWebElement MoveToSpamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-id='approve']")]
        private IWebElement ApproveSpamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-id='950']")]
        private IWebElement SpamFolderButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='b-sticky']//a[@data-bem='b-toolbar__btn']")]
        private IWebElement CreateMessageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-bem='b-flag']")]
        private IList<IWebElement> MessagesFlags { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-datalist_letters_from')]//div[@class='b-datalist__item__subj']")]
        private IList<IWebElement> MessagesSubjects { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-mnemo='flagged']")]
        private IWebElement FlagsIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-datalist__item')]//div[@class='b-datalist__item__subj']")]
        private IList<IWebElement> FlagMessagesSubjects { get; set; }


        public MessagePage()
        {
            PageFactory.InitElements(WebDriverUtil.GetInstance(), this);
        }

        public void CheckMessage(int index)
        {
            MessagesCheckboxes[index].WaitForElementToBeClickable();
            MessagesCheckboxes[index].ClickElement(); ;
        }

        public void СlickSpamButton()
        {
            MoveToSpamButton.ClickElement();
        }

        public void ClickApproveSpamButton()
        {
            ApproveSpamButton.WaitForElementToBeClickable();
            ApproveSpamButton.ClickElement();
        }

        public void MoveMessageToSpam(int index)
        {
            CheckMessage(index);
            СlickSpamButton();
            ClickApproveSpamButton();
        }

        public void NavigateToSpamFolder()
        {
            SpamFolderButton.WaitForElementToBeClickable();
            SpamFolderButton.ClickElement();
        }


        public bool IsMessageListEmty()
        {
            return MessagesCheckboxes.Count == 0;
        }

        public SendMessagePage ClickCreateMessageButton()
        {
            CreateMessageButton.ClickElement();
            return new SendMessagePage();
        }

        public void FlagMessage(int index)
        {
            MessagesFlags[index].ClickElement();
        }

        public void СlickFlagIcon()
        {
            FlagsIcon.ClickElement();
        }



        public override bool IsPageLoaded()
        {
            return InboxButton.IsElementDisplayed();
        }

        public List<string> GetMessages()
        {
            List<string> messages = new List<string>();
            foreach (IWebElement message in MessagesSubjects)
            {
                string subjectText = message.Text;
                messages.Add(subjectText);
            }
            return messages;
        }

        public List<string> GetFlaggedMessages()
        {
            List<string> messages = new List<string>();
            foreach (IWebElement message in FlagMessagesSubjects)
            {
                string subjectText = message.Text;
                messages.Add(subjectText);
            }
            return messages;
        }
    }
}