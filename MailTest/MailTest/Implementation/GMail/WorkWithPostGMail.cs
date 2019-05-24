using MailTest.Helpers;
using MailTest.Pages;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace MailTest.Implementation.GMail
{
    internal class WorkWithPostGMail : WorkWithPost
    {
        protected override string SearchBy { get; set; } = "https://mail.google.com/mail/#inbox";
        protected override string Reseiver { get; set; } = "ilya.filinin@simbirsoft.com";
        protected override string SearchMailsBy { get; set; } = "from: ilya.filinin@simbirsoft.com";
        protected override string Subject { get; set; } = "Тестовое задание. Салахутдинов";
        protected override string MailBody { get; set; }

        protected override By SearchFieldLocator { get; set; } = By.Name("q");
        protected override By ToLocator { get; set; } = By.Name("to");
        protected override By SubjectLocator { get; set; } = By.Name("subjectbox");
        protected override By MailBodyLocator { get; set; } = By.CssSelector("#\\:d7");

        public string TotalMails;
        
        private string CountLocator = "#\\:4 > div:nth-child(2) > div.nH.aqK > div.Cr.aqJ > div.ar5.J-J5-Ji > span";

        public WorkWithPostGMail(Browser browser)
        {
            this.Browser = browser;
        }

        public void SearchMail()
        {
            this.TypeSearchField();
            Browser.webDriver.FindElement(SearchFieldLocator).SendKeys(Keys.Enter);
        }

        public void CountMail()
        {
            var getselector = Browser.webDriver.FindElement(By.CssSelector(CountLocator)).GetAttribute("innerHTML");
            var prepare1 = getselector.Split("из");
            var prepare2 = prepare1[prepare1.Length-1];
            var prepare3 = prepare2.Remove(20);
            TotalMails = Regex.Replace(prepare3, @"[^0-9$,]", "");
            MailBody = "В ходе выполнения тестового задания найдено " + TotalMails + " письма от Филинина Ильи";
        }

        public void SendMail()
        {
            Browser.webDriver.Navigate().GoToUrl("https://mail.google.com/mail/#sent?compose=new");
            this.SendMails();
            Browser.webDriver.FindElement(By.CssSelector("#\\:d7")).SendKeys(Keys.Control + Keys.Enter);
        }

        public override Page Work()
        {
            this.SearchMail();
            this.CountMail();
            this.SendMail();
            return this;
        }
    }
}
