// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileViewRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   Base contract for product repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     Base contract for product repository
    ///     <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{Profile}" />
    /// </summary>
    public interface IProfileViewRepository : IRepository<ProfileView>
    {
    }
}