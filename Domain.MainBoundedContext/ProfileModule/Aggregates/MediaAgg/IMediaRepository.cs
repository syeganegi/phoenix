// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPostRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The PostRepository interface.</summary>
    public interface IMediaRepository : IRepository<Media>
    {
    }
}