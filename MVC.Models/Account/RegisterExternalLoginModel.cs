namespace Phoenix.PhoenixApp.Presentation.MVC.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Validations;

    /// <summary>
    /// The register external login model.
    /// </summary>
    public class RegisterExternalLoginModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the external login data.
        /// </summary>
        public string ExternalLoginData { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        [UsernameValidation]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

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
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl { get; set; }

        #endregion
    }
}