namespace GoogleTestUI
{
    using System;
    using System.Configuration;
    using OpenQA.Selenium;
    using System.Globalization;
    using System.IO;
    using static NUnit.Framework.TestContext;
    using static WebDriverContainer;

    public class CommonUtils
    {

        private static readonly CultureInfo CultureInformation = CultureInfo.InvariantCulture;
        public static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static TestAdapter CurrentTest => CurrentContext.Test;

        public static string TakeScreenshot(string path = "")
        {
            string testResultFolder = BaseDirectory;
            var directory = Directory.CreateDirectory($"{testResultFolder}");

            if (path != "")
            {
                directory = Directory.CreateDirectory($"{testResultFolder}\\{path}");
            }
            string fileName = directory.FullName +  $"{DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss")}.jpeg";

            Screenshot ss = ((ITakesScreenshot)GetDriver()).GetScreenshot();
            ss.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
            return fileName;
        }

        public static string GetSetting(string setting)
        {
            return ConfigurationManager.AppSettings.Get(setting);
        }

        public static int GetIntSetting(string setting)
        {
            return int.Parse(ConfigurationManager.AppSettings.Get(setting));
        }

       
    }
}