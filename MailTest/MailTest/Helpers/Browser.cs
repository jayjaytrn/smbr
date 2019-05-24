using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace MailTest.Helpers
{
    public class Browser
    {
        private readonly ChromeOptions options;
        public readonly RemoteWebDriver webDriver;
        public readonly WebDriverWait wait;

        public Browser(ChromeOptions chromeOptions)
        {
            this.options = new ChromeOptions();
            this.webDriver = new RemoteWebDriver(new Uri("http://localhost:3333/wd/hub"), options.ToCapabilities());
            this.wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }
        public void GoTo(string url)
        {
            this.webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.webDriver.Navigate().GoToUrl(url);
        }
        public void CloseBrowser()
        {
            this.webDriver.Quit();
        }
        public void MaximizeWindow()
        {
            this.webDriver.Manage().Window.Maximize();
        }
        
    }
}
