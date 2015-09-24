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
    SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.IContainer.#Register`2()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.IContainer.#Register`2(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface", Scope = "type", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters.Configuration.RegisterTypesMapConfigurationElementCollection"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface", Scope = "type", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.Configuration.ContainerConfigurationElementCollection")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1012:AbstractTypesShouldNotHaveConstructors", Scope = "type", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters.RegisterTypesMap")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1012:AbstractTypesShouldNotHaveConstructors", Scope = "type", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.ContainerConfiguration")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters.TypeMapConfigurationBase`2.#GetDescriptor()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters.TypeMapConfigurationBase`2.#BeforeMap(!0&)")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters.TypeMapConfigurationBase`2.#AfterMap(!1&,System.Object[])"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.CrosscuttingConfigurationSection.#Adapters")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters.Configuration.RegisterTypesMapConfigurationElement.#Type"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.Configuration.ContainerConfigurationElement.#Type")
]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters.TypeMapConfigurationBase`2.#GetDescriptor()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.Impl.Unity.UnityApplicationBlockContainer.#Register`2(System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.Impl.Unity.UnityApplicationBlockContainer.#Register`2()"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.Impl.Unity")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.CrosscuttingConfigurationSection.#Containers")]
[assembly:
    SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.Impl.Unity.UnityApplicationBlockContainer.#CreateContainersHierarchy()"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.IoCFactory.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Impl", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.IoC.Impl.Unity")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting", 
        Scope = "type", Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.CrosscuttingConfigurationSection")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapters")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Crosscutting")
]