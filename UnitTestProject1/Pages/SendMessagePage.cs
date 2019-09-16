using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Text;

namespace UnitTestsMail.Pages
{
    public class SendMessagePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//textarea[@data-original-name='To']")]
        private IWebElement ToWhomField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='b-input']")]
        private IWebElement ThemeField { get; set; }

        [FindsBy(How = How.XPath, Using = "//body[@id='tinymce']")]
        private IWebElement MessageTextField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"b-toolbar__right\"]/div[3]/div/div[2]/div[1]/div/span")]
        private IWebElement SendButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id,'composeEditor_ifr')]")]
        private IWebElement FrameElement { get; set; }

        [FindsBy(How = How.ClassName, Using = "message-sent__title")]
        private IWebElement MessageSentMessage { get; set; }

        public SendMessagePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void EnterRecipients(string recipients)
        {
            for (int i = 0; i < recipients.Length; i++)
            {
                char letter = recipients[i];
                string stringLetter = new StringBuilder().Append(letter).ToString();
                ToWhomField.SendKeys(stringLetter);
            }
        }

        public void EnterTheme(string themeText)
        {
            ThemeField.SendKeys(themeText);
        }

        public void EnterMessageText(string messageText)
        {
            _driver.SwitchTo().Frame(0);
            MessageTextField.SendKeys(messageText);
            _driver.SwitchTo().DefaultContent();
        }

        public void SendButtonClick()
        {
            SendButton.Click();
        }

        public bool MessageIsSent()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return MessageSentMessage.Displayed;
        }
    }
}