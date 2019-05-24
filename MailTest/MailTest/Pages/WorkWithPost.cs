using MailTest.Helpers;
using OpenQA.Selenium;

namespace MailTest.Pages
{
    public abstract class WorkWithPost : Page
    {
        protected virtual string Reseiver { get; set; }
        protected virtual string SearchMailsBy { get; set; }
        protected virtual string Subject { get; set; }
        protected virtual string MailBody { get; set; }
      
        protected virtual By SearchFieldLocator { get; set; }
        protected virtual By ToLocator { get; set; }
        protected virtual By SubjectLocator { get; set; }
        protected virtual By MailBodyLocator { get; set; }
       

        public void TypeSearchField()
        {
            Browser.webDriver.FindElement(SearchFieldLocator).Clear();
            Browser.webDriver.FindElement(SearchFieldLocator).SendKeys(SearchMailsBy);
        }

        public void SendMails()
        {
            Browser.webDriver.FindElement(ToLocator).SendKeys(Reseiver);
            Browser.webDriver.FindElement(SubjectLocator).SendKeys(Subject);
            Browser.webDriver.FindElement(MailBodyLocator).SendKeys(MailBody);
        }

        public abstract Page Work();
    }
}
