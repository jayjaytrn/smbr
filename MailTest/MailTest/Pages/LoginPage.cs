using MailTest.Helpers;
using OpenQA.Selenium;

namespace MailTest.Pages
{
    public abstract class LoginPage : Page
    {
        protected virtual string Username { get; set; }
        protected virtual string Password { get; set; }
        protected virtual By UsernameLocator { get; set; }
        protected virtual By PasswordLocator { get; set; }

        public void GoToLoginPage()
        {
            Browser.GoTo(Url);
        }

        public void TypeUsername()
        {
            Browser.webDriver.FindElement(UsernameLocator).Clear();
            Browser.webDriver.FindElement(UsernameLocator).SendKeys(Username);
        }

        public void TypePassword()
        {
            Browser.webDriver.FindElement(PasswordLocator).SendKeys(Password);
        }

        public abstract Page Login();
    }
}