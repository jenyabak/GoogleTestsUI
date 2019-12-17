namespace GoogleTestUI
{
    using OpenQA.Selenium.Support.PageObjects;
    using static GoogleTestUI.WebDriverContainer;
    using static GoogleTestUI.Wait;

    public abstract class BasePage
    {
        public virtual string URL { get; private set; }

        private string title { get; set; }
        public virtual string Title
        {
            get { if (title == "" || title == null) return WebDriver.Title; else return title; }
            set { if (title == "" || title == null) title = value; }
        }


        protected BasePage(string baseURL, string title = null)
        {
            if (baseURL != null) URL = baseURL;
            if (title != null) Title = title;
            PageFactory.InitElements(WebDriver, this);
        }

        public virtual bool PageLoadedCorrectly()
        {
            return WebDriver.Title == Title;
        }

        public BasePage Open()
        {
            var wait = new Wait()
            {
                PollingInterval = 1000,
                WebTimeoutElement = defaultTimeout,
                Message = "Can't open page: " + this.ToString() + " url: " + URL
            };
            bool TryOpenPage()
            {
                WebDriver.Navigate().GoToUrl(URL);
                return this.PageLoadedCorrectly();
            }
            wait.Until(() => TryOpenPage());
            return this;
        }
    }
}