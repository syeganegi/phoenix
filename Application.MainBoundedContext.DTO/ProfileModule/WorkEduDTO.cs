// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkEduDTO.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The work and education DTO.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Application.MainBoundedContext.DTO.ProfileModule
{
    /// <summary>
    ///     The work and education DTO.
    /// </summary>
    public class WorkEduDTO : ProfileDTOBase
    {
        #region Public Properties

        /// <summary>Gets or sets the college university.</summary>
        public string CollegeUniversity { get; set; }

        /// <summary>
        ///     Gets or sets the job.
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        ///     Gets or sets the secondary school.
        /// </summary>
        public string SecondarySchool { get; set; }

        #endregion
    }
}