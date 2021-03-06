﻿
namespace GoogleTestUI
{

    using NUnit.Framework;
    using static WebDriverContainer;
    using static CommonUtils;
    using static NUnit.Framework.TestContext;
    using NUnit.Framework.Interfaces;

    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            var testStatus = CurrentContext.Result.Outcome.Status;
            if (testStatus == TestStatus.Failed)
            {
                TakeScreenshot();
            }

            if (WebDriver != null)
            {
                WebDriver.Quit();
                WebDriver = null;
            }
        }

    }


}