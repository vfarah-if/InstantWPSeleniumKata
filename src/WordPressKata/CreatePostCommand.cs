using System;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace WordPressKata
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
            // Wait for the frame delay
            Browser.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            Browser.Instance.Wait(1000).ForElement(By.Id("publish"));
            Browser.Instance.FindElement(By.Id("publish")).Click();
            // Wait for the animation
            Browser.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
        }
    }
}