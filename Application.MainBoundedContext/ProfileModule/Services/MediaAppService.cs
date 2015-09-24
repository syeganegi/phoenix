// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The media app service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Application.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Application.Seedwork;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;

    /// <summary>The media app service.</summary>
    public class MediaAppService : IMediaAppService
    {
        #region Fields

        /// <summary>The media repository.</summary>
        private readonly IMediaRepository mediaRepository;

        /// <summary>The profile repository.</summary>
        private readonly IProfileRepository profileRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MediaAppService"/> class.</summary>
        /// <param name="mediaRepository">The media repository.</param>
        /// <param name="profileRepository">The profile Repository.</param>
        public MediaAppService(IMediaRepository mediaRepository, IProfileRepository profileRepository)
        {
            Guard.ArgumentIsNotNull(mediaRepository, "mediaRepository");
            Guard.ArgumentIsNotNull(profileRepository, "profileRepository");

            this.mediaRepository = mediaRepository;
            this.profileRepository = profileRepository;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The add new media.</summary>
        /// <param name="mediaDTO">The media dto.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        public MediaDTO AddNewMedia(MediaDTO mediaDTO)
        {
            // check preconditions
            if (mediaDTO == null)
            {
                throw new ArgumentException(Messages.warning_CannotAddMediaWithEmptyInformation);
            }

            MediaType type;
            if (!Enum.TryParse(mediaDTO.Type, true, out type))
            {
                throw new ArgumentException(Messages.warning_CannotAddMediaWithInvalidMediaType);
            }

            Media media = MediaFactory.Create(mediaDTO.Title, mediaDTO.MediaUrl, type, mediaDTO.ProfileId);

            // save entity
            this.SaveProfile(media);

            // return the data with id and assigned default values
            return media.ProjectedAs<MediaDTO>();
        }

        /// <summary>The delete media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeleteMedia(Guid id)
        {
            Media media = this.mediaRepository.Get(id);
            if (media == null)
            {
                return false;
            }

            this.mediaRepository.Remove(media);
            this.mediaRepository.UnitOfWork.Commit();

            return true;
        }

        /// <summary>The get media.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="MediaDTO"/>.</returns>
        public MediaDTO GetMedia(Guid id)
        {
            Guard.ArgumentIsEmpty(id, "id");

            Media media = this.mediaRepository.Get(id);
            return media == null ? null : media.ProjectedAs<MediaDTO>();
        }

        /// <summary>The get medias.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        /// <exception cref="Exception"></exception>
        public List<MediaDTO> GetMedias(string username)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            Profile profile = this.profileRepository.Get(username);
            if (profile == null)
            {
                throw new Exception(Messages.exception_ProfileViewerWasNotFound);
            }

            Specification<Media> spec = MediaSpecifications.MediaByProfile(profile.Id);
            List<Media> medias =
                this.mediaRepository.GetFiltered(spec.SatisfiedBy()).OrderByDescending(p => p.DateCreated).ToList();

            return medias.ProjectedAsCollection<MediaDTO>();
        }

        #endregion

        #region Methods

        /// <summary>The save profile.</summary>
        /// <param name="media">The media.</param>
        /// <exception cref="ApplicationValidationErrorsException"></exception>
        private void SaveProfile(Media media)
        {
            // recover validator
            IEntityValidator validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(media))
            {
                // if media is valid
                // add the media into the repository
                this.mediaRepository.Add(media);

                // commit the unit of work
                this.mediaRepository.UnitOfWork.Commit();
            }
            else
            {
                // media is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(media));
            }
        }

        #endregion
    }
}