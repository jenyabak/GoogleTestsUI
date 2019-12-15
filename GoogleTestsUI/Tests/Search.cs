﻿namespace GoogleTestUI
{
    using NUnit.Framework;
    using Keys = OpenQA.Selenium.Keys;
    using static WebDriverContainer;
    using OpenQA.Selenium.Support.PageObjects;

    [TestFixture]
    public class Search : BaseTest
    {
        [TestCase("Selenium IDE export to C#", "Selenium IDE", 4)]
        [TestCase("Selenium IDE C#", "Code Export in Selenium IDE",4)]
        public void SearchText(string textToSearch, string expectedResult, int searchLineNumber)
        {
            // Arrange
            MainPage mainPage = WebDriver.GetPage<MainPage>();
            SearchResultPage searchResultPage = new SearchResultPage();

            // Action
            mainPage.SearchField.SendKeys(textToSearch);
            mainPage.SearchButton.Click();

            // Assert
            string actualResult = searchResultPage.SearchResults[searchLineNumber - 1].Text;
            Assert.That(actualResult.Contains(expectedResult), $"{actualResult} does not contains {expectedResult}");

        }      
    }
}
