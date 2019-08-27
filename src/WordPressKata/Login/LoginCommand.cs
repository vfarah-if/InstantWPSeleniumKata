using System;
using OpenQA.Selenium;

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
            var loginButton = Browser.Instance.FindElement(By.Id("wp-submit"));
            loginButton.Click();
        }

        private void FindAndClickRememberMe()
        {
            var byRememberMe = By.Id("rememberme");
            var rememberMeInput = Browser.Instance.FindElement(byRememberMe);
            if (_rememberMe)
            {
                rememberMeInput?.Click();
            }
        }

        private void FindAndTypePassword()
        {
            var byPassword = By.Id("user_pass");
            Browser.Instance.FindElement(byPassword).Click();
            Browser.Instance.FindElement(byPassword).SendKeys(_password);
        }

        private void FindAndTypeUsername()
        {
            var byUserLogin = By.Id("user_login");
            Browser.Instance.FindElement(byUserLogin).Click();
            Browser.Instance.FindElement(byUserLogin).SendKeys(_username);
        }
    }
}
