
using NUnit.Framework;
using UnitTestProject1;
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
            loginPage = new LoginPage();
            WebDriverUtil.GetInstance().Navigate().GoToUrl("https://mail.ru/");
            loginPage.LogIn("user.test.2000", "us20002000");
            messagePage = loginPage.ClickEnterButton();
            WebDriverWaitUtil.WaitForPageToLoad("Входящие");
            Assert.IsTrue(loginPage.IsLogoutDisplayed(), "Logout button was not displayed.");
        }

        [Test]
        public void TestMoveToSpamAndBack()
        {
            // move to spam
            messagePage.ChooseFirstMessage();
            messagePage.СlickSpamButton();
            messagePage.ClickApproveSpamButton();
            WebDriverUtil.GetInstance().Navigate().Refresh();
            messagePage.ClickSpamField();
            WebDriverUtil.GetInstance().Navigate().Refresh();
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
