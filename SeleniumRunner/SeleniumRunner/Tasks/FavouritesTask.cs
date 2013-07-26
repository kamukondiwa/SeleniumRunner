using OpenQA.Selenium;
using TrafficEstimator.Selenium.Extensions;
using TrafficEstimator.Selenium.Contracts;
using TrafficEstimator.Selenium.Pages;

namespace TrafficEstimator.Selenium.Tasks
{
    public class FavouritesTask : ISeleniumTask
    {
        private readonly IWebDriver context;
        private readonly LoginPage loginPage;

        public string Title { get { return "Download all client's favourites list"; } }

        public string Url { get { return "http://www.something.com/" + loginPage.Url; } }

        public void Execute()
        {
            loginPage.Login();
            Favourites.Click();
        }

        public FavouritesTask(IWebDriver context)
        {
            this.context = context;
            loginPage = new LoginPage(context);
        }

        public IWebElement Favourites { get { return context.FindElementWithDefaultWait(By.PartialLinkText("Favorites")); } }
    }
}