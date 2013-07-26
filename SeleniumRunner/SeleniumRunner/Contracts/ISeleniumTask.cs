namespace SeleniumRunner.Contracts
{
    public interface ISeleniumTask : IPagePeer
    {
        void Execute();
    }
}