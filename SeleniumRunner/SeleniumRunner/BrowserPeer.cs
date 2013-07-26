using System;
using System.Drawing.Imaging;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumRunner
{
    public class BrowserPeer
    {
        private static BrowserPeer current;
        private static readonly ILog Log = LogManager.GetLogger(typeof (BrowserPeer));
        private readonly string screenshotPath;

        public BrowserPeer(IWebDriver webDriver, string screenshotPath)
        {
            WebDriver = webDriver;
            this.screenshotPath = screenshotPath;
        }

        public IWebDriver WebDriver { get; private set; }

        public static BrowserPeer Current
        {
            get { return current; }
        }

        public static void Create()
        {
            var uri = new Uri(new Uri(Environment.CurrentDirectory), Config.Current.RelativeWebDriverPath);
            var path = Config.Current.ScreenshotPath;

            try
            {
                current = new BrowserPeer(new ChromeDriver(uri.LocalPath), path);
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Could not create web browser peer. Web Driver ({0}). Screenshotpath ({1}).", uri, path), exception);
                throw;
            }
        }

        public void Quit()
        {
            WebDriver.Quit();
        }

        public void TakeScreenshot(string title)
        {
            var path = string.Format("{0}\\{1}_{2}.jpg", screenshotPath, title, DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss"));
            try
            {
                var takesScreenShot = WebDriver as ITakesScreenshot;
                if (takesScreenShot == null) return;
                var screenshot = takesScreenShot.GetScreenshot();
                screenshot.SaveAsFile(path, ImageFormat.Jpeg);
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Could not create screenshot ({0}).", path), exception);
                throw;
            }
        }
    }
}