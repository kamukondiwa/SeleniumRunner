//using NUnit.Framework;
using TrafficEstimator.Selenium.Tasks;

namespace TrafficEstimator.Selenium
{
    //[TestFixture]
    public class RunnerTests
    {
        //[Test]
        public void CanGoToFavourites()
        {
            using (var runner = new Runner<FavouritesTask>())
            {
                runner.Execute();
            }
        }
    }
}