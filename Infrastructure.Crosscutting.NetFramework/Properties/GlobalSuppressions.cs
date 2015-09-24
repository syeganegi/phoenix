// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="GlobalSuppressions.cs">
//   
// </copyright>
// <summary>
//   GlobalSuppressions.cs
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting")
]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging.TraceSourceLog.#LogError(System.String,System.Exception,System.Object[])"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Logging")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator.DataAnnotationsEntityValidator.#SetValidatableObjectErrors`1(!!0,System.Collections.Generic.List`1<System.String>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator.DataAnnotationsEntityValidator.#SetValidationAttributeErrors`1(!!0,System.Collections.Generic.List`1<System.String>)"
        )]