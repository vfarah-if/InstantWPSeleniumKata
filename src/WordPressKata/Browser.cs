using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata
{
    public static class Browser
    {
        public static IWebDriver Instance { get; private set; }

        public static void Open(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                {
                    Instance = new FirefoxDriver();
                    break;
                }
                case BrowserType.PhantomJS:
                {
                    Instance = new PhantomJSDriver();
                    break;
                }
                default:
                {
                    Instance = new ChromeDriver();
                    break;
                }
            }
            Instance.Manage().Window.Maximize();
        }

        public static void PauseFor(TimeSpan timeSpan)
        {
            Instance.Manage().Timeouts().ImplicitlyWait(timeSpan);
        }

        public static void TypeText(this IWebDriver source, By by, string text, int waitInMilliseconds = 500)
        {
            if (source != null && by != null)
            {
                try
                {
                    source.Wait(waitInMilliseconds).ForElement(by).ToExist().Click();
                    source.Wait(waitInMilliseconds).ForElement(by).ToExist().SendKeys(text);
                }
                catch (StaleElementReferenceException)
                {
                    source.Wait(waitInMilliseconds).ForElement(by).ToExist().Click();
                    source.Wait(waitInMilliseconds).ForElement(by).ToExist().SendKeys(text);
                }
            }
        }

        public static void Quit()
        {
            if (Instance != null)
            {
                Instance.Quit();
                Instance = null;
            }
        }
    }
}
