// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FacebookHelper.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.Seedwork
{
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// The facebook helper.
    /// </summary>
    public sealed class FacebookHelper
    {
        #region Constants

        /// <summary>
        /// The picture url.
        /// </summary>
        public const string PictureUrlFormat = "https://graph.facebook.com/{0}/picture?type=large";

        #endregion

        #region Methods

        /// <summary>
        /// The get profile picture.
        /// </summary>
        /// <param name="providerId">
        /// The provider id.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public static byte[] GetProfilePicture(string providerId)
        {
            if (string.IsNullOrEmpty(providerId))
            {
                return null;
            }

            byte[] result = null;
            var buffer = new byte[4096];

            var connectionString = string.Format(PictureUrlFormat, providerId);

            try
            {
                WebRequest wr = WebRequest.Create(connectionString);

                using (WebResponse response = wr.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            var count = 0;
                            do
                            {
                                count = responseStream.Read(buffer, 0, buffer.Length);
                                memoryStream.Write(buffer, 0, count);
                            }
                            while (count != 0);

                            result = memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        #endregion
    }
}