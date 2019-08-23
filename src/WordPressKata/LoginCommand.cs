using System;

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
        }
    }
}
