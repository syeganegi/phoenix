// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelProfile.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Mappers
{
    using System;

    using AutoMapper;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Entities;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;

    /// <summary>
    ///     The profile profile.
    /// </summary>
    public class ModelProfile : Profile
    {
        #region Methods

        /// <summary>
        ///     The configure.
        /// </summary>
        protected override void Configure()
        {
            // Birthday <=> DateTime
            Mapper.CreateMap<Birthday, DateTime>().ConvertUsing(s => new DateTime(s.Year, s.Month, s.Day));
            Mapper.CreateMap<DateTime, Birthday>().ConvertUsing(s => new Birthday(s));

            // DTO => Model
            Mapper.CreateMap<ProfileDTO, ProfilePageModel>().ConvertUsing<ProfileDTOConverter>();
            Mapper.CreateMap<ProfileDTO, AboutModel>();
            Mapper.CreateMap<ProfileDTO, ResultsModel>();
            Mapper.CreateMap<ProfileDTO, ResumeModel>();
            Mapper.CreateMap<ProfileDTO, AchievementsModel>();
            Mapper.CreateMap<ProfileDTO, ProfileSummaryModel>()
                  .ForMember(dest => dest.Sex, opt => opt.ResolveUsing<ProfileSexResolver>());
            Mapper.CreateMap<ProfileDTO, ProfilePictureModel>();
            Mapper.CreateMap<ProfileDTO, BasicInfoModel>()
                  .ForMember(dest => dest.Sex, opt => opt.ResolveUsing<ProfileSexResolver>());
            Mapper.CreateMap<ProfileDTO, ContactModel>();
            Mapper.CreateMap<ProfileDTO, WorkEduModel>();
            Mapper.CreateMap<ProfileDTO, LivingModel>();
            Mapper.CreateMap<ProfileDTO, SportModel>();

            Mapper.CreateMap<ProfileDTO, ProfileAdminModel>();
            Mapper.CreateMap<ProfileListDTO, ProfileAdminModel>();
            Mapper.CreateMap<ProfileDTO, ProfilePrincipal>();
            Mapper.CreateMap<AboutDTO, AboutModel>();
            Mapper.CreateMap<ResumeDTO, ResumeModel>();
            Mapper.CreateMap<AchievementsDTO, AchievementsModel>();
            Mapper.CreateMap<ProfileSummaryDTO, ProfileSummaryModel>()
                  .ForMember(dest => dest.Sex, opt => opt.ResolveUsing<ProfileSummarySexResolver>());
            Mapper.CreateMap<BasicInfoDTO, BasicInfoModel>()
                  .ForMember(dest => dest.Sex, opt => opt.ResolveUsing<BasicInfoSexResolver>());
            Mapper.CreateMap<ContactDTO, ContactModel>();
            Mapper.CreateMap<WorkEduDTO, WorkEduModel>();
            Mapper.CreateMap<LivingDTO, LivingModel>();
            Mapper.CreateMap<SportDTO, SportModel>();
            Mapper.CreateMap<ProfilePictureDTO, ProfilePictureModel>();
            Mapper.CreateMap<ProfileListDTO, ProfileModel>();
            Mapper.CreateMap<ProfileStatsDTO, ProfileStatsModel>();
            Mapper.CreateMap<ProfileCounterDTO, ProfileCounterModel>();
            Mapper.CreateMap<ProfileSearchResultDTO, ProfileSearchResult>();
            Mapper.CreateMap<PostDTO, PostModel>();
            Mapper.CreateMap<MediaDTO, MediaModel>();
            Mapper.CreateMap<FriendshipDTO, FriendshipModel>();

            // Model => DTO
            Mapper.CreateMap<AboutModel, AboutDTO>();
            Mapper.CreateMap<ResultsModel, ResultsDTO>();
            Mapper.CreateMap<ResumeModel, ResumeDTO>();
            Mapper.CreateMap<AchievementsModel, AchievementsDTO>();
            Mapper.CreateMap<ProfileSummaryModel, ProfileSummaryDTO>();
            Mapper.CreateMap<BasicInfoModel, BasicInfoDTO>();
            Mapper.CreateMap<ContactModel, ContactDTO>();
            Mapper.CreateMap<WorkEduModel, WorkEduDTO>();
            Mapper.CreateMap<LivingModel, LivingDTO>();
            Mapper.CreateMap<SportModel, SportDTO>();
            Mapper.CreateMap<ProfilePictureModel, ProfilePictureDTO>();
            Mapper.CreateMap<PostModel, PostDTO>();
            Mapper.CreateMap<MediaModel, MediaDTO>();

        }

        #endregion
    }

    /// <summary>The profile sex resolver.</summary>
    internal class ProfileSexResolver : ValueResolver<ProfileDTO, Sex>
    {
        #region Methods

        /// <summary>The resolve core.</summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="Sex"/>.</returns>
        protected override Sex ResolveCore(ProfileDTO source)
        {
            return (Sex)Enum.Parse(typeof(Sex), source.Sex, true);
        }

        #endregion
    }

    /// <summary>The basic info sex resolver.</summary>
    internal class BasicInfoSexResolver : ValueResolver<BasicInfoDTO, Sex>
    {
        #region Methods

        /// <summary>The resolve core.</summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="Sex"/>.</returns>
        protected override Sex ResolveCore(BasicInfoDTO source)
        {
            return (Sex)Enum.Parse(typeof(Sex), source.Sex, true);
        }

        #endregion
    }

    /// <summary>The basic info sex resolver.</summary>
    internal class ProfileSummarySexResolver : ValueResolver<ProfileSummaryDTO, Sex>
    {
        #region Methods

        /// <summary>The resolve core.</summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="Sex"/>.</returns>
        protected override Sex ResolveCore(ProfileSummaryDTO source)
        {
            return (Sex)Enum.Parse(typeof(Sex), source.Sex, true);
        }

        #endregion
    }

    /// <summary>The profile dto converter.</summary>
    internal class ProfileDTOConverter : ITypeConverter<ProfileDTO, ProfilePageModel>
    {
        #region Public Methods and Operators

        /// <summary>The convert.</summary>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="ProfilePageModel"/>.</returns>
        public ProfilePageModel Convert(ResolutionContext context)
        {
            var dto = context.SourceValue as ProfileDTO;
            if (dto == null)
            {
                return null;
            }

            var profileModel = new ProfilePageModel
                                   {
                                       About = Mapper.Map<ProfileDTO, AboutModel>(dto),
                                       Results = Mapper.Map<ProfileDTO, ResultsModel>(dto),
                                       Resume = Mapper.Map<ProfileDTO, ResumeModel>(dto),
                                       Achievements = Mapper.Map<ProfileDTO, AchievementsModel>(dto),
                                       ProfileSummary = Mapper.Map<ProfileDTO, ProfileSummaryModel>(dto),
                                       ProfilePicture = Mapper.Map<ProfileDTO, ProfilePictureModel>(dto), 
                                       Friendship = Mapper.Map<FriendshipDTO, FriendshipModel>(dto.Friendship)
                                   };

            return profileModel;
        }

        #endregion
    }
}