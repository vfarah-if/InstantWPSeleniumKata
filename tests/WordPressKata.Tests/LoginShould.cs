using System;
using Xunit;
using FluentAssertions;
using WordPressKata.Login;


namespace WordPressKata.Tests
{
    public class LoginShould : TestBase
    {
        public LoginShould(): base(false)
        {
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

            LoginPage.VerifyLoginFailed();
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

            LoginPage.VerifyLoginSucceeded();
            DashboardPage.IsCurrentPage.Should().BeTrue("Failed to login");
        }

        private static void WarmupBrowser()
        {
            LoginPage.NavigateTo();
        }
    }
}
