using OpenQA.Selenium;
using TrafficEstimator.Selenium.Contracts;

namespace TrafficEstimator.Selenium.Pages
{
    public class LoginPage : IPagePeer
    {
        private readonly ISearchContext context;

        public LoginPage(ISearchContext context)
        {
            this.context = context;
        }

        public void Login()
        {
            var username = context.FindElement(By.Id("username"));
            username.SendKeys("username");

            var password = context.FindElement(By.Id("password"));
            password.SendKeys("password");

            var loginButton = context.FindElement(By.CssSelector(".loginBnt"));
            loginButton.Submit();
        }

        public string Title { get { return "Login page"; } }
        public string Url { get { return "/login.php"; }}
    }
}