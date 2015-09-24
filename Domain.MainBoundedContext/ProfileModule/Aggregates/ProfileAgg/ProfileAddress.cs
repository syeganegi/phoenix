// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileAddress.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   Address  information for existing customer
//   For this Domain-Model, the Address is a Value-Object
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    ///     Address  information for existing customer
    ///     For this Domain-Model, the Address is a Value-Object
    /// </summary>
    public class ProfileAddress : ValueObject<ProfileAddress>
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ProfileAddress"/> class.</summary>
        /// <param name="city">The city.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="addressLine1">The address line1.</param>
        /// <param name="addressLine2">The address line2.</param>
        public ProfileAddress(string city, string zipCode, string addressLine1, string addressLine2)
        {
            this.City = city;
            this.ZipCode = zipCode;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
        }

        /// <summary>
        ///     Prevents a default instance of the <see cref="ProfileAddress" /> class from being created.
        /// </summary>
        private ProfileAddress()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Get or set address line 1
        /// </summary>
        public string AddressLine1 { get; private set; }

        /// <summary>
        ///     Get or set address line 2
        /// </summary>
        public string AddressLine2 { get; private set; }

        #endregion

        #region Properties

        /// For this Domain-Model, the Address is a Value-Object
        /// 'sets' are private as Value-Objects must be immutable, 
        /// so the only way to set properties is using the constructor
        /// <summary>
        ///     Get or set the city of this address
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        ///     Get or set the zip code
        /// </summary>
        public string ZipCode { get; private set; }

        #endregion

        // required for EF
    }
}