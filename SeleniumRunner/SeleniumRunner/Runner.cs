using System;
using log4net;
using SeleniumRunner.Contracts;

namespace SeleniumRunner
{
    public class Runner<TSeleniumTask> : IDisposable where TSeleniumTask : ISeleniumTask
    {
        private readonly ILog log = LogManager.GetLogger(typeof (Runner<TSeleniumTask>));

        public Runner()
        {
            BrowserPeer.Create();
        }

        public void Dispose()
        {
            try
            {
                BrowserPeer.Current.Quit();
            }
            catch (Exception exception)
            {
                log.Error(string.Format("Could not dispose runner for task of type {0}", typeof(TSeleniumTask).FullName), exception);
                throw;
            }
        }

        public void Execute()
        {
            var task = CreateTask();
            BrowserPeer.Current.WebDriver.Navigate().GoToUrl(task.Url);
            try
            {
                task.Execute();
            }
            catch (Exception exception)
            {
                log.Error(string.Format("Could not execute task of type {0}", typeof(TSeleniumTask).FullName), exception);
                BrowserPeer.Current.TakeScreenshot(task.Title);
                throw;
            }
        }

        private TSeleniumTask CreateTask()
        {
            try
            {
                var context = BrowserPeer.Current.WebDriver;
                return (TSeleniumTask)Activator.CreateInstance(typeof(TSeleniumTask), new object[] { context });
            }
            catch (Exception exception)
            {
                log.Error(string.Format("Could not create task of type {0}", typeof(TSeleniumTask).FullName), exception);
                throw;
            }
        }
    }
}