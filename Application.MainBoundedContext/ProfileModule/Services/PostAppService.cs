// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostAppService.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The post app service.
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
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;

    /// <summary>The post app service.</summary>
    public class PostAppService : IPostAppService
    {
        #region Fields

        /// <summary>The post repository.</summary>
        private readonly IPostRepository postRepository;

        /// <summary>The profile repository.</summary>
        private readonly IProfileRepository profileRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="PostAppService"/> class.</summary>
        /// <param name="postRepository">The post repository.</param>
        /// <param name="profileRepository">The profile Repository.</param>
        public PostAppService(IPostRepository postRepository, IProfileRepository profileRepository)
        {
            Guard.ArgumentIsNotNull(postRepository, "postRepository");
            Guard.ArgumentIsNotNull(profileRepository, "profileRepository");

            this.postRepository = postRepository;
            this.profileRepository = profileRepository;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The add new post.</summary>
        /// <param name="postDTO">The post dto.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        public PostDTO AddNewPost(PostDTO postDTO)
        {
            // check preconditions
            if (postDTO == null)
            {
                throw new ArgumentException(Messages.warning_CannotAddPostWithEmptyInformation);
            }

            Post post = PostFactory.Create(postDTO.Title, postDTO.Content, postDTO.ProfileId);

            // save entity
            this.SaveProfile(post);

            // return the data with id and assigned default values
            return post.ProjectedAs<PostDTO>();
        }

        /// <summary>The delete post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeletePost(Guid id)
        {
            Post post = this.postRepository.Get(id);
            if (post == null)
            {
                return false;
            }

            this.postRepository.Remove(post);
            this.postRepository.UnitOfWork.Commit();

            return true;
        }

        /// <summary>The get post.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="PostDTO"/>.</returns>
        public PostDTO GetPost(Guid id)
        {
            Guard.ArgumentIsEmpty(id, "id");

            Post post = this.postRepository.Get(id);
            return post == null ? null : post.ProjectedAs<PostDTO>();
        }

        /// <summary>The get posts.</summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="List"/>.</returns>
        /// <exception cref="Exception"></exception>
        public List<PostDTO> GetPosts(string username)
        {
            Guard.ArgumentIsNotNullOrEmpty(username, "username");

            Profile profile = this.profileRepository.Get(username);
            if (profile == null)
            {
                throw new Exception(Messages.exception_ProfileViewerWasNotFound);
            }

            Specification<Post> spec = PostSpecifications.PostByProfile(profile.Id);
            List<Post> posts =
                this.postRepository.GetFiltered(spec.SatisfiedBy()).OrderByDescending(p => p.DateCreated).ToList();

            return posts.ProjectedAsCollection<PostDTO>();
        }

        #endregion

        #region Methods

        /// <summary>The save profile.</summary>
        /// <param name="post">The post.</param>
        /// <exception cref="ApplicationValidationErrorsException"></exception>
        private void SaveProfile(Post post)
        {
            // recover validator
            IEntityValidator validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(post))
            {
                // if post is valid
                // add the post into the repository
                this.postRepository.Add(post);

                // commit the unit of work
                this.postRepository.UnitOfWork.Commit();
            }
            else
            {
                // post is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(post));
            }
        }

        #endregion
    }
}