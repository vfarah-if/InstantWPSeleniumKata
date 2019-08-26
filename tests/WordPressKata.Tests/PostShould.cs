using System;
using Xunit;
using FluentAssertions;
using static WordPressKata.BrowserType;

namespace WordPressKata.Tests
{
    public class PostShould : IDisposable
    {
        public PostShould()
        {
#if DEBUG
            Browser.Open();
#else
            Browser.Open(PhantomJS);
#endif
            LoginPage.NavigateTo();
            LoginPage.NavigateTo();
            LoginPage.LoginAsAdministrator();
        }

        [Fact]
        public void CreateANewPost()
        {
            NewPostPage.NavigateTo();
            var expectedPostTitle = "This is the test post title";

            NewPostPage
                .CreatePost(expectedPostTitle)
                .WithBody("This is the body")
                .Create();
            NewPostPage.GoToNewPost();

            PostPage.Title.Should().Be(expectedPostTitle);
        }


        public void Dispose()
        {            
            Browser.Quit();
        }

    }
}
