// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Phoenix Pty Ltd" file="GlobalSuppressions.cs">
//   Copyright Sportware
// </copyright>
// <summary>
//   GlobalSuppressions.cs
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile.#Phones")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile.#Phones")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile.#InstanceMessages"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile.#InstanceMessages"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile.#Emails")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile.#Emails")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces", Scope = "type", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg.Profile")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Agg", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg"
        )]