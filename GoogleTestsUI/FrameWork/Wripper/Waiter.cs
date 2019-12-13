namespace GoogleTestUI
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using static WebDriverContainer;
    using static CommonUtils;


    public class Waiter
    {

        public static int defaultTimeout = GetIntSetting("defaultTimeout");

        public static T WaitUntil<T>(Func<T, bool> condition, T input, int pollingInterval = 0, string message = "")
        {
            if (pollingInterval == 0) pollingInterval = GetIntSetting("pollingInterval");
            if (message == "") message = condition.ToString() + " did not happened in defaultTimeout: " + defaultTimeout.ToString();
            IWait<T> wait = new DefaultWait<T>(input)
            {
                Timeout = TimeSpan.FromSeconds(defaultTimeout),
                Message = message,
                PollingInterval = TimeSpan.FromMilliseconds(pollingInterval)
            };
            wait.Until(condition);
            return input;
        }

        public static void WaitUntil(Func<bool, bool> condition, int pollingInterval = 0, string message = "")
        {
            WaitUntil(condition, true, pollingInterval, message);
        }

        public static IWebElement WaitForClikcable(IWebElement webElement)
        {
            WebDriverWait WebDriverWaiter(int timeout = 0)
            {
                if (timeout == 0) timeout = defaultTimeout;
                return new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(timeout));
            }

            return WebDriverWaiter().Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

    }
}
