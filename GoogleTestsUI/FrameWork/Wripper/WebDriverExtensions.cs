namespace GoogleTestUI
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using static GoogleTestUI.Waiter;
    using System;


    public static class WebDriverExtensions
    {
        public static T GetPage<T>(this IWebDriver webDriver) 
        {
            var page = Activator.CreateInstance(typeof(T));
            string url = (page as BasePage).URL;
            Func<bool> TryOpenPage = () =>
            {
                webDriver.Navigate().GoToUrl(url);
                return (page as BasePage).PageLoadedCorrectly();
            };        
            WaitUntil(x => TryOpenPage(), 1000, "Can't open page: " + page.ToString() + " url: " + url);
            return (T)page;
        }

    }
}
