namespace GoogleTestUI
{
    using NUnit.Framework;
    using static WebDriverContainer;
    using static CurrentPage;

    [TestFixture]
    public class TranslatorInSearch : BaseTest
    {
        // NOTE currently this test works properly only for cyrillic locale
        [TestCase("Анг", "Укр", "This is UI test.", "Це тест на інтерфейс користувача.")]
        [TestCase("Укр", "Анг", "Це тест на інтерфейс користувача.", "This is a user interface test.")]
        public void TranslateTextOnSearchPage(string langFromTransl, string langToTransl, string textToTranslate, string expectedResult)
        {
            MainPage mainPage = WebDriver.GetPage<MainPage>();
            SearchResultPage searchResultPage = new SearchResultPage();
            SearchResultPage.Translator TaranslatorOnSearchResultPage = new SearchResultPage.Translator();

            // Gettin translator via search
            mainPage.SearchField.SendKeys("translate");
            mainPage.SearchButton.ClickAndCheck(() => TitleChanged());

            // Send text to translate
            TaranslatorOnSearchResultPage.TranslateField.SendKeys(textToTranslate);

            // Select language from translate
            TaranslatorOnSearchResultPage.LangFromSelector.ClickAndCheck();
            TaranslatorOnSearchResultPage.SearchBox.SendKeys(langFromTransl);
            TaranslatorOnSearchResultPage.FoundLang.ClickAndCheck();

            // Select language to translate
            TaranslatorOnSearchResultPage.LangToSelector.ClickAndCheck();
            TaranslatorOnSearchResultPage.SearchBox.SendKeys(langToTransl);
            TaranslatorOnSearchResultPage.FoundLang.ClickAndCheck();

            // Verifiy result
            string actualResult = TaranslatorOnSearchResultPage.TranslatedField.Text;
            Assert.That(actualResult.Contains(expectedResult), $"{actualResult} does not contains {expectedResult}");

        }


    }
}
