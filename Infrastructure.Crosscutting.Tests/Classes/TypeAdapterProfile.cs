// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeAdapterProfile.cs" company="">
//   
// </copyright>
// <summary>
//   The type adapter profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Crosscutting.Tests.Classes
{
    using AutoMapper;

    /// <summary>
    /// The type adapter profile.
    /// </summary>
    internal class TypeAdapterProfile : Profile
    {
        #region Methods

        /// <summary>
        /// The configure.
        /// </summary>
        protected override void Configure()
        {
            IMappingExpression<Customer, CustomerDTO> map = Mapper.CreateMap<Customer, CustomerDTO>();
            map.ForMember(dto => dto.CustomerId, mc => mc.MapFrom(e => e.Id));
            map.ForMember(dto => dto.FullName, mc => mc.MapFrom(e => string.Format("{0},{1}", e.LastName, e.FirstName)));
        }

        #endregion
    }
}