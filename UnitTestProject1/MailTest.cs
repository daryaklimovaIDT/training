
using NUnit.Framework;
using UnitTestsMail.Pages;

namespace UnitTestsMail
{
    [TestFixture]
    public class MailTest : BaseTest
    {
        private MessagePage messagePage;
        private SendMessagePage sendMessagePage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl("https://mail.ru/");
            loginPage.LogIn("user.test.2000", "us20002000");
            messagePage = loginPage.ClickEnterButton();
            messagePage.WaitForPageToLoad();
            Assert.IsTrue(loginPage.IsLogoutDisplayed(), "Logout button was not displayed.");
        }

        [Test]
        public void TestMoveToSpamAndBack()
        {
            // move to spam
            messagePage.ChooseFirstMessage();
            messagePage.СlickSpamButton();
            messagePage.ClickApproveSpamButton();
            _driver.Navigate().Refresh();
            messagePage.ClickSpamField();
            _driver.Navigate().Refresh();
            // move from spam
            messagePage.ChooseFirstMessage();
            messagePage.СlickSpamButton();
        }

        [Test]
        public void TestFlagAndUnflag()
        {
            messagePage.ChooseSeveralMessagesFlags();
            messagePage.ChooseSeveralMessagesFlags();
        }

        [Test]
        public void TestSentMessageSeveralUsers()
        {
            sendMessagePage = messagePage.ClickCreateMessageButton();
            sendMessagePage.EnterRecipients("user.test.2000@mail.ru dasha.7777777@mail.ru");
            sendMessagePage.EnterTheme("111");
            sendMessagePage.EnterMessageText("Hi");
            sendMessagePage.SendButtonClick();
            Assert.IsTrue(sendMessagePage.MessageIsSent(), "Logout button was not displayed.");
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
