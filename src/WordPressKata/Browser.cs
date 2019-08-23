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
            Wait(1000, By.Id("user_login"));
        }

        public static void Wait(int milliseconds = 500, By by = null)
        {
            if (by == null)
            {
                Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(milliseconds));
            }
            else
            {
                Instance.Wait(milliseconds).ForElement(by);
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
