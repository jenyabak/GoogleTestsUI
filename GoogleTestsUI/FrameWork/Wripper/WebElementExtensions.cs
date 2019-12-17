namespace GoogleTestUI
{
    using OpenQA.Selenium;
    using System;
    using static CurrentPage;

    public static class IWebElementExtensions
    {
        public static IWebElement WaitForElementTextLenthNotChanged(this IWebElement webElement, int pollingInterval = 500, string message = "")
        {
            var waiter = new Wait()
            {
                ObjectToReturn = webElement,
                Message = message,
                PollingInterval = pollingInterval
            };
            int textLenth1 = 0, textLenth2, diff;
            bool isTextLengthNotChanged()
            {
                textLenth2 = webElement.Text.Length;
                diff = textLenth1 - textLenth2;
                textLenth1 = textLenth2;
                return diff == 0 ? true : false;
            }
            return waiter.Until(x => isTextLengthNotChanged(), webElement);
        }

        public static void ClickAndCheck(this IWebElement webElement, Func<bool> Сondition = null, string message = "")
        {
            var wait = new Wait()
            {
                PollingInterval = 1000,
                Message = message,
            };
            bool Click()
            {
                var waitСondition = new Wait()
                {
                    Message = message,
                    PollingInterval = 400,
                    WebTimeoutElement = 2,
                };
                try
                {
                    if (Сondition != null) RememberPageState();
                    webElement.Click();
                    if (Сondition != null) return waitСondition.Until(Сondition);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            wait.Until(() => Click());
        }
    }
}
