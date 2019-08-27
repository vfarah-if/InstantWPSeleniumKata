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
            Browser.Instance.FindElement(By.Id("title")).Click();
            Browser.Instance.FindElement(By.Id("title")).SendKeys(_title);

            Browser.Instance.SwitchTo().Frame("content_ifr");
            Browser.Instance.SwitchTo().ActiveElement().SendKeys(_body);
            Browser.Instance.SwitchTo().DefaultContent();

            Browser.Instance.Wait().ForElement(By.Id("publish")).ToExist().Click();
        }
    }
}