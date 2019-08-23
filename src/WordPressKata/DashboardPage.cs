using OpenQA.Selenium;

namespace WordPressKata
{
    public static class DashboardPage
    {
        public static bool IsCurrentPage =>
            Browser.Instance.Url.Contains("http://127.0.0.1:10080/wordpress/wp-admin/") &&
            Browser.Instance.FindElements(By.CssSelector("div.wrap > h1")).Count > 0;
            
    }
}
