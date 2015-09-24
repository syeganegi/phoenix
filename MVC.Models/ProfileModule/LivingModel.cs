// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LivingModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The living model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System.ComponentModel;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The living model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class LivingModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the current city.</summary>
        [DisplayName("Current City")]
        public string CurrentCity { get; set; }

        /// <summary>Gets or sets the hometown.</summary>
        [DisplayName("Hometown")]
        public string Hometown { get; set; }

        /// <summary>Gets or sets the nationality.</summary>
        public string Nationality { get; set; }

        #endregion
    }
}