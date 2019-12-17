namespace GoogleTestUI
{
    using static GoogleTestUI.WebDriverContainer;
    using static GoogleTestUI.Wait;
    using OpenQA.Selenium;

    public class CurrentPage : BasePage
    {
        public static BasePage currentPage = null;

        public CurrentPage(string baseURL = null, string title = null) : base(WebDriver.Url, WebDriver.Title)
        {
        }

        public static IWebElement ActiveWebElement { get => WebDriver.SwitchTo().ActiveElement(); }

        public static void RememberPageState()
        {
            currentPage = new CurrentPage();
        }

        public static bool isTitleChanged(string titleFirst = "*", int waitingTime = 3, int poolingInt = 300)
        {
            if (waitingTime == 0) waitingTime = defaultTimeout;
            if (poolingInt == 0) poolingInt = pollingInterval;
            if (titleFirst == "*") titleFirst = currentPage.Title;
            string title1 = titleFirst;
            string title2 = "";
            bool isTitlesDiff()
            {
                title2 = WebDriver.Title;
                bool result = title1 != title2;
                title1 = title2;
                return result;
            }
            var wait = new Wait()
            {
                PollingInterval = poolingInt,
                WebTimeoutElement = waitingTime,
            };
            return wait.Until(() => isTitlesDiff());
        }
    }
}
