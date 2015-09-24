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
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount.#BankAccActivity"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg.Order.#OrderLines")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount.#BankActivity"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg.Picture.#RawPhoto")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg.Customer.#FullName")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Un", Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount.#UnLock()"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ISO", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg.Country.#CountryISOCode")
]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ISBN", Scope = "member"
        , Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg.Book.#ISBN")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ERP", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Services")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ERP", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ERP", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ERP", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ERP", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Agg", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Agg", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Agg", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Agg", 
        Scope = "namespace", Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Agg", 
        Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "UnLock", 
        Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount.#UnLock()"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Services.BankTransferService.#PerformTransfer(System.Decimal,Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount,Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Services.BankTransferService.#PerformTransfer(System.Decimal,Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount,Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg.Order.#CreateOrderLine(Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg.Product,System.Int32,System.Decimal,System.Decimal)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member"
        , 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Services.OrderingService.#IsCreditValidForOrder(Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg.Order)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Scope = "type", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg.IProductRepository")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Scope = "type", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg.IOrderRepository")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Scope = "type", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg.ICountryRepository")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Scope = "type", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.IBankAccountRepository"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope = "member", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg.Order.#GetOrderTotal()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Services")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Services")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", 
        Target = "Phoenix.PhoenixApp.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Withdrawed", 
        Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount.#CanBeWithdrawed(System.Decimal)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "iban", 
        Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccountSpecifications.#BankAccountIbanNumber(System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Iban", 
        Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccount.#Iban")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Iban", 
        Scope = "member", 
        Target =
            "Phoenix.PhoenixApp.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg.BankAccountSpecifications.#BankAccountIbanNumber(System.String)"
        )]