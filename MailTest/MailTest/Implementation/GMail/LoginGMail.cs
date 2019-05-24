using MailTest.Helpers;
using MailTest.Implementation;
using MailTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MailTest.Implementation.GMail
{
    internal class LoginGMail : LoginPage
    {
        protected override string Url { get; set; } = "https://www.gmail.com";
        protected override string SearchBy { get; set; } = "https://accounts.google.com/signin/";
        protected override string Username { get; set; } = "test445561";
        protected override string Password { get; set; } = "888uuu888";

        protected override By UsernameLocator { get; set; } = By.Id("identifierId");
        protected override By PasswordLocator { get; set; } = By.Name("password");

        private string SendLoginButton = "identifierNext";
        private string SendPasswordButton = "passwordNext";


        //[FindsBy(How = How.Name, Using = "identifierNext")]
        //public IWebElement SendLoginButton { get; set; }

        public LoginGMail(Browser browser)
        {
            this.Browser = browser;
        }

        public void EnterUsername()
        { 
            this.TypeUsername();
            Browser.wait.Until(ExpectedConditions.ElementIsVisible(By.Id(SendLoginButton)));
            Browser.webDriver.FindElement(By.Id(SendLoginButton)).Click();
        }

        public void EnterPassword()
        {
            this.TypePassword();
            Thread.Sleep(2000);
            Browser.wait.Until(ExpectedConditions.ElementIsVisible(By.Id(SendPasswordButton)));
            Browser.webDriver.FindElement(By.Id(SendPasswordButton)).Click();
        }

        public override Page Login()
        {
            this.GoToLoginPage();
            this.IsPageValid();
            this.EnterUsername();
            this.EnterPassword();
            return new WorkWithPostGMail(this.Browser);
        }
    }
}
