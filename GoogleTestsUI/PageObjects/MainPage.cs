namespace GoogleTestUI
{
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;
    using static GoogleTestUI.CommonUtils;

    public class MainPage : BasePage
    {
        public MainPage()
        {
            Title = "Google";
            URL = GetSetting("baseURL");            
        }

        [FindsBy(How = How.XPath, Using = "//div/input[@type='text']")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='gNO89b' and not(ancestor::div[contains(@style,'display:none')]) and not(ancestor::div[contains(@style,'display: none')])]")]
        public IWebElement SearchButton { get; set; }

        public override bool PageLoadedCorrectly()
        {
            return base.PageLoadedCorrectly() && SearchField.Displayed;
        }

    }
}
