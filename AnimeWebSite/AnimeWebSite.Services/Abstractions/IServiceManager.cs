namespace AnimeWebSite.Services.Abstractions
{
    public interface IServiceManager
    {
        IAnimeService AnimeService { get; }

        ICommentsService CommentsService { get; }
    }
}
