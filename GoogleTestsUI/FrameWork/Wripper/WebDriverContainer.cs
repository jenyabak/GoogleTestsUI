namespace GoogleTestUI
{
    using OpenQA.Selenium;

    public class WebDriverContainer
    {
        public static IWebDriver WebDriver = null;

        public static IWebDriver GetDriver(DriverOptions driverOptions = null)
        {
            if (WebDriver == null )
            {
                driverOptions = driverOptions ?? Chrome.StartOptions;
                WebDriver = Chrome.Start();
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
