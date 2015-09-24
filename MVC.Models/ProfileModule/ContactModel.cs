// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactModel.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The contact model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule
{
    using System.ComponentModel;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;

    /// <summary>The contact model.</summary>
    [ModelBinder(typeof(ProfileModelBinder))]
    public class ContactModel : ProfileModelBase
    {
        #region Public Properties

        /// <summary>Gets or sets the address address line 1.</summary>
        [DisplayName("Address Line 1")]
        public string AddressAddressLine1 { get; set; }

        /// <summary>Gets or sets the address address line 2.</summary>
        [DisplayName("Address Line 2")]
        public string AddressAddressLine2 { get; set; }

        /// <summary>Gets or sets the address city.</summary>
        [DisplayName("City / Suburb")]
        public string AddressCity { get; set; }

        /// <summary>Gets or sets the address zip code.</summary>
        [DisplayName("Postcode")]
        public string AddressZipCode { get; set; }

        /// <summary>Gets or sets the email.</summary>
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>Gets or sets the home phone.</summary>
        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }

        /// <summary>Gets or sets the mobile phone.</summary>
        [DisplayName("Mobile Phone")]
        public string MobilePhone { get; set; }

        /// <summary>Gets or sets the website.</summary>
        [DisplayName("Website")]
        public string Website { get; set; }

        /// <summary>Gets or sets the work phone.</summary>
        [DisplayName("Work Phone")]
        public string WorkPhone { get; set; }

        #endregion
    }

    /*
    /// <summary>The phone.</summary>
    public class Phone
    {
        #region Public Properties

        /// <summary>Gets or sets the area code.</summary>
        public string AreaCode { get; set; }

        /// <summary>Gets the full number.</summary>
        public string FullNumber
        {
            get
            {
                return string.Format("{0} {1}", this.AreaCode, this.Number);
            }
        }

        /// <summary>Gets or sets a value indicating whether is default.</summary>
        public bool IsDefault { get; set; }

        /// <summary>Gets or sets the number.</summary>
        public string Number { get; set; }

        /// <summary>Gets or sets the phone type.</summary>
        public PhoneType PhoneType { get; set; }

        #endregion
    }

    /// <summary>The phone type.</summary>
    public enum PhoneType
    {
        /// <summary>The mobile.</summary>
        Mobile, 

        /// <summary>The home.</summary>
        Home, 

        /// <summary>The work.</summary>
        Work, 

        /// <summary>The fax.</summary>
        Fax
    }

    /// <summary>The instance message.</summary>
    public class InstanceMessage
    {
        #region Public Properties

        /// <summary>Gets or sets the screen name.</summary>
        public string ScreenName { get; set; }

        #endregion
    }

    /// <summary>The email.</summary>
    public class Email
    {
        #region Public Properties

        /// <summary>Gets or sets the email address.</summary>
        public string EmailAddress { get; set; }

        /// <summary>Gets or sets a value indicating whether is default field.</summary>
        public bool IsDefaultField { get; set; }

        #endregion
    }
     * */
}