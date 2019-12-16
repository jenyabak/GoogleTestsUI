namespace GoogleTestUI
{
    using OpenQA.Selenium;
    using static GoogleTestUI.Wait;
    using System;


    public static class WebDriverExtensions
    {
        public static T GetPage<T>(this IWebDriver webDriver)
        {
            var page = Activator.CreateInstance(typeof(T));
            string url = (page as BasePage).URL;
            var wait = new Wait()
            {
                PollingInterval = 1000,
                WebTimeoutElement = defaultTimeout,
                Message = "Can't open page: " + page.ToString() + " url: " + url
            };
            bool TryOpenPage()
            {
                webDriver.Navigate().GoToUrl(url);
                return (page as BasePage).PageLoadedCorrectly();
            }
            return wait.Until(x => TryOpenPage(), (T)page);
        }

    }
}
