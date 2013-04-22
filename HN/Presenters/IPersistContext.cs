namespace voidsoft.HackerNews.Presenters
{
    public interface IPersistContext
    {
        void RestoreState();

        void SaveState();
    }
}