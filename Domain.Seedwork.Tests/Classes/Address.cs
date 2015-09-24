// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="">
//   
// </copyright>
// <summary>
//   The address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Domain.Seedwork.Tests.Classes
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    /// The address.
    /// </summary>
    public class Address : ValueObject<Address>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="streetLine1">
        /// The street line 1.
        /// </param>
        /// <param name="streetLine2">
        /// The street line 2.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="zipCode">
        /// The zip code.
        /// </param>
        public Address(string streetLine1, string streetLine2, string city, string zipCode)
        {
            this.StreetLine1 = streetLine1;
            this.StreetLine2 = streetLine2;
            this.City = city;
            this.ZipCode = zipCode;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Gets the street line 1.
        /// </summary>
        public string StreetLine1 { get; private set; }

        /// <summary>
        /// Gets the street line 2.
        /// </summary>
        public string StreetLine2 { get; private set; }

        /// <summary>
        /// Gets the zip code.
        /// </summary>
        public string ZipCode { get; private set; }

        #endregion
    }
}