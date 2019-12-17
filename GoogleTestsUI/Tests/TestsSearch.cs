namespace GoogleTestUI
{
    using NUnit.Framework;
    using static CurrentPage;

    [TestFixture]
    public class TestsSearch : BaseTest
    {

        [TestCase("Selenium IDE export to C#", "Selenium IDE", 4)]
        [TestCase("Selenium IDE C#", "Code Export in Selenium IDE", 4)]
        public void SearchText(string textToSearch, string expectedResult, int searchLineNumber)
        {
            SearchPage searchPage = new SearchPage("https://www.google.com/");
            SearchResultsPage searchResultPage = new SearchResultsPage();

            // Arrange
            searchPage.Open();

            // Action
            searchPage.SearchField.SendKeys(textToSearch);
            searchPage.SearchButton.ClickAndCheck(() => isTitleChanged());

            // Assert
            string actualResult = searchResultPage.SearchResults[searchLineNumber - 1].Text;
            Assert.That(actualResult.Contains(expectedResult), $"{actualResult} does not contains {expectedResult}");

        }
    }
}
