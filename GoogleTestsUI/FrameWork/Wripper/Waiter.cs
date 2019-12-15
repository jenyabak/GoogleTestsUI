namespace GoogleTestUI
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
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

        public static IWebElement WaitForClikcable(IWebElement webElement)
        {
            bool isClickable()
            {
                try
                {
                   return webElement.Displayed && webElement.Enabled;
                }
                catch
                {
                   return false;
                }                
            }
            return WaitUntil(x => isClickable(), webElement, 1000, "Element is not become clikable in default timoute");

        }
    }
}
