namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using DataAnnotationsExtensions;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    [ModelBinder(typeof(ProfileModelBinder))]
    public class ProfileSummaryModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        [Required]
        [UIHint("Birthday")]
        public Birthday Birthday { get; set; }

        /// <summary>Gets or sets the current club team.</summary>
        [DisplayName("Club Team")]
        public string ClubTeam { get; set; }

        /// <summary>Gets or sets the current contract dates.</summary>
        [DisplayName("Contract From")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ContractDateFrom { get; set; }

        /// <summary>Gets or sets the contract date to.</summary>
        [DisplayName("Contract To")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ContractDateTo { get; set; }

        /// <summary>
        ///     Gets or sets the emails.
        /// </summary>
        //public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        [DisplayName("Name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        [Numeric]
        public string Height { get; set; }

        /// <value>
        ///     The last name.
        /// </value>
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the current management company.</summary>
        [DisplayName("Management Company")]
        public string ManagementCompany { get; set; }

        /// <summary>Gets or sets the nationality.</summary>
        public string Nationality { get; set; }

        /// <summary>Gets or sets the current playing position.</summary>
        [DisplayName("Playing Position")]
        public string PlayingPosition { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        [Display(Name = "I am")]
        [UIHint("Sex")]
        public Sex Sex { get; set; }

        /// <summary>Gets or sets the signed by.</summary>
        [DisplayName("Signed By")]
        public string SignedBy { get; set; }

        /// <summary>Gets or sets the sport.</summary>
        public string Sport { get; set; }

        /// <summary>
        ///     Gets or sets the weight.
        /// </summary>
        [Numeric]
        public string Weight { get; set; }

        #endregion
    }
}