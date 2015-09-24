// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainBCUnitOfWorkInitializer.cs" company="">
//   
// </copyright>
// <summary>
//   The default initializer for testing this unit of work. Yoy can
//   learn more about initializers in
//   http://msdn.microsoft.com/en-us/library/gg696323(v=VS.103).aspx
//   <remarks>
//   In this initialize data the Guid is not sequential Guid but
//   in your code you need use sequential guid to avoid index fragmentation
//   </remarks>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Data.MainBoundedContext.Tests.Initializers
{
    using System;
    using System.Data.Entity;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.Enums;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.FriendshipAgg;
    using Phoenix.PhoenixApp.Domain.MainBoundedContext.ProfileModule.Aggregates.ProfileAgg;
    using Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.UnitOfWork;

    /// <summary>
    /// The default initializer for testing this unit of work. Yoy can
    /// learn more about initializers in 
    /// http://msdn.microsoft.com/en-us/library/gg696323(v=VS.103).aspx
    /// <remarks>
    /// In this initialize data the Guid is not sequential Guid but 
    /// in your code you need use sequential guid to avoid index fragmentation
    /// </remarks>
    /// </summary>
    public class MainBCUnitOfWorkInitializer : DropCreateDatabaseAlways<MainBCUnitOfWork>
    {
        #region Methods

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        protected override void Seed(MainBCUnitOfWork unitOfWork)
        {
            /*
             * Profile agg
             */
            Profile profile1 = ProfileFactory.CreateProfile(
                "username1", "Sasan", "Yeganegi", "s.yeganegi@gmail.com", Gender.Male, new DateTime(1975, 5, 7));
            profile1.AddInstanceMessage("syg66", InstanceMessageType.Yahoo);
            profile1.AddInstanceMessage("s.yeganegi", InstanceMessageType.Skype);
            profile1.MobilePhone = "+61410811721";
            profile1.HomePhone = "+6190450570";
            profile1.WorkPhone = "+6189679012";
            profile1.Address = new ProfileAddress("Sydney", "2077", "408/25-31 Orara st", "WAITARA");
            var id1 = new Guid("d7db612b-59c3-cbd8-1243-08cf857c45e2");
            profile1.ChangeCurrentIdentity(new Guid("d7db612b-59c3-cbd8-1243-08cf857c45e2"));
            Image i = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sasan.jpg"));
            var ms = new MemoryStream();
            i.Save(ms, ImageFormat.Jpeg);
            var pic = new ProfilePicture { RawPhoto = ms.ToArray() };
            pic.ChangeCurrentIdentity(new Guid("d7db612b-59c3-cbd8-1243-08cf857c45e2"));
            profile1.ChangePicture(pic);

            Profile profile2 = ProfileFactory.CreateProfile(
                "username2", "John", "Smith", "j.smith@outlook.com", Gender.Female, new DateTime(1990, 12, 3));
            profile2.AddInstanceMessage("jsmithgoogle", InstanceMessageType.Google);
            profile2.AddInstanceMessage("jsmithlive", InstanceMessageType.WindowsLive);
            profile2.MobilePhone = "+61433600512";
            profile2.Address = new ProfileAddress("city", "zipCode", "addressLine1", "addressLine2");
            profile2.ChangeCurrentIdentity(new Guid("6e1b40eb-64f4-c275-8787-08cf857c45e2"));

            // Act
            unitOfWork.Profiles.Add(profile1);
            unitOfWork.Profiles.Add(profile2);
        }

        #endregion
    }
}