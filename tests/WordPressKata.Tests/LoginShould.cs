using System;
using Xunit;
using FluentAssertions;

namespace WordPressKata.Tests
{
    public class LoginShould : IDisposable
    {
        public LoginShould()
        {
#if DEBUG
            Browser.Open();
#else
            Browser.Open(BrowserType.PhantomJS);
#endif
            WarmupBrowser();
        }

        [Fact]
        public void NotAllowBadUserNameAndPasswordToLogin()
        {
            LoginPage.NavigateTo();

            LoginPage
                .LoginAs("invaliduser")
                .WithPassword("badpassword")
                .Login();

            DashboardPage.IsCurrentPage.Should().BeFalse("Failed to not login");
        }


        [Fact]
        public void AllowAnAdminToLogin()
        {
            LoginPage.NavigateTo();

            LoginPage
                .LoginAs("admin")
                .WithPassword("password")
                .Login();

            DashboardPage.IsCurrentPage.Should().BeTrue("Failed to login");
        }

        public void Dispose()
        {            
            Browser.Quit();
        }

        private static void WarmupBrowser()
        {
            LoginPage.NavigateTo();
        }
    }
}
