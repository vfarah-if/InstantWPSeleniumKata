using System;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata
{
    public static class LoginPage
    {
        public static void NavigateTo()
        {
            Browser.Instance.Navigate().GoToUrl("http://127.0.0.1:10080/wordpress/wp-login.php");
            // Wait is for the focus timing issue that occurs because of the focus on the first input
            Browser.Instance.Wait(10000).ForElement(By.Id("user_login"));
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }

        public static void LoginAsAdministrator()
        {
            new LoginCommand("admin").WithPassword("password").Login();
        }
    }
}
