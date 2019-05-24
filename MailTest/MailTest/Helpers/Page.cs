using MailTest.Helpers;

namespace MailTest.Helpers
{
    public abstract class Page
    {
        protected virtual Browser Browser { get; set; }
        protected virtual string Url { get; set; }
        protected virtual string SearchBy { get; set; }

        public void IsPageValid()
        {
            Browser.webDriver.Url.Contains(SearchBy);
        }
    }
}