// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostSpecifications.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;

    /// <summary>
    ///     A list of Post specifications. You can learn
    ///     about Specifications, Enhanced Query Objects or repository methods
    ///     reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
    /// </summary>
    public static class PostSpecifications
    {
        #region Public Methods and Operators

        /// <summary>Post with firstName or LastName equal to <paramref name="text"/></summary>
        /// <param name="profileId">The profile Id.</param>
        /// <returns>Associated specification for this creterion</returns>
        public static Specification<Post> PostByProfile(Guid profileId)
        {
            return new DirectSpecification<Post>(c => c.ProfileId == profileId);
        }

        /// <summary>The post full text.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="Specification"/>.</returns>
        public static Specification<Post> PostFullText(string text)
        {
            Specification<Post> specification = new TrueSpecification<Post>();

            if (!string.IsNullOrWhiteSpace(text))
            {
                var titleNameSpec = new DirectSpecification<Post>(c => c.Title.ToLower().Contains(text));
                var contentNameSpec = new DirectSpecification<Post>(c => c.Content.ToLower().Contains(text));

                specification &= titleNameSpec || contentNameSpec;
            }

            return specification;
        }

        #endregion
    }
}