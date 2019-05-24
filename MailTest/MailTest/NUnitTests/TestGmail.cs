using MailTest.Helpers;
using MailTest.Implementation.GMail;
using MailTest.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace MailTest.NUnitTests
{

    [TestFixture]
    [AllureNUnit]
    public class TestGmail
    {
        Browser browser;
        LoginPage page;
        WorkWithPostGMail work;

        [SetUp]
        public void Init()
        {
            this.browser = new Browser(new OpenQA.Selenium.Chrome.ChromeOptions());
            this.page = new LoginGMail(browser);
            this.work = new WorkWithPostGMail(browser);
        }

        [Test]
        [AllureTag("NUnit", "Debug")]
        [AllureFeature("Core")]
        [TestCase]
        public void GmailTest()
        {
            this.page.Login();
            this.work.Work();
        }
    }
}
