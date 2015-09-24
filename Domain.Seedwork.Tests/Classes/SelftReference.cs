// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelftReference.cs" company="">
//   
// </copyright>
// <summary>
//   The self reference.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Domain.Seedwork.Tests.Classes
{
    using Phoenix.PhoenixApp.Domain.Seedwork;

    /// <summary>
    /// The self reference.
    /// </summary>
    internal class SelfReference : ValueObject<SelfReference>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfReference"/> class.
        /// </summary>
        public SelfReference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfReference"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public SelfReference(SelfReference value)
        {
            this.Value = value;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public SelfReference Value { get; set; }

        #endregion
    }
}