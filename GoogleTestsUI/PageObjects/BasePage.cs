namespace GoogleTestUI
{
    using OpenQA.Selenium.Support.PageObjects;
    using static GoogleTestUI.WebDriverContainer;

    public abstract class BasePage
    {

        private string uRL;
        private string title;

        protected BasePage()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public string PageSource { get => WebDriver.PageSource; }
        public virtual string URL { get => uRL; set => uRL = value; }
        public virtual string Title { get => title; set => title = value; }

        public virtual bool PageLoadedCorrectly()
        {
            return WebDriver.Title == Title;
        }

    }
}