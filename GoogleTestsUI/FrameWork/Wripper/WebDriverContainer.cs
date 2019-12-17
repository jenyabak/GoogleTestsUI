namespace GoogleTestUI
{
    using OpenQA.Selenium;

    public class WebDriverContainer
    {
        public static IWebDriver WebDriver = null;

        public static IWebDriver GetDriver()
        {
            return WebDriver = WebDriver ?? Chrome.Start();
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
