// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Common.Helpers
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Web;

    using ImageResizer;

    using Phoenix.PhoenixApp.Presentation.MVC.Common.Resources;

    /// <summary>The picture helper.</summary>
    public sealed class PictureHelper
    {
        #region Public Methods and Operators

        /// <summary>The get default no image.</summary>
        /// <returns>
        ///     The <see cref="byte[]" />.
        /// </returns>
        public static byte[] GetDefaultNoImage()
        {
            return File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/Images/noimage.jpg"));
        }

        /// <summary>The get default profile image.</summary>
        /// <returns>
        ///     The <see cref="byte[]" />.
        /// </returns>
        public static byte[] GetDefaultProfileImage()
        {
            return File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/Images/profile.jpg"));
        }

        /// <summary>The resize picture.</summary>
        /// <param name="picture">The picture.</param>
        /// <param name="maxSize">The max size.</param>
        /// <returns>The <see cref="byte[]"/>.</returns>
        public static byte[] ResizePicture(byte[] picture, int maxSize = 240)
        {
            var outStream = new MemoryStream();
            try
            {
                var settings = new ResizeSettings { MaxWidth = maxSize, MaxHeight = maxSize, Format = "jpg" };

                ImageBuilder.Current.Build(picture, outStream, settings);
            }
            catch (Exception ex)
            {
                throw;
            }

            return outStream.ToArray();
        }

        /// <summary>The validate image.</summary>
        /// <param name="bytes">The bytes.</param>
        /// <exception cref="Exception"></exception>
        public static void ValidateImage(byte[] bytes)
        {
            // TODO: add minimum image size to the app config
            //const int MinWidthHeight = 180;
            Stream stream = new MemoryStream(bytes);
            using (Image img = Image.FromStream(stream))
            {
                bool formatValid = img.RawFormat.Equals(ImageFormat.Bmp) || img.RawFormat.Equals(ImageFormat.Gif)
                                    || img.RawFormat.Equals(ImageFormat.Jpeg)
                                    || img.RawFormat.Equals(ImageFormat.Png);
                if (!formatValid)
                {
                    throw new Exception(Messages.exception_ImageFormatInvalid);
                }

                //if (img.Width < MinWidthHeight || img.Height < MinWidthHeight)
                //{
                //    throw new Exception(Messages.exception_ImageTooSmall);
                //}
            }
        }

        /// <summary>The validate profile picture upload.</summary>
        /// <param name="postedFile">The posted file.</param>
        /// <exception cref="Exception"></exception>
        public static void ValidateProfilePictureUpload(HttpPostedFileBase postedFile)
        {
            // TODO: read maxFileSize from app config
            // max file size in KB
            const int MaxFileSize = 5120;

            // Is the file too big to upload?
            int fileSize = postedFile.ContentLength;
            if (fileSize > (MaxFileSize * 1024))
            {
                throw new Exception(string.Format(Messages.exception_FilesizeTooLarge, MaxFileSize));
            }

            // check that the file is of the permitted file type
            string fileExtension = Path.GetExtension(postedFile.FileName);

            if (fileExtension == null)
            {
                throw new Exception(string.Format(Messages.exception_FileInvalidExtension, MaxFileSize));
            }

            fileExtension = fileExtension.ToLower();
            var acceptedFileTypes = new[] { ".bmp", ".jpg", ".jpeg", ".gif", ".png" };

            // should we accept the file?
            if (!acceptedFileTypes.Any(t => t.Equals(fileExtension)))
            {
                throw new Exception(string.Format(Messages.exception_FileTypeIsNotPermitted, MaxFileSize));
            }
        }

        #endregion
    }
}