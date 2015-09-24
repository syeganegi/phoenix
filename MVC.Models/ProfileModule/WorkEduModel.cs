// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkEduModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The work edu model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System.ComponentModel;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The work edu model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class WorkEduModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the college university.</summary>
        [DisplayName("College / University")]
        public string CollegeUniversity { get; set; }

        /// <summary>Gets or sets the job.</summary>
        public string Job { get; set; }

        /// <summary>Gets or sets the secondary school.</summary>
        [DisplayName("High School")]
        public string SecondarySchool { get; set; }

        #endregion
    }
}