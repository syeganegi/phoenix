// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPostRepository.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg
{
    using System;
    using System.Collections.Generic;

    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The PostRepository interface.</summary>
    public interface IPostRepository : IRepository<Post>
    {
    }
}