using System;
using System.Configuration;

namespace TrafficEstimator.Selenium
{
    public class Config
    {
        public string ScreenshotPath { get; private set; }
        public int ElementWaitTimeoutInSeconds { get; private set; }
        public int ElementWaitPollIntervalInMilliseconds { get; private set; }
        public string RelativeWebDriverPath { get; private set; }

        public static Config Current
        {
            get
            {
                return current;
            }
        }

        static readonly Config current = new Config
        {
            ScreenshotPath = ConfigurationManager.AppSettings["ScreenshotPath"],
            RelativeWebDriverPath = ConfigurationManager.AppSettings["RelativeWebDriverPath"],
            ElementWaitTimeoutInSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["ElementWaitTimeoutInSeconds"]),
            ElementWaitPollIntervalInMilliseconds = Convert.ToInt32(ConfigurationManager.AppSettings["ElementWaitPollIntervalInMilliseconds"])
        }; 
    }
}