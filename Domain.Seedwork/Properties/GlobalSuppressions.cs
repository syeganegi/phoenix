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
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1.#op_True(Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1.#op_False(Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1.#op_LogicalNot(Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1.#op_BitwiseOr(Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>,Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1.#op_BitwiseAnd(Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>,Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "specification", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1.#op_False(Phoenix.PhoenixApp.Domain.Seedwork.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Get", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.Seedwork.IRepository`1.#Get(System.Guid)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix", MessageId = "T", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.IRepository`1.#GetPaged`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rebinder", 
        Scope = "type", Target = "Phoenix.PhoenixApp.Domain.Seedwork.Specification.ParameterRebinder")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.ExpressionBuilder.#Compose`1(System.Linq.Expressions.Expression`1<!!0>,System.Linq.Expressions.Expression`1<!!0>,System.Func`3<System.Linq.Expressions.Expression,System.Linq.Expressions.Expression,System.Linq.Expressions.Expression>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.ExpressionBuilder.#Compose`1(System.Linq.Expressions.Expression`1<!!0>,System.Linq.Expressions.Expression`1<!!0>,System.Func`3<System.Linq.Expressions.Expression,System.Linq.Expressions.Expression,System.Linq.Expressions.Expression>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.Seedwork.IRepository`1.#GetAll()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.ExpressionBuilder.#Compose`1(System.Linq.Expressions.Expression`1<!!0>,System.Linq.Expressions.Expression`1<!!0>,System.Func`3<System.Linq.Expressions.Expression,System.Linq.Expressions.Expression,System.Linq.Expressions.Expression>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.NotSpecification`1.#.ctor(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.Seedwork.Specification.ISpecification`1.#SatisfiedBy()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.IRepository`1.#GetPaged`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.IRepository`1.#GetFiltered(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.ExpressionBuilder.#Or`1(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.ExpressionBuilder.#And`1(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.Seedwork.Specification.DirectSpecification`1.#.ctor(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>)"
        )]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Seedwork")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Seedwork", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.Seedwork")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Seedwork", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.Seedwork.Specification")]