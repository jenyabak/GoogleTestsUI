namespace GoogleTestUI
{
    using OpenQA.Selenium;
    using static GoogleTestUI.Waiter;

    public static class IWebElementExtensions
    {
        public static IWebElement WaitForElementTextNotChanged(this IWebElement webElement, int pollingInterval = 500, string message = "")
        {
            int textLenth1 = 0, textLenth2, diff;
            bool isTextLengthNotChanged()
            {
                textLenth2 = webElement.Text.Length;
                diff = textLenth1 - textLenth2;
                textLenth1 = textLenth2;
                return diff == 0 ? true : false;
            }
            return WaitUntil(x => isTextLengthNotChanged(), webElement, pollingInterval, message);
        }
    }
}
