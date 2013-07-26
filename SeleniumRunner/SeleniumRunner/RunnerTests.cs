using NUnit.Framework;
using SeleniumRunner.Tasks;

namespace SeleniumRunner
{
    [TestFixture]
    public class RunnerTests
    {
        [Test]
        public void CanGoToFavourites()
        {
            using (var runner = new Runner<FavouritesTask>())
            {
                runner.Execute();
            }
        }
    }
}