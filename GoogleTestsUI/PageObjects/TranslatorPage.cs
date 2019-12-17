namespace GoogleTestUI
{

    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public class TranslatorPage : BasePage
    {
        public TranslatorPage(string baseURL) : base(baseURL)
        {
        }

        [FindsBy(How = How.Id, Using = "source")]
        public IWebElement TranslateInField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'results-container')]")]
        private IWebElement translateOutField { get; set; }
        public IWebElement TranslateOutField
        {
            get => translateOutField.WaitForElementTextLenthNotChanged();
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'source-language-list')]")]
        public IWebElement LangFromSelector { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'target-language-list')]")]
        public IWebElement LangToSelector { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'list-search-box')]")]
        private IList<IWebElement> searchBox { get; set; }
        public IWebElement SearchBox
        {
            get => searchBox.Where(x => x.Displayed).First();
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'list_item_language_name')]/b")]
        private IList<IWebElement> filteredLang { get; set; }
        public IWebElement FilteredLang
        {
            get => filteredLang.Where(x => x.Displayed).First();
        }

        public override bool PageLoadedCorrectly() => base.PageLoadedCorrectly() && URL.Contains("translate.google");

    }
}
