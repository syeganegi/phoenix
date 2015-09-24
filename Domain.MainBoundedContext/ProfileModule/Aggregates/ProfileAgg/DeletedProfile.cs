// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeletedProfile.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>The deleted profile.</summary>
    public class DeletedProfile : Entity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the about.
        /// </summary>
        public string About { get; set; }

        /// <summary>Gets or sets the achievements.</summary>
        public string Achievements { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        public virtual ProfileAddress Address { get; set; }

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

        /// <summary>Gets or sets the date deleted.</summary>
        public DateTime DateDeleted { get; set; }

        /// <summary>Gets or sets the email.</summary>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the favorite sporting idol.
        /// </summary>
        public string FavoriteSportingIdol { get; set; }

        /// <summary>
        ///     Gets or sets the favorite other sport.
        /// </summary>
        public string FavouriteOtherSport { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }

            // ReSharper disable ValueParameterNotUsed
            set
            {
                // ReSharper restore ValueParameterNotUsed
            }
        }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        public string Height { get; set; }

        /// <summary>Gets or sets the home phone.</summary>
        public string HomePhone { get; set; }

        /// <summary>
        ///     Gets or sets the hometown.
        /// </summary>
        public string Hometown { get; set; }

        /// <summary>
        ///     Gets or sets the interested in.
        /// </summary>
        public InterestedIn InterestedIn { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is enabled.
        /// </summary>
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
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the current management company.
        /// </summary>
        /// <value>
        ///     The current management company.
        /// </value>
        public string ManagementCompany { get; set; }

        /// <summary>Gets or sets the mobile phone.</summary>
        public string MobilePhone { get; set; }

        /// <summary>Gets or sets the nationality.</summary>
        public string Nationality { get; set; }

        /// <summary>
        ///     Gets or sets the overseas/country opportunities.
        /// </summary>
        /// <value>
        ///     The overseas opportunities.
        /// </value>
        public string OverseasOpportunities { get; set; }

        /// <summary>
        ///     Gets the picture.
        /// </summary>
        public byte[] Picture { get; set; }

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
        public RelationshipStatus RelationshipStatus { get; set; }

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
        public Gender Sex { get; set; }

        /// <summary>Gets or sets the signed by.</summary>
        public string SignedBy { get; set; }

        /// <summary>
        ///     Gets or sets the sport.
        /// </summary>
        public string Sport { get; set; }

        /// <summary>
        ///     Gets or sets the sport achievements.
        /// </summary>
        /// <value>
        ///     The sport achievements.
        /// </value>
        public string SportAchievements { get; set; }

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>Gets or sets the view counter.</summary>
        public long ViewCounter { get; set; }

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