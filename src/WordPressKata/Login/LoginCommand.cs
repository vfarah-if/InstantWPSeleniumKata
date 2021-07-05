using System;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata.Login
{
    public class LoginCommand
    {
        private readonly string _username;
        private string _password;
        private readonly bool _rememberMe;

        public LoginCommand(string username)
        {
            _username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            _password = password ?? throw new ArgumentNullException(nameof(password));
            return this;
        }

        public void Login()
        {
            FindAndTypeUsername();
            FindAndTypePassword();
            FindAndClickRememberMe();
            FindAndClickLoginButton();
        }

        private static void FindAndClickLoginButton()
        {
            Browser.Instance.Wait().ForElement(By.Id("wp-submit")).ToExist().Click();
        }

        private void FindAndClickRememberMe()
        {
            if (!_rememberMe) return;
            var byRememberMe = By.Id("rememberme");
            var rememberMeInput = Browser.Instance.FindElement(byRememberMe);
            rememberMeInput?.Click();
        }

        private void FindAndTypePassword()
        {
            Browser.Instance.TypeText(By.Id("user_pass"), _password);
        }

        private void FindAndTypeUsername()
        {
            Browser.Instance.TypeText(By.Id("user_login"), _username);
        }
    }
}
