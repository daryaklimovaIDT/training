using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Text;
using UnitTestProject1;

namespace UnitTestsMail.Pages
{
    public class SendMessagePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@data-original-name='To']")]
        private IWebElement ToWhomField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='b-input']")]
        private IWebElement ThemeField { get; set; }

        [FindsBy(How = How.XPath, Using = "//body[@id='tinymce']")]
        private IWebElement MessageTextField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='b-sticky']//span[text()='Отправить']")]
        private IWebElement SendButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id,'composeEditor_ifr')]")]
        private IWebElement FrameElement { get; set; }

        [FindsBy(How = How.ClassName, Using = "message-sent__title")]
        private IWebElement MessageSentMessage { get; set; }

        public SendMessagePage()
        {
            PageFactory.InitElements(WebDriverUtil.GetInstance(), this);
        }

        public void EnterRecipients(string recipients)
        {
            for (int i = 0; i < recipients.Length; i++)
            {
                char letter = recipients[i];
                string stringLetter = new StringBuilder().Append(letter).ToString();
                SendText(ToWhomField, stringLetter);
            }
        }

        public void EnterTheme(string themeText)
        {
            SendText(ThemeField, themeText);
        }

        public void EnterMessageText(string messageText)
        {
            WebDriverUtil.GetInstance().SwitchTo().Frame(0);
            SendText(MessageTextField, messageText);
            WebDriverUtil.GetInstance().SwitchTo().DefaultContent();
        }

        public void SendButtonClick()
        {
            Click(SendButton);
        }

        public bool MessageIsSent()
        {
            WebDriverWaitUtil.WaitForElementToBeVisible(By.ClassName("message-sent__title"));
            return MessageSentMessage.Displayed;
        }
    }
}