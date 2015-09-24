// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaSpecifications.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;

    /// <summary>
    ///     A list of Media specifications. You can learn
    ///     about Specifications, Enhanced Query Objects or repository methods
    ///     reading our Architecture guide and checking the DesignNotes.txt in Domain.Seedwork project
    /// </summary>
    public static class MediaSpecifications
    {
        #region Public Methods and Operators

        /// <summary>Media with firstName or LastName equal to <paramref name="text"/></summary>
        /// <param name="profileId">The profile Id.</param>
        /// <returns>Associated specification for this creterion</returns>
        public static Specification<Media> MediaByProfile(Guid profileId)
        {
            return new DirectSpecification<Media>(c => c.ProfileId == profileId);
        }

        public static Specification<Media> MediaByType(MediaType type)
        {
            return new DirectSpecification<Media>(c => c.Type == type);
        }

        public static Specification<Media> Images()
        {
            return new DirectSpecification<Media>(c => c.Type == MediaType.Image);
        }

        public static Specification<Media> Videos()
        {
            return new DirectSpecification<Media>(c => c.Type == MediaType.Video);
        }

        /// <summary>The post full text.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="Specification"/>.</returns>
        public static Specification<Media> MediaFullText(string text)
        {
            Specification<Media> specification = new TrueSpecification<Media>();

            if (!string.IsNullOrWhiteSpace(text))
            {
                var titleNameSpec = new DirectSpecification<Media>(c => c.Title.ToLower().Contains(text));

                specification &= titleNameSpec;
            }

            return specification;
        }

        #endregion
    }
}