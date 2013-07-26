using System;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TrafficEstimator.Selenium.Extensions
{
    public static class WebDriverExtensions
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (WebDriverExtensions));
        public static IWebElement FindElementWithDefaultWait(this IWebDriver driver, By by)
        {
            try
            {
                var timeout = Config.Current.ElementWaitTimeoutInSeconds;
                if (timeout <= 0) return driver.FindElement(@by);
                var wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(timeout), TimeSpan.FromMilliseconds(Config.Current.ElementWaitPollIntervalInMilliseconds));
                return wait.Until(drv => drv.FindElement(@by));
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                throw;
            }
        }
    }
}