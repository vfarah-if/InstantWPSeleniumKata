using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata.Login
{
    public static class LoginPage
    {
        public static void NavigateTo()
        {
            Browser.Instance.Navigate().GoToUrl("http://127.0.0.1:10080/wordpress/wp-login.php");
            // Wait is for the focus timing issue that occurs because of the focus on the first input
            Browser.Instance.Wait(10000).ForElement(By.Id("user_login")).ToExist();
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }

        public static void LoginAsAdministrator()
        {
            new LoginCommand("admin")
                .WithPassword("password")
                .Login();
            VerifyLoginSucceeded();
        }

        public static void VerifyLoginSucceeded()
        {
            Browser
                .Instance
                .Wait()
                .ForElement(@by: By.CssSelector("div.wrap > h1"))
                .ToExist();
        }

        public static void VerifyLoginFailed()
        {
            Browser
                .Instance
                .Wait()
                .ForElement(@by: By.Id("login_error"))
                .ToExist();
        }
    }
}
