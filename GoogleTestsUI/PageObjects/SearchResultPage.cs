namespace GoogleTestUI
{
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;
    using static GoogleTestUI.WebDriverContainer;
    using static GoogleTestUI.Waiter;
    using System.Collections.Generic;
    using System.Linq;


    public class SearchResultPage : BasePage
    {

        public override string Title { get => WebDriver.Title; }

        [FindsBy(How = How.XPath, Using = "//div[@class='g']")]
        public IList<IWebElement> SearchResults { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/input[@type='text']")]
        public IWebElement SearchField { get; set; }

        public override bool PageLoadedCorrectly()
        {
            return base.PageLoadedCorrectly() && SearchField.Displayed;
        }

        public class Translator
        {
            public Translator()
            {
                PageFactory.InitElements(WebDriver, this);
            }

            [FindsBy(How = How.Id, Using = "tw-source-text-ta")]
            public IWebElement TranslateField { get; set; }

            [FindsBy(How = How.Id, Using = "kAz1tf")]
            private IWebElement translatedField { get; set; }
            public IWebElement TranslatedField
            {
                get => translatedField.WaitForElementTextNotChanged();
            }

            [FindsBy(How = How.XPath, Using = "//span[contains(@class,'DQEUec ')]")]
            private IList<IWebElement> translateFieldLangSelectors { get; set; }
            public IWebElement LangFromSelector
            {
                get => WaitForClikcable(translateFieldLangSelectors[0]);
            }

            public IWebElement LangToSelector
            {
                get => WaitForClikcable(translateFieldLangSelectors[1]);
            }

            [FindsBy(How = How.XPath, Using = "//input[contains(@id,'list-search-box')]")]
            private IList<IWebElement> searchBox { get; set; }
            public IWebElement SearchBox
            {
                get => searchBox.Where(x => x.Displayed).First();
            }

            [FindsBy(How = How.XPath, Using = "//div[@id='tw-container']//b")]
            private IList<IWebElement> foundLang { get; set; }
            public IWebElement FoundLang
            {
                get => WaitForClikcable(foundLang.Where(x => x.Displayed).First());
            }
        }
    }
}
