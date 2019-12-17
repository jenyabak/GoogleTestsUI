namespace GoogleTestUI
{
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;

    public class SearchPage : BasePage
    {

        public SearchPage(string baseUrl, string title = "Google") : base(baseUrl, title)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div/input[@type='text']")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='gNO89b' and not(ancestor::div[contains(@style,'display:none')]) and not(ancestor::div[contains(@style,'display: none')])]")]
        public IWebElement SearchButton { get; set; }

        public override bool PageLoadedCorrectly()
        {
            var wait = new Wait(){WebTimeoutElement = 2};
            return base.PageLoadedCorrectly() && wait.Until(() => SearchField.Displayed); 
        }

    }
}
