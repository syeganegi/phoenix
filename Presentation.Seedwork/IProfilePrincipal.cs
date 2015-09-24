namespace Phoenix.PhoenixApp.Presentation.Seedwork
{
    using System;

    public interface IProfilePrincipal
    {
        /// <summary>Gets or sets the first name.</summary>
        string FirstName { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        string FullName { get; set; }

        /// <summary>Gets or sets the id.</summary>
        Guid Id { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        string LastName { get; set; }
    }
}