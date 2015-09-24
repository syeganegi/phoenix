// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   This is the data transfer object
//   for Profile entity. The name
//   of properties for this type
//   is based on conventions of many mappers
//   to simplify the mapping process
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     This is the data transfer object
    ///     for Profile entity. The name
    ///     of properties for this type
    ///     is based on conventions of many mappers
    ///     to simplify the mapping process
    /// </summary>
    public class ProfileDTO : ProfileDTOBase
    {
        #region Public Properties

        public FriendshipDTO Friendship { get; set; }    

        /// <summary>
        ///     Gets or sets the about.
        /// </summary>
        /// <value>
        ///     The about.
        /// </value>
        public string About { get; set; }

        /// <summary>Gets or sets the achievements.</summary>
        public string Achievements { get; set; }

        /// <summary>
        ///     Gets or sets the address address line1.
        /// </summary>
        /// <value>
        ///     The address address line1.
        /// </value>
        public string AddressAddressLine1 { get; set; }

        /// <summary>
        ///     Gets or sets the address address line2.
        /// </summary>
        /// <value>
        ///     The address address line2.
        /// </value>
        public string AddressAddressLine2 { get; set; }

        /// <summary>
        ///     Gets or sets the address city.
        /// </summary>
        /// <value>
        ///     The address city.
        /// </value>
        public string AddressCity { get; set; }

        /// <summary>
        ///     Gets or sets the address zip code.
        /// </summary>
        /// <value>
        ///     The address zip code.
        /// </value>
        public string AddressZipCode { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the current club team.
        /// </summary>
        public string ClubTeam { get; set; }

        /// <summary>
        ///     Gets or sets the college university.
        /// </summary>
        public string CollegeUniversity { get; set; }

        /// <summary>
        ///     Gets or sets the current contract dates.
        /// </summary>
        public DateTime? ContractDateFrom { get; set; }

        /// <summary>Gets or sets the contract date to.</summary>
        public DateTime? ContractDateTo { get; set; }

        /// <summary>
        ///     Gets or sets the current city.
        /// </summary>
        public string CurrentCity { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>
        ///     The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the favorite other sport.
        /// </summary>
        public string FavoriteOtherSport { get; set; }

        /// <summary>
        ///     Gets or sets the favorite sporting idol.
        /// </summary>
        public string FavoriteSportingIdol { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        ///     Gets or sets the high school.
        /// </summary>
        public string HighSchool { get; set; }

        /// <summary>Gets or sets the home phone.</summary>
        public string HomePhone { get; set; }

        /// <summary>
        ///     Gets or sets the hometown.
        /// </summary>
        public string Hometown { get; set; }

        /// <summary>
        ///     Gets or sets the instance messages.
        /// </summary>
        public IList<InstanceMessageDTO> InstanceMessages { get; set; }

        /// <summary>
        ///     Gets or sets the interested in.
        /// </summary>
        public string InterestedIn { get; set; }

        /// <summary>Gets or sets a value indicating whether is enabled.</summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets the job.
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        ///     Gets or sets the languages.
        /// </summary>
        public string Languages { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the current management company.
        /// </summary>
        public string ManagementCompany { get; set; }

        /// <summary>Gets or sets the mobile phone.</summary>
        public string MobilePhone { get; set; }

        /// <summary>Gets or sets the nationality.</summary>
        public string Nationality { get; set; }

        /// <summary>
        ///     Gets or sets the overseas opportunities.
        /// </summary>
        public string OverseasOpportunities { get; set; }

        /// <summary>
        ///     Gets or sets the picture raw photo.
        /// </summary>
        /// <value>
        ///     The picture raw photo.
        /// </value>
        public byte[] PictureRawPhoto { get; set; }

        /// <summary>
        ///     Gets or sets the current playing position.
        /// </summary>
        public string PlayingPosition { get; set; }

        /// <summary>
        ///     Gets or sets the political views.
        /// </summary>
        public string PoliticalViews { get; set; }

        /// <summary>
        ///     Gets or sets the relationship status.
        /// </summary>
        public string RelationshipStatus { get; set; }

        /// <summary>
        ///     Gets or sets the religion.
        /// </summary>
        public string Religion { get; set; }

        /// <summary>Gets or sets the results.</summary>
        public string Results { get; set; }

        /// <summary>Gets or sets the resume.</summary>
        public string Resume { get; set; }

        /// <summary>
        ///     Gets or sets the school achievements.
        /// </summary>
        public string SchoolAchievements { get; set; }

        /// <summary>
        ///     Gets or sets the secondary school.
        /// </summary>
        public string SecondarySchool { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        public string Sex { get; set; }

        /// <summary>Gets or sets the signed by.</summary>
        public string SignedBy { get; set; }

        /// <summary>
        ///     Gets or sets the sport.
        /// </summary>
        public string Sport { get; set; }

        /// <summary>
        ///     Gets or sets the sport achievements.
        /// </summary>
        public string SportAchievements { get; set; }

        /// <summary>
        ///     Gets or sets the website.
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        ///     Gets or sets the weight.
        /// </summary>
        public string Weight { get; set; }

        /// <summary>Gets or sets the work phone.</summary>
        public string WorkPhone { get; set; }

        #endregion
    }
}