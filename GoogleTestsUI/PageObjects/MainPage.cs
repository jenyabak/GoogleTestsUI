namespace GoogleTestUI
{
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;
    using static GoogleTestUI.WebDriverContainer;
    using static GoogleTestUI.CommonUtils;
    using static GoogleTestUI.Waiter;
    using System.Collections.Generic;
    using System.Linq;

    public class MainPage : BasePage
    {
        public MainPage()
        {
            Title = "Google";
            URL = GetSetting("baseURL");
            
        }

        [FindsBy(How = How.XPath, Using = "//div/input[@type='text']")]
        public IWebElement SearchField { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@class='gNO89b']")]
        private IList<IWebElement> searchButtons { get; set; }
        public IWebElement SearchButton
        {
            get => WaitForClikcable(searchButtons.Where(x => x.Displayed).First());
        }

        public override bool PageLoadedCorrectly()
        {
            return base.PageLoadedCorrectly() && SearchField.Displayed;
        }

    }
}
