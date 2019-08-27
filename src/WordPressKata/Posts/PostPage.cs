using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata.Posts
{
    public class PostPage
    {
        public static string Title =>
            Browser
                .Instance
                .Wait()
                .ForElement(By.ClassName("entry-title"))
                .ToExist()
                .Text;
    }
}