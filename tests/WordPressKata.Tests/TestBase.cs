using System;
using WordPressKata.Login;
using static WordPressKata.BrowserType;

namespace WordPressKata.Tests
{
    public class TestBase : IDisposable
    {
        public TestBase(bool shouldLogin = true)
        {
#if DEBUG
            Browser.Open();
#else
            Browser.Open(PhantomJS);
#endif
            if (shouldLogin)
            {
                LoginPage.NavigateTo();
                LoginPage.LoginAsAdministrator();
            }
        }

        public virtual void Dispose()
        {
            Browser.Quit();
        }
    }
}