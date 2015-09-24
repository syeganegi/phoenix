namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging
{
    public class PagedResponseBase
    {
        public int NumberOfItemsFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}