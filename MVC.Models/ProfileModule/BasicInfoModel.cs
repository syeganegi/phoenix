// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicInfoModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The basic info model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The basic info model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class BasicInfoModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the birthday.</summary>
        [Required]
        [UIHint("Birthday")]
        public Birthday Birthday { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        [DisplayName("Name")]
        public string FullName { get; set; }

        /// <summary>Gets or sets the height.</summary>
        public string Height { get; set; }

        /// <summary>Gets or sets the languages.</summary>
        public string Languages { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the political views.</summary>
        [DisplayName("Political Views")]
        public string PoliticalViews { get; set; }

        /// <summary>Gets or sets the religion.</summary>
        [DisplayName("Religion")]
        public string Religion { get; set; }

        /// <summary>Gets or sets the sex.</summary>
        [Display(Name = "I am")]
        [UIHint("Sex")]
        public Sex Sex { get; set; }

        /// <summary>Gets or sets the weight.</summary>
        public string Weight { get; set; }

        #endregion
    }
}