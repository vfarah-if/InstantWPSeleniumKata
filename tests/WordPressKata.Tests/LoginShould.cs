using System;
using Xunit;
using FluentAssertions;

namespace WordPressKata.Tests
{
    public class LoginShould : IDisposable
    {
        public LoginShould()
        {
            Browser.Open();    
        }

        [Fact]
        public void AllowAnAdminToLogin()
        {
            LoginPage.NavigateTo();

            LoginPage
                .LoginAs("admin")
                .WithPassword("password")
                .Login();

            DashboardPage.IsCurrentPage.Should().BeTrue();
        }

        public void Dispose()
        {
            Browser.Quit();
        }
    }
}
