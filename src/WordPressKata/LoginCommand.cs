using System;
using OpenQA.Selenium;

namespace WordPressKata
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
            var byUserLogin = By.Id("user_login");
            Browser.Instance.FindElement(byUserLogin).Click();
            Browser.Instance.FindElement(byUserLogin).SendKeys(_username);

            var byPassword = By.Id("user_pass");
            Browser.Instance.FindElement(byPassword).Click();
            Browser.Instance.FindElement(byPassword).SendKeys(_password);

            var byRememberMe = By.Id("rememberme");
            var rememberMeInput = Browser.Instance.FindElement(byRememberMe);
            if (_rememberMe)
            {
                rememberMeInput?.Click();
            }

            var byButton = By.Id("wp-submit");
            var loginButton = Browser.Instance.FindElement(byButton);
            Browser.Wait(1000, byButton);
            loginButton.Click();
            // Wait for the login to occur
            Browser.Wait(by: By.CssSelector("div.wrap > h1"));
        }
    }
}
