// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappersExtensionMethods.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Mappers
{
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;

    /// <summary>The mappers extension methods.</summary>
    public static class MappersExtensionMethods
    {
        #region Public Methods and Operators

        /// <summary>The convert to adminModel.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="AboutModel"/>.</returns>
        public static ProfileSearchResult[] ConvertToModel(this ProfileSearchResultDTO[] dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfileSearchResult[]>(dto);
        }

        public static ProfileModel[] ConvertToModel(this ProfileListDTO[] dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfileModel[]>(dto);
        }

        public static ProfileAdminModel[] ConvertToAdminModel(this ProfileListDTO[] dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfileAdminModel[]>(dto);
        }

        public static ProfileStatsModel[] ConvertToModel(this ProfileStatsDTO[] dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfileStatsModel[]>(dto);
        }

        public static PostModel[] ConvertToModel(this PostDTO[] dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<PostModel[]>(dto);
        }

        public static PostModel ConvertToModel(this PostDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<PostModel>(dto);
        }

        public static MediaModel[] ConvertToModel(this MediaDTO[] dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<MediaModel[]>(dto);
        }

        public static MediaModel ConvertToModel(this MediaDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<MediaModel>(dto);
        }

        public static ProfileCounterModel ConvertToModel(this ProfileCounterDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfileCounterModel>(dto);
        }

        public static AboutModel ConvertToModel(this AboutDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<AboutModel>(dto);
        }

        public static ResultsModel ConvertToModel(this ResultsDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ResultsModel>(dto);
        }

        public static ResumeModel ConvertToModel(this ResumeDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ResumeModel>(dto);
        }

        public static AchievementsModel ConvertToModel(this AchievementsDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<AchievementsModel>(dto);
        }

        public static ProfileSummaryModel ConvertToModel(this ProfileSummaryDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfileSummaryModel>(dto);
        }

        public static ProfilePictureModel ConvertToModel(this ProfilePictureDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfilePictureModel>(dto);
        }

        /// <summary>The convert to adminModel.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ContactModel"/>.</returns>
        public static ContactModel ConvertToModel(this ContactDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ContactModel>(dto);
        }

        /// <summary>The convert to adminModel.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="LivingModel"/>.</returns>
        public static LivingModel ConvertToModel(this LivingDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<LivingModel>(dto);
        }

        /// <summary>The convert to adminModel.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="WorkEduModel"/>.</returns>
        public static WorkEduModel ConvertToModel(this WorkEduDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<WorkEduModel>(dto);
        }

        /// <summary>The convert to adminModel.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="SportModel"/>.</returns>
        public static SportModel ConvertToModel(this SportDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<SportModel>(dto);
        }

        /// <summary>The convert to adminModel.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="ProfilePageModel"/>.</returns>
        public static ProfilePageModel ConvertToModel(this ProfileDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfilePageModel>(dto);
        }

        public static ProfileAdminModel ConvertToAdminModel(this ProfileDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfileAdminModel>(dto);
        }

        /// <summary>The convert to adminModel.</summary>
        /// <param name="dto">The dto.</param>
        /// <returns>The <see cref="BasicInfoModel"/>.</returns>
        public static BasicInfoModel ConvertToModel(this BasicInfoDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<BasicInfoModel>(dto);
        }

        public static ProfilePrincipal ConvertToPrincipal(this ProfileDTO dto)
        {
            ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<ProfilePrincipal>(dto);
        }

        #endregion
    }
}