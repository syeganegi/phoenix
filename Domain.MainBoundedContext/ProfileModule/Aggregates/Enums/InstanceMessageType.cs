// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceMessageType.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The relationship status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums
{
    /// <summary>
    ///     The instance message type.
    /// </summary>
    public enum InstanceMessageType
    {
        /// <summary>
        ///     The unknown
        /// </summary>
        Unknown, 

        /// <summary>
        ///     The google.
        /// </summary>
        Google, 

        /// <summary>
        ///     The twitter.
        /// </summary>
        Twitter, 

        /// <summary>
        ///     The windows live.
        /// </summary>
        WindowsLive, 

        /// <summary>
        ///     The yahoo.
        /// </summary>
        Yahoo, 

        /// <summary>
        ///     The skype.
        /// </summary>
        Skype, 
    }
}