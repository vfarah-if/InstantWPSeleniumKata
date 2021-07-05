using System;
using Xunit;
using FluentAssertions;
using TestStack.BDDfy;
using TestStack.BDDfy.Configuration;
using WordPressKata.Login;


namespace WordPressKata.Tests.Login
{
    [Story(
        AsA = "As a Word Press Administrator",
        IWant = "I want to login to the system",
        SoThat = "So that I can administer my word press blogs")]
    public class BddfyLoginShould : TestBase
    {
        public BddfyLoginShould (): base(false)
        {
            WarmupBrowser();
        }

        [Fact]
        public void NotAllowBadUserNameAndPasswordToLogin()
        {
            this.Given(_ => GivenINavigateToTheLoginPage())
                .When(_ => WhenILoginAsAnInvalidUserWithABadPassword())
                .Then(_ => TheLoginShouldFail())
                .And(_ => AndTheCurrentPageShouldNotBeTheDashboardPage())
                .BDDfy("Not allow invalid users to login");
        }

        [Fact]
        public void AllowAnAdminToLogin()
        {
            this.Given(_ => GivenINavigateToTheLoginPage())
                .When(_ => WhenILoginAsAValidAdministrator())
                .Then(_ => TheLoginShouldSucceed())
                .And(_ => AndTheCurrentPageShouldBeTheDashboardPage())
                .BDDfy("Allow valid administrator to login");
        }

        private void AndTheCurrentPageShouldBeTheDashboardPage()
        {
            DashboardPage.IsCurrentPage.Should().BeTrue("Failed to login");
        }

        private void TheLoginShouldSucceed()
        {
            LoginPage.VerifyLoginSucceeded();
        }

        private void WhenILoginAsAValidAdministrator()
        {
            LoginPage
                .LoginAs("admin")
                .WithPassword("password")
                .Login();
        }

        private void GivenINavigateToTheLoginPage()
        {
            LoginPage.NavigateTo();
        }

        private void AndTheCurrentPageShouldNotBeTheDashboardPage()
        {
            DashboardPage.IsCurrentPage.Should().BeFalse("Failed to not login");
        }

        private void TheLoginShouldFail()
        {
            LoginPage.VerifyLoginFailed();
        }

        private void WhenILoginAsAnInvalidUserWithABadPassword()
        {
            LoginPage
                .LoginAs("invaliduser")
                .WithPassword("badpassword")
                .Login();
        }

        private void WarmupBrowser()
        {
            LoginPage.NavigateTo();
        }
    }
}
