// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelBinderHelper.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders
{
    using System.Web.Mvc;

    /// <summary>
    /// The model binder helper.
    /// </summary>
    public sealed class ModelBinderHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="bindingContext">
        /// The binding context.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="T?"/>.
        /// </returns>
        public static T? GetValue<T>(ModelBindingContext bindingContext, string key) where T : struct
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + "." + key);

            if (result == null && bindingContext.FallbackToEmptyPrefix)
            {
                result = bindingContext.ValueProvider.GetValue(key);
            }

            if (result == null)
            {
                return null;
            }

            return (T?)result.ConvertTo(typeof(T));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="bindingContext">
        /// The binding context.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="ValueProviderResult"/>.
        /// </returns>
        public static ValueProviderResult GetValue(ModelBindingContext bindingContext, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + "." + key);

            if (result == null && bindingContext.FallbackToEmptyPrefix)
            {
                result = bindingContext.ValueProvider.GetValue(key);
            }

            return result;
        }

        #endregion
    }
}