// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.MediaAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.PostAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.Resources;
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     The profile.
    /// </summary>
    public class Profile : Entity, IValidatableObject
    {
        #region Constants

        /// <summary>
        ///     The min age
        /// </summary>
        private const int MinAge = 18;

        #endregion

        #region Fields

        /// <summary>
        ///     The _instance messages.
        /// </summary>
        private readonly HashSet<InstanceMessage> instanceMessages;

        /// <summary>
        ///     The min birthday
        /// </summary>
        private readonly DateTime minBirthday = new DateTime(1900, 1, 1);

        /// <summary>
        ///     The _is enabled.
        /// </summary>
        private bool isEnabled;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Profile" /> class.
        /// </summary>
        public Profile()
        {
            this.instanceMessages = new HashSet<InstanceMessage>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the about.
        /// </summary>
        public string About { get; set; }
        public string Resume { get; set; }
        public string Achievements { get; set; }
        public string Results { get; set; }

        /// <summary>Gets or sets the acceptors.</summary>
        public virtual IList<Friendship> Acceptors { get; set; }

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

        /// <summary>Gets or sets the initiators.</summary>
        public virtual IList<Friendship> Initiators { get; set; }

        /// <summary>
        ///     Gets the instance messages.
        /// </summary>
        public virtual ICollection<InstanceMessage> InstanceMessages
        {
            get
            {
                return this.instanceMessages;
            }

            // ReSharper disable ValueParameterNotUsed
            // ReSharper disable UnusedMember.Local
            private set
            {
                // ReSharper restore UnusedMember.Local
                // ReSharper restore ValueParameterNotUsed
            }
        }

        /// <summary>
        ///     Gets or sets the interested in.
        /// </summary>
        public InterestedIn InterestedIn { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }

            protected set
            {
                this.isEnabled = value;
            }
        }

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
        public virtual ProfilePicture Picture { get; private set; }

        /// <summary>
        ///     Gets or sets the current playing position.
        /// </summary>
        public string PlayingPosition { get; set; }

        /// <summary>
        ///     Gets or sets the political views.
        /// </summary>
        public string PoliticalViews { get; set; }

        /// <summary>Gets or sets the posts.</summary>
        public virtual IList<Post> Posts { get; set; }

        /// <summary>
        ///     Gets or sets the relationship status.
        /// </summary>
        public RelationshipStatus RelationshipStatus { get; set; }

        /// <summary>
        ///     Gets or sets the religion.
        /// </summary>
        public string Religion { get; set; }

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

        public virtual IList<Media> Medias { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The add instance message.</summary>
        /// <param name="screenName">The screen name.</param>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="InstanceMessage"/>.</returns>
        public InstanceMessage AddInstanceMessage(string screenName, InstanceMessageType type)
        {
            var im = new InstanceMessage(screenName, type) { ProfileId = this.Id };
            im.GenerateNewIdentity();
            this.InstanceMessages.Add(im);

            return im;
        }

        /// <summary>Change current identity for a new non transient identity</summary>
        /// <param name="identity">the new identity</param>
        public override void ChangeCurrentIdentity(Guid identity)
        {
            base.ChangeCurrentIdentity(identity);

            // Cascading the change Id
            if (this.Picture != null)
            {
                this.Picture.ChangeCurrentIdentity(identity);
            }
        }

        /// <summary>change the picture for this customer</summary>
        /// <param name="picture">the new picture for this customer</param>
        public void ChangePicture(ProfilePicture picture)
        {
            if (picture != null && !picture.IsTransient())
            {
                this.Picture = picture;
            }
        }

        /// <summary>
        ///     Disable customer
        /// </summary>
        public void Disable()
        {
            if (this.IsEnabled)
            {
                this.isEnabled = false;
            }
        }

        /// <summary>
        ///     Enable customer
        /// </summary>
        public void Enable()
        {
            if (!this.IsEnabled)
            {
                this.isEnabled = true;
            }
        }

        /// <summary>The validate.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The list of validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            // -->Check user name property
            if (string.IsNullOrEmpty(this.UserName))
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_ProfileUserNameCannotBeEmpty, new[] { "UserName" }));
            }

            // -->Check sex property
            if (this.Sex == Gender.Unknown)
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_ProfileSexCannotBeUnknown, new[] { "Sex" }));
            }

            // -->Check first name property
            if (string.IsNullOrWhiteSpace(this.FirstName))
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_ProfileFirstNameCannotBeNull, new[] { "FirstName" }));
            }

            // -->Check last name property
            if (string.IsNullOrWhiteSpace(this.LastName))
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_ProfileLastNameCannotBeNull, new[] { "LastName" }));
            }

            // -->Check email property
            if (string.IsNullOrWhiteSpace(this.Email))
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_ProfileEmailCannotBeEmpty, new[] { "Email" }));
            }

            // -->Check birthday property
            if (this.Birthday < this.minBirthday)
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_ProfileBirthdayInvalid, new[] { "Birthday" }));
            }

            if (this.Birthday.AddYears(MinAge) > DateTime.Today)
            {
                validationResults.Add(
                    new ValidationResult(Messages.validation_ProfileBirthdayCannotBeLessThan18, new[] { "Birthday" }));
            }

            // InstanceMessages
            foreach (InstanceMessage instanceMessage in this.InstanceMessages)
            {
                validationResults.AddRange(instanceMessage.Validate(validationContext));
            }

            return validationResults;
        }

        #endregion
    }
}