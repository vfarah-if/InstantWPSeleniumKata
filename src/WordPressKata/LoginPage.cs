using System;
using OpenQA.Selenium;

namespace WordPressKata
{
    public static class LoginPage
    {
        public static void NavigateTo()
        {
            Browser.Instance.Navigate().GoToUrl("http://127.0.0.1:10080/wordpress/wp-login.php");
            // Wait is for the focus timing issue that occurs because of the focus on the first input
            Browser.Wait(10000, By.Id("user_login"));
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }
    }
}
