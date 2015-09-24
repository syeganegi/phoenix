// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileProfile.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.Profiles
{
    using System;

    using AutoMapper;

    using Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileViewAgg;

    using Profile = AutoMapper.Profile;

    /// <summary>
    ///     The profile profile.
    /// </summary>
    public class ProfileProfile : Profile
    {
        #region Methods

        /// <summary>
        ///     The configure.
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<InstanceMessage, InstanceMessageDTO>();
            Mapper.CreateMap<InstanceMessageDTO, InstanceMessage>();
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, DeletedProfile>()
                  .ForMember(dp => dp.Picture, opt => opt.MapFrom(p => p.Picture.RawPhoto))
                  .ForMember(dp => dp.DateDeleted, opt => opt.UseValue(DateTime.Now));

            // profile => profilelistdto
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ProfileListDTO>();

            // profile => profiledto
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ProfileDTO>()
                  .ForMember(dto => dto.PictureRawPhoto, opt => opt.MapFrom(src => src.Picture.RawPhoto));

            // profile <=> aboutdto
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, AboutDTO>();
            Mapper.CreateMap<AboutDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // profile <=> ResultsDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ResultsDTO>();
            Mapper.CreateMap<ResultsDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // profile <=> ResumeDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ResumeDTO>();
            Mapper.CreateMap<ResumeDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // profile <=> AchievementsDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, AchievementsDTO>();
            Mapper.CreateMap<AchievementsDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // profile <=> basicInfodto
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, BasicInfoDTO>();
            Mapper.CreateMap<BasicInfoDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore())
                  .ForMember(d => d.Sex, opt => opt.MapFrom(s => s.Sex));

            // profile <=> ContactDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ContactDTO>();
            Mapper.CreateMap<ContactDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // profile <=> WorkEduDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, WorkEduDTO>();
            Mapper.CreateMap<WorkEduDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // profile <=> LivingDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, LivingDTO>();
            Mapper.CreateMap<LivingDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // profile <=> SportDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, SportDTO>();
            Mapper.CreateMap<SportDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // Profile <=> ProfileSummaryDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ProfileSummaryDTO>();
            Mapper.CreateMap<ProfileSummaryDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ForMember(x => x.Id, y => y.Ignore())
                  .ForMember(x => x.UserName, y => y.Ignore());

            // ProfilePicture <=> ProfilePictureDTO
            Mapper.CreateMap<ProfilePicture, ProfilePictureDTO>();
            Mapper.CreateMap<ProfilePictureDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>()
                  .ConvertUsing<ProfilePictureConvertor>();

            // ProfileView <=> ProfileStatsDTO
            Mapper.CreateMap<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ProfileStatsDTO>();
            Mapper.CreateMap<ProfileView, ProfileStatsDTO>().ConvertUsing<ProfileViewConvertor>();

            // Friendship <=> FriendshipDTO
            Mapper.CreateMap<Friendship, FriendshipDTO>();

            // ProfileSearchResult <=> ProfileSearchResultDTO
            Mapper.CreateMap<ProfileSearchResult, ProfileSearchResultDTO>();

            // Post <=> PostDTO
            Mapper.CreateMap<Post, PostDTO>();

            // Media <=> MediaDTO
            Mapper.CreateMap<Media, MediaDTO>();

            // Mapper.AssertConfigurationIsValid();
        }

        #endregion
    }

    public class ProfileViewConvertor : ITypeConverter<ProfileView, ProfileStatsDTO>
    {
        public ProfileStatsDTO Convert(ResolutionContext context)
        {
            var source = context.SourceValue as ProfileView;
            if (source == null || source.Viewer == null)
            {
                return null;
            }

            var viewer = source.Viewer;
            var dto =
                Mapper.Map<Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile, ProfileStatsDTO>(viewer);
            dto.DateViewed = source.DateViewed;

            return dto;
        }
    }

    /// <summary>The profile picture convertor.</summary>
    public class ProfilePictureConvertor :
        ITypeConverter<ProfilePictureDTO, Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile>
    {
        #region Public Methods and Operators

        /// <summary>The convert.</summary>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Profile"/>.</returns>
        public Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile Convert(ResolutionContext context)
        {
            var pictureDTO = context.SourceValue as ProfilePictureDTO;
            var profile =
                context.DestinationValue as Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile;

            if (profile != null && pictureDTO != null)
            {
                profile.Picture.RawPhoto = pictureDTO.RawPhoto;
            }

            return profile;
        }

        #endregion
    }
}