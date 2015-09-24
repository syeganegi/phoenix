namespace Phoenix.PhoenixApp.Presentation.MVC.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The user profile.
    /// </summary>
    [Table("UserProfile")]
    public class UserProfile
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [StringLength(256)]
        public string UserName { get; set; }

        public bool IsEnabled { get; set; }

        #endregion
    }
}