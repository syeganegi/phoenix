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
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Data.Seedwork.IQueryableExtensions.#Include`2(System.Data.Entity.IDbSet`1<!!0>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,!!1>>)"
        )]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Seedwork")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Seedwork", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Infrastructure.Data.Seedwork")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix", MessageId = "T", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Data.Seedwork.IQueryableExtensions.#OfType`2(System.Linq.IQueryable`1<!!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Data.Seedwork.Repository`1.#AllMatching(Phoenix.PhoenixApp.Domain.Seedwork.Specification.ISpecification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Data.Seedwork.Repository`1.#GetPaged`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix", MessageId = "T", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Data.Seedwork.Repository`1.#GetPaged`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]