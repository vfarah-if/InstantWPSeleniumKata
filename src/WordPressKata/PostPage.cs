using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata
{
    public class PostPage
    {
        public static string Title
        {
            get
            {
                Browser.Instance.Wait().ForElement(By.ClassName("entry-title"));
                return Browser.Instance.FindElement(By.ClassName("entry-title")).Text;
            }
        }
    }
}