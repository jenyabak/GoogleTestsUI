namespace GoogleTestUI
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using static CommonUtils;

    public class Wait
    {

        public static readonly int defaultTimeout = GetIntSetting("defaultTimeout");
        public static readonly int pollingInterval = GetIntSetting("pollingInterval");

        public object ObjectToReturn = null;
        public int WebTimeoutElement = defaultTimeout;
        public int PollingInterval = pollingInterval;
        public Type IgnoreExceptionType = null;
        public string Message = "";


        public bool Until(Func<bool> condition)
        {
            Func<object, bool> func = (x) => condition();
            var result = WaitUntil(func);
            if (result == null) return false;
            else return true;
        }

        public IWebElement Until(Func<IWebElement, bool> condition, IWebElement webElement)
        {
            ObjectToReturn = webElement;
            return WaitUntil(condition);
        }

        private T WaitUntil<T>(Func<T, bool> condition)
        {
            if (Message == "") Message = condition.ToString() + " did not happened in defaultTimeout: " + defaultTimeout.ToString();
            if (ObjectToReturn == null) ObjectToReturn = CurrentPage.ActiveWebElement;
            IWait<T> wait = new DefaultWait<T>((T)ObjectToReturn)
            {
                Timeout = TimeSpan.FromSeconds(WebTimeoutElement),
                Message = Message,
                PollingInterval = TimeSpan.FromMilliseconds(PollingInterval),
            };
            if (IgnoreExceptionType != null) wait.IgnoreExceptionTypes(IgnoreExceptionType);
            try
            {
                wait.Until(condition);
            }
            catch (TimeoutException)
            {
                return default(T);
            }
            return (T)ObjectToReturn;

        }

    }
}
