namespace GoogleTestUI
{

    using static GoogleTestUI.WebDriverContainer;

    public abstract class BasePage
    {

        private string uRL;
        private string title;

        public string PageSource { get => WebDriver.PageSource; }
        public virtual string URL { get => uRL; set => uRL = value; }
        public virtual string Title { get => title; set => title = value; }

        public virtual bool PageLoadedCorrectly()
        {
            return WebDriver.Title == Title;
        }

    }
}