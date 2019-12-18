namespace GoogleTestUI
{
    using NUnit.Framework;

    [TestFixture]
    public class TranslatorInSearch : BaseTest
    {
        [TestCase("Анг", "Укр", "This is UI test.", "Це тест на інтерфейс користувача.")]
        [TestCase("Укр", "Анг", "Це тест на інтерфейс користувача.", "This is a user interface test.")]
        public void TestsTranslator(string langFromTransl, string langToTransl, string textToTranslate, string expectedResult)
        {
            TranslatorPage translatorPage = new TranslatorPage("https://translate.google.com.ua/");

            // Open page in browser
            translatorPage.Open();

            // Send text to translate
            translatorPage.TranslateInField.SendKeys(textToTranslate);

            // Select language from translate
            translatorPage.LangFromSelector.ClickAndCheck();
            translatorPage.SearchBox.SendKeys(langFromTransl);
            translatorPage.FilteredLang.ClickAndCheck();

            // Select language to translate
            translatorPage.LangToSelector.ClickAndCheck();
            translatorPage.SearchBox.SendKeys(langToTransl);
            translatorPage.FilteredLang.ClickAndCheck();

            // Verifiy result
            string actualResult = translatorPage.TranslateOutField.Text;
            Assert.That(actualResult.Contains(expectedResult), $"{actualResult} does not contains {expectedResult}");

        }
    }
}
