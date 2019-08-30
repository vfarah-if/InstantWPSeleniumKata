using Xunit;
using FluentAssertions;
using WordPressKata.Posts;

namespace WordPressKata.Tests.Posts
{
    public class PostShould : TestBase
    {
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
