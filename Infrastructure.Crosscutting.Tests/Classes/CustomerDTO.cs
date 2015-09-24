// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDTO.cs" company="">
//   
// </copyright>
// <summary>
//   The customer dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Crosscutting.Tests.Classes
{
    /// <summary>
    /// The customer dto.
    /// </summary>
    internal class CustomerDTO
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }

        #endregion
    }
}