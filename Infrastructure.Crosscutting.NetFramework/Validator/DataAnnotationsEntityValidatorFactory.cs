﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataAnnotationsEntityValidatorFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Data Annotations based entity validator factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Validator
{
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Validator;

    /// <summary>
    /// Data Annotations based entity validator factory
    /// </summary>
    public class DataAnnotationsEntityValidatorFactory : IEntityValidatorFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Create a entity validator
        /// </summary>
        /// <returns>
        /// The <see cref="IEntityValidator"/>.
        /// </returns>
        public IEntityValidator Create()
        {
            return new DataAnnotationsEntityValidator();
        }

        #endregion
    }
}