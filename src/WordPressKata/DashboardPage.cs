using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata
{
    public static class DashboardPage
    {
        public static bool IsCurrentPage =>
            Browser.Instance.Url.Contains("http://127.0.0.1:10080/wordpress/wp-admin/") &&
            Browser.Instance.Wait().ForElement(By.CssSelector("div.wrap > h1")).ToExist().Enabled;
            
    }
}
