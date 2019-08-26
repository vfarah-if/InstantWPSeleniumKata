using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata
{
    public class NewPostPage
    {
        public static CreatePostCommand CreatePost(string expectedPostTitle)
        {
            return new CreatePostCommand(expectedPostTitle);
        }

        public static void NavigateToNewPost()
        {
            Browser
                .Instance
                .Wait()
                .ForElement(by: By.Id("message"));

            Browser.
                Instance.
                FindElement(By.Id("message")).
                FindElements(By.TagName("a"))[0].Click();
        }

        public static void NavigateTo()
        {
            // VVF: Not working
            //            Browser.
            //                Instance.
            //                Wait().
            //                ForElement(By.Id("menu-posts")).
            //                ToExist().
            //                Click();

            Browser.
                Instance.
                FindElement(By.Id("menu-posts")).
                Click();

            // VVF: Not working
            //            Browser.
            //                Instance.
            //                Wait().
            //                ForElement(By.LinkText("Add New")).
            //                ToExist().
            //                Click();

            Browser.
                Instance.
                FindElement(By.LinkText("Add New")).
                Click();
        }
    }
}