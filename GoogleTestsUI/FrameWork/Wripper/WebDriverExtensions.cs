﻿namespace GoogleTestUI
{
    using OpenQA.Selenium;
    using static GoogleTestUI.Waiter;
    using System;


    public static class WebDriverExtensions
    {
        public static T GetPage<T>(this IWebDriver webDriver) 
        {
            var page = Activator.CreateInstance(typeof(T));
            string url = (page as BasePage).URL;
            bool TryOpenPage()
            {
                webDriver.Navigate().GoToUrl(url);
                return (page as BasePage).PageLoadedCorrectly();
            }
            return WaitUntil(x => TryOpenPage(), (T)page, 1000, "Can't open page: " + page.ToString() + " url: " + url);
        }

    }
}
