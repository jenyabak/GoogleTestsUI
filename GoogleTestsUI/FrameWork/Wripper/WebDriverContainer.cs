namespace GoogleTestUI
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class WebDriverContainer
    {
        public static IWebDriver WebDriver = null;

        public static IWebDriver GetDriver(DriverOptions driverOptions = null)
        {
            if (WebDriver == null )
            {
                driverOptions = driverOptions ?? new ChromeOptions();
                ((ChromeOptions)driverOptions).AddArguments("--start-maximized");
                ((ChromeOptions)driverOptions).AddArguments("--lang=uk-UA");
                WebDriver = new ChromeDriver((ChromeOptions)driverOptions);
                WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Wait.defaultTimeout);
            }
            return WebDriver;
        }

        public static void QuitWebdriver()
        {
            if (WebDriver != null)
            {
                WebDriver.Quit();
                WebDriver = null;
            }
        }
    }
}
