namespace Phoenix.PhoenixApp.Presentation.MVC.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Validations;

    /// <summary>
    /// The register model.
    /// </summary>
    public class RegisterModel
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Required]
        [Display(Name = "Username")]
        [UsernameValidation]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        [Required]
        [Display(Name = "Birthday")]
        [UIHint("Birthday")]
        public Birthday Birthday { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        [Display(Name = "I am")]
        [UIHint("Sex")]
        public Sex Sex { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [Display(Name = "Your Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[] PictureRawPhoto { get; set; }

        #endregion
    }
}