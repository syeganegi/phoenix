// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipStatus.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The relationship status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums
{
    /// <summary>
    ///     The relationship status.
    /// </summary>
    public enum RelationshipStatus
    {
        /// <summary>
        ///     The unknown
        /// </summary>
        Unknown, 

        /// <summary>
        ///     The single.
        /// </summary>
        Single, 

        /// <summary>
        ///     The in relationship.
        /// </summary>
        InRelationship, 

        /// <summary>
        ///     The engaged.
        /// </summary>
        Engaged, 

        /// <summary>
        ///     The married.
        /// </summary>
        Married, 

        /// <summary>
        ///     The complicated.
        /// </summary>
        Complicated, 

        /// <summary>
        ///     The open relationship.
        /// </summary>
        OpenRelationship, 

        /// <summary>
        ///     The widowed.
        /// </summary>
        Widowed, 

        /// <summary>
        ///     The separated.
        /// </summary>
        Separated, 

        /// <summary>
        ///     The divorced.
        /// </summary>
        Divorced
    }
}