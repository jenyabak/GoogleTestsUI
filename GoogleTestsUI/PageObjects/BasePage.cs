namespace GoogleTestUI
{
    using OpenQA.Selenium.Support.PageObjects;
    using static GoogleTestUI.WebDriverContainer;

    public abstract class BasePage
    {
        public virtual string URL { get; set; }
        public virtual string Title { get; set; }

        protected BasePage()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public virtual bool PageLoadedCorrectly()
        {
            return WebDriver.Title == Title;
        }

    }
}