// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationServiceError.cs" company="">
//   
// </copyright>
// <summary>
//   Default ServiceError
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.DistributedServices.Seedwork.ErrorHandlers
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Default ServiceError
    /// </summary>
    [DataContract(Name = "ServiceError", Namespace = "Microsoft.Samples.DistributedServices.Core")]
    public class ApplicationServiceError
    {
        #region Public Properties

        /// <summary>
        /// Error message that flow to client services
        /// </summary>
        [DataMember(Name = "ErrorMessage")]
        public IEnumerable<string> ErrorMessages { get; set; }

        #endregion
    }
}