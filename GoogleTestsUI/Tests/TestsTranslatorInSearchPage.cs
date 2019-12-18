namespace GoogleTestUI
{
    using NUnit.Framework;
    using static WebDriverContainer;
    using static CurrentPage;


    [TestFixture]
    public class TestsTranslatorInSearchPage : BaseTest
    {
        [TestCase("Анг", "Укр", "This is UI test.", "Це тест на інтерфейс користувача.")]
        [TestCase("Укр", "Анг", "Це тест на інтерфейс користувача.", "This is a user interface test.")]
        public void TranslateTextOnSearchPage(string langFromTransl, string langToTransl, string textToTranslate, string expectedResult)
        {
            SearchPage searchPage = new SearchPage("https://www.google.com/");
            SearchResultsPage searchResultPage = new SearchResultsPage();
            SearchResultsPage.Translator translatorPage = new SearchResultsPage.Translator();

            // Open searchPage in browser
            searchPage.Open();

            // Gettin translator via search
            searchPage.SearchField.SendKeys("translate");
            searchPage.SearchButton.ClickAndCheck(() => IsTitleChanged());

            // Send text to translate
            translatorPage.TranslateField.SendKeys(textToTranslate);

            // Select language from translate
            translatorPage.LangFromSelector.ClickAndCheck();
            translatorPage.SearchBox.SendKeys(langFromTransl);
            translatorPage.FoundLang.ClickAndCheck();

            // Select language to translate
            translatorPage.LangToSelector.ClickAndCheck();
            translatorPage.SearchBox.SendKeys(langToTransl);
            translatorPage.FoundLang.ClickAndCheck();

            // Verifiy result
            string actualResult = translatorPage.TranslatedField.Text;
            Assert.That(actualResult.Contains(expectedResult), $"{actualResult} does not contains {expectedResult}");

        }


    }
}