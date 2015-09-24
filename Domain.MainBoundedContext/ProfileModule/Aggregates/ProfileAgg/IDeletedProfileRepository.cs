// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     Base contract for product repository
    ///     <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{Profile}" />
    /// </summary>
    public interface IDeletedProfileRepository : IRepository<DeletedProfile>
    {
    }
}