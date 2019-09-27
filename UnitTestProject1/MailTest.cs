
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1;
using UnitTestProject1.Temp;
using UnitTestProject1.Utils;
using UnitTestsMail.Entities;
using UnitTestsMail.Pages;

namespace UnitTestsMail
{
    [TestFixture]
    public class MailTest : BaseTest
    {
        private MessagePage messagePage;
        private SendMessagePage sendMessagePage;
        private LoginPage loginPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            User user = EntitiesManager.GetUser();
            loginPage = new LoginPage();
            WebDriverUtil.GetInstance().Navigate().GoToUrl(Config.URL);
            loginPage.AssertPageIsLoaded();
            loginPage.LogIn(user.Login, user.Password); 
            messagePage = loginPage.ClickEnterButton();
            messagePage.AssertPageIsLoaded();
            Assert.IsTrue(loginPage.IsLogoutDisplayed(), "Logout button was not displayed.");
        }

        [Test]
        public void TestMoveToSpam()
        {
            List<string> messages = messagePage.GetMessages();
            string expectedSpamSubject = messages[0];
            messagePage.MoveMessageToSpam(0);
            WebDriverUtil.Refresh();
            messagePage.NavigateToSpamFolder();
            List<string> spamMessages = messagePage.GetMessages();
            Assert.IsTrue(spamMessages.Any(actualSpamMessage => expectedSpamSubject.Contains(actualSpamMessage)), "The message is not in spam");
        }

        [Test]
        public void TestFlagMessage()
        {
            List<string> messages = messagePage.GetMessages();
            string expectedFlagSubject = messages[0];
            messagePage.FlagMessage(0);
            WebDriverUtil.Refresh();
            messagePage.СlickFlagIcon();
            List<string> flagMessages = messagePage.GetFlaggedMessages();
            Assert.IsTrue(flagMessages.Any(actualFlagMessage => expectedFlagSubject.Contains(actualFlagMessage)), $"Message '{expectedFlagSubject}' was not in the list");
            messagePage.FlagMessage(0);
            WebDriverUtil.Refresh();
            List<string> updatedFlagMessages = messagePage.GetFlaggedMessages();
            Assert.IsFalse(updatedFlagMessages.Any(actualFlagMessage => expectedFlagSubject.Contains(actualFlagMessage)), "Message is in the list");
        }

        [Test]
        public void TestSentMessageSeveralUsers()
        {
            List<Recipient> recipients = EntitiesManager.GetRecipients();
            sendMessagePage = messagePage.ClickCreateMessageButton();
            sendMessagePage.AssertPageIsLoaded();
            sendMessagePage.EnterRecipients(recipients);
            string expectedSubject = StringUtils.GenerateAlphanumericString(10);
            sendMessagePage.EnterSubject(expectedSubject);
            sendMessagePage.EnterMessage(StringUtils.GenerateAlphabeticalString(20));
            sendMessagePage.SendButtonClick();
            Assert.IsTrue(sendMessagePage.CheckMessageIsSent(), "Message sent notification was not displayed.");
            sendMessagePage.SentMessagesButtonClick();
            WebDriverUtil.Refresh();
            List<string> subjects = sendMessagePage.GetSubjects();
            Assert.IsTrue(subjects.Any(subject => subject.Contains(expectedSubject)), "Subject was not in the list");
        }
    }
}
