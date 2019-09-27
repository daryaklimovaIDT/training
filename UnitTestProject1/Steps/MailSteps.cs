using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UnitTestProject1.Temp;
using UnitTestProject1.Utils;
using UnitTestsMail;
using UnitTestsMail.Entities;
using UnitTestsMail.Pages;

namespace UnitTestProject1.Steps
{
    [Binding]
    public class MailSteps : BaseSteps
    {
        private MessagePage messagePage;
        private SendMessagePage sendMessagePage;
        private LoginPage loginPage;
        private readonly Context _context;


        public MailSteps(Context context)
        {
            _context = context;
        }

        [Given(@"I login to mail.ru")]
        public void GivenILoginToMail_Ru()
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

        [Given(@"I mark message as spam")]
        public void GivenIMarkMessageAsSpam()
        {
            List<string> messages = messagePage.GetMessages();
            _context.ExpectedSpamSubject = messages[0];
            messagePage.MoveMessageToSpam(0);
            WebDriverUtil.Refresh();
        }

        [When(@"I navigate to spam folder")]
        public void WhenINavigateToSpamFolder()
        {
            messagePage.NavigateToSpamFolder();
        }

        [Then(@"The message should be in spam")]
        public void ThenTheMessageShouldBeInSpam()
        {
            List<string> spamMessages = messagePage.GetMessages();
            Assert.IsTrue(spamMessages.Any(actualSpamMessage => _context.ExpectedSpamSubject.Contains(actualSpamMessage)), "The message is not in spam");
        }

        [Given(@"I get inbox messages")]
        public void GivenIToggleMessageFlag()
        {
            List<string> messages = messagePage.GetMessages();
            _context.ExpectedFlagSubject = messages[0];

        }

        [When(@"I navigate to flaged messages folder")]
        public void WhenINavigateToFlagedMessagesFolder()
        {
            messagePage.СlickFlagIcon();
        }

        [Then(@"The message should be in flag folder")]
        public void ThenTheMessageShouldBeInFlagFolder()
        {
            List<string> flagMessages = messagePage.GetFlaggedMessages();
            Assert.IsTrue(flagMessages.Any(actualFlagMessage => _context.ExpectedFlagSubject.Contains(actualFlagMessage)), $"Message '{_context.ExpectedFlagSubject}' was not in the list");
        }

        [When(@"I toggle message flag")]
        public void WhenIToggleMessageFlag()
        {
            messagePage.FlagMessage(0);
            WebDriverUtil.Refresh();
        }

        [Then(@"The message should not be in flag folder")]
        public void ThenTheMessageShouldNotBeInFlagFolder()
        {
            List<string> updatedFlagMessages = messagePage.GetFlaggedMessages();
            Assert.IsFalse(updatedFlagMessages.Any(actualFlagMessage => _context.ExpectedFlagSubject.Contains(actualFlagMessage)), "Message is in the list");
        }

        [Given(@"I entered message data")]
        public void GivenIEnteredMessageData()
        {
            List<Recipient> recipients = EntitiesManager.GetRecipients();
            sendMessagePage = messagePage.ClickCreateMessageButton();
            sendMessagePage.AssertPageIsLoaded();
            sendMessagePage.EnterRecipients(recipients);
            _context.ExpectedSubject = StringUtils.GenerateAlphanumericString(10);
            sendMessagePage.EnterSubject(_context.ExpectedSubject);
            sendMessagePage.EnterMessage(StringUtils.GenerateAlphabeticalString(20));
        }

        [When(@"I send the message")]
        public void WhenISendTheMessage()
        {
            sendMessagePage.SendButtonClick();
        }

        [Then(@"Message notification should appear")]
        public void ThenMessageNotificationShouldAppear()
        {
            Assert.IsTrue(sendMessagePage.CheckMessageIsSent(), "Message sent notification was not displayed.");
        }

        [When(@"I navigate to sent messages folder")]
        public void WhenINavigateToSentMessagesFolder()
        {
            sendMessagePage.SentMessagesButtonClick();
            WebDriverUtil.Refresh();
        }

        [Then(@"The message should be in sent messages folder")]
        public void ThenTheMessageShouldBeInSentMessagesFolder()
        {
            List<string> subjects = sendMessagePage.GetSubjects();
            Assert.IsTrue(subjects.Any(subject => subject.Contains(_context.ExpectedSubject)), "Subject was not in the list");
        }

        [AfterScenario]
        public override void TearDown()
        {
            base.TearDown();
        }

    }
}

