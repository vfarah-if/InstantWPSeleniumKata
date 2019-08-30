using System;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata.Posts
{
    public class CreatePostCommand
    {
        private readonly string _title;
        private string _body;

        public CreatePostCommand(string title)
        {
            _title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            _body = body;
            return this;
        }

        public void Publish()
        {
            FindAndTypeTitleText();

            FindAndTypeBodyTextIntoFrame();

            FindAndClickOnPublishButton();
        }

        private static void FindAndClickOnPublishButton()
        {
                WaitForBodyToBeReady();
                Browser.Instance.Wait().ForElement(By.Id("publish")).ToExist().Click();
                WaitForAnimationToFinish();
        }

        private static void WaitForAnimationToFinish()
        {
            Browser.PauseFor(TimeSpan.FromSeconds(2));
        }

        private static void WaitForBodyToBeReady()
        {
            Browser.PauseFor(TimeSpan.FromSeconds(2));
        }

        private void FindAndTypeBodyTextIntoFrame()
        {
            Browser.Instance.SwitchTo().Frame("content_ifr");
            Browser.Instance.SwitchTo().ActiveElement().SendKeys(_body);
            Browser.Instance.SwitchTo().DefaultContent();
        }

        private void FindAndTypeTitleText()
        {
            Browser.Instance.TypeText(By.Id("title"), _title);
        }
    }
}