using System;
using Xunit;
using FluentAssertions;
using WordPressKata.Posts;

namespace WordPressKata.Tests
{
    public class PostShould : TestBase
    {
        // HACK: In order to prevent the browser quiting before the element is found
        public override void Dispose()
        {
            Browser.ImplicitlyWait(TimeSpan.FromSeconds(1));
            base.Dispose();
        }

        [Fact]
        public void CreateANewPost()
        {
            NewPostPage.NavigateTo();
            var expectedPostTitle = "This is the test post title";

            NewPostPage
                .CreatePost(expectedPostTitle)
                .WithBody("This is the body")
                .Publish();
            NewPostPage.NavigateToNewPost();
            PostPage.Title.Should().Be(expectedPostTitle);
        }
    }
}
