using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;

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
