namespace GoogleTestUI
{
    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using static CommonUtils;

    public static class Chrome
    {
        public static ChromeOptions StartOptions = new ChromeOptions();

        static Chrome()
        {
            SupportedLocales.TryGetValue(GetSetting("browserLocale"), out string arg);
            StartOptions.AddArguments("--start-maximized");
            StartOptions.AddArguments("--lang=" + arg);
        }

        public static IWebDriver Start()
        {
            var driver = new ChromeDriver(StartOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            return driver;
        }

        private static Dictionary<string, string> SupportedLocales =>
            new Dictionary<string, string>
            {
               { "UK", "en-GB" },
               { "UA", "uk-UA" },
               { "RU", "ru-RU" }
            };

    }
}
