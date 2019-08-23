using System;
using OpenQA.Selenium.Chrome;

namespace WordPressKata
{
    public static class LoginPage
    {
        public static void NavigateTo()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://127.0.0.1:10080/wordpress/wp-login.php");
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }
    }
}
