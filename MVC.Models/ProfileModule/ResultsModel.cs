// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultsModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The about model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The about model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class ResultsModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the about.</summary>
        public string Results { get; set; }

        #endregion
    }
}