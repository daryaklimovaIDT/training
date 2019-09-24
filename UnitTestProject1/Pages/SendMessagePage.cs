using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTestProject1;
using UnitTestProject1.Utils;
using UnitTestsMail.Entities;

namespace UnitTestsMail.Pages
{
    public class SendMessagePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@data-original-name='To']")]
        private IWebElement ToWhomField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='b-input']")]
        private IWebElement SubjectField { get; set; }

        [FindsBy(How = How.XPath, Using = "//body[@id='tinymce']")]
        private IWebElement MessageTextField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='b-sticky']//span[text()='Отправить']")]  
        private IWebElement SendButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id,'composeEditor_ifr')]")]
        private IWebElement FrameElement { get; set; }

        [FindsBy(How = How.ClassName, Using = "message-sent__title")]
        private IWebElement MessageSentMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-nav_folders')]//a[@href='/messages/sent/']")]
        private IWebElement SentMessagesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-datalist_letters_to')]//div[@class='b-datalist__item__subj']")]
        private IList<IWebElement> MessagesSubjects { get; set; }

        public SendMessagePage()
        {
            PageFactory.InitElements(WebDriverUtil.GetInstance(), this);
        }

        public void EnterRecipients(List<Recipient> recipients)
        {
            foreach (Recipient recipient in recipients)
            {
                if (recipients.IndexOf(recipient) == 0)
                {
                    EnterRecipient(recipient);
                    continue;
                }
                ToWhomField.SendText(" ");
                EnterRecipient(recipient);
            }
        }

        public void EnterRecipient(Recipient recipient)
        {
            for (int i = 0; i < recipient.Email.Length; i++)
            {
                ToWhomField.SendText(recipient.Email[i].ToString());
            }
        }

        public void EnterSubject(string themeText)
        {
            SubjectField.ClearAndSendText(themeText);
        }

        public void EnterMessage(string messageText)
        {
            WebDriverUtil.SwtichToFrame(0);
            MessageTextField.SendText(messageText);
            WebDriverUtil.SwtichToDefaultContent();
        }

        public void SendButtonClick()
        {
            SendButton.ClickElement();
        }

        public bool CheckMessageIsSent()
        {
            WebDriverWaitUtil.WaitForElementToBeVisible(MessageSentMessage);
            return MessageSentMessage.IsElementDisplayed();
        }

        public override bool IsPageLoaded()
        {
            return SendButton.IsElementDisplayed();
        }

        public void SentMessagesButtonClick()
        {
            SentMessagesButton.ClickElement();
        }

        public List<string> GetSubjects()
        {
            List<string> subjects = new List<string>();
            foreach (IWebElement subject in MessagesSubjects)
            {
                string subjectText = subject.Text;
                subjects.Add(subjectText);
            }
            return subjects;
        }
    }
}