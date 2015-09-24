// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditController.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// <summary>
//   The profile controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.Web;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Client.Extensions;
    using Phoenix.PhoenixApp.Presentation.MVC.Common.Helpers;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule.Admin;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    using WebMatrix.WebData;

    /// <summary>The profile controller.</summary>
    [Authorize]
    public partial class EditController : BaseController
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EditController" /> class.
        ///     Initializes a new instance of the <see cref="ProfileController" /> class.
        /// </summary>
        public EditController()
            : this(new ProfileMvcService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EditController"/> class. Initializes a new instance of the<see cref="ProfileController"/>
        ///     class.</summary>
        /// <param name="profileService">The profile service.</param>
        public EditController(IProfileMvcService profileService)
            : base(profileService)
        {
        }

        #endregion

        // GET: /Profile/
        #region Public Methods and Operators

        /// <summary>The edit about.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateInput(false)]
        [HandleModelStateException]
        public virtual ActionResult About(AboutModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateAbout(model);
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.PartialView(MVCT.Edit.Views.About._View, model);
        }

        /// <summary>The achievements.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateInput(false)]
        [HandleModelStateException]
        public virtual ActionResult Achievements(AchievementsModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateAchievements(model);
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.PartialView(MVCT.Edit.Views.Achievements._View, model);
        }

        /// <summary>The edit about.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult BasicInfo()
        {
            BasicInfoModel model = this.ProfileService.GetBasicInfoModel(this.User.Identity.Name);
            return View(model);
        }

        /// <summary>The edit about.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult BasicInfo(BasicInfoModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateBasicInfo(model);

                    return this.RedirectToAction(MVCT.Edit.Index());
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return View(model);
        }

        /// <summary>The edit contact.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult Contact()
        {
            ContactModel model = this.ProfileService.GetContactModel(this.User.Identity.Name);
            return View(model);
        }

        /// <summary>The edit contact.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Contact(ContactModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateContact(model);

                    return this.RedirectToAction(MVCT.Edit.Index());
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return View(model);
        }

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public virtual ActionResult Delete(string id)
        {
            ProfileAdminModel model = this.ProfileService.GetProfileAdmin(id);
            return View(model);
        }

        /// <summary>The delete confirmed.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(string id)
        {
            bool resultOk = false;
            try
            {
                string username = this.Request.Form["UserName"];
                this.ProfileService.DeleteProfile(username);
                resultOk = true;
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, e.Message);
            }

            if (resultOk)
            {
                // logout
                WebSecurity.Logout();
                return this.RedirectToAction(MVCT.Account.Login());
            }

            ProfileAdminModel model = this.ProfileService.GetProfileAdmin(id);
            return this.View(model);
        }

        /// <summary>The index.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult Index()
        {
            ProfilePageModel pageModel = this.ProfileService.GetProfileModel(this.User.Identity.Name, false);
            this.ViewBag.Sport = this.GetSportList(pageModel.ProfileSummary.Sport);
            return View(pageModel);
        }

        /// <summary>The edit living.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Living(LivingModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateLiving(model);
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.PartialView(MVCT.Edit.Views.Resume._View, model);
        }

        /// <summary>The edit picture.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [HttpPost]
        [HandleModelStateException]
        public virtual ActionResult Picture()
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    if (this.Request.Files.Count > 0)
                    {
                        HttpPostedFileBase file = this.Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            PictureHelper.ValidateProfilePictureUpload(file);
                            byte[] picture = ReadFully(file.InputStream);
                            PictureHelper.ValidateImage(picture);
                            byte[] rawPhoto = PictureHelper.ResizePicture(picture);
                            this.ProfileService.UpdateProfilePicture(
                                new ProfilePictureModel { RawPhoto = rawPhoto, UserName = this.User.Identity.Name });
                        }
                    }
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.RedirectToAction(MVCT.Edit.Index());
        }

        /// <summary>The profile summary.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [HandleModelStateException]
        public virtual ActionResult ProfileSummary(ProfileSummaryModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateProfileSummary(model);
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.PartialView(MVCT.Edit.Views.Profile._View, model);
        }

        /// <summary>The results.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateInput(false)]
        [HandleModelStateException]
        public virtual ActionResult Results(ResultsModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateResults(model);
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.PartialView(MVCT.Edit.Views.Results._View, model);
        }

        /// <summary>The resume.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateInput(false)]
        [HandleModelStateException]
        public virtual ActionResult Resume(ResumeModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateResume(model);
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.PartialView(MVCT.Edit.Views.Resume._View, model);
        }

        /// <summary>The edit sport.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult Sport()
        {
            SportModel model = this.ProfileService.GetSportModel(this.User.Identity.Name);
            return View(model);
        }

        /// <summary>The edit sport.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult Sport(SportModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateSport(model);

                    return this.RedirectToAction(MVCT.Edit.Index());
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return View(model);
        }

        /// <summary>The edit workEdu.</summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public virtual ActionResult WorkEdu()
        {
            WorkEduModel model = this.ProfileService.GetWorkEduModel(this.User.Identity.Name);
            return View(model);
        }

        /// <summary>The edit workEdu.</summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public virtual ActionResult WorkEdu(WorkEduModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.ProfileService.UpdateWorkEdu(model);

                    return this.RedirectToAction(MVCT.Edit.Index());
                }
                catch (FaultException<ServiceError> e)
                {
                    this.ModelState.AddRangeModelError(e.Detail.ErrorMessage);
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return View(model);
        }

        #endregion

        #region Methods

        /// <summary>The read fully.</summary>
        /// <param name="input">The input.</param>
        /// <returns>The <see cref="byte[]"/>.</returns>
        private static byte[] ReadFully(Stream input)
        {
            var buffer = new byte[input.Length];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        /// <summary>The get sport list.</summary>
        /// <param name="sport">The sport.</param>
        /// <returns>The <see cref="SelectList"/>.</returns>
        private SelectList GetSportList(string sport)
        {
            var sports = new[]
                             {
                                 "Association Football (Soccer)", "Air Sports", "American Football (Gridiron)", "Archery", 
                                 "Athletics", "Athletics", "Australian Rules Football", "Auto Racing", "Bandy", "Baseball"
                                 , "Basketball", "Basque Pelota", "Billiard Sports", "Body Building", "Boules", "Bowling", 
                                 "Boxing", "Bridge", "Canoe/Kayak", "Chess", "Cricket", "Curling", "Cycling", "Dance", 
                                 "Darts", "Diving", "Fencing", "Floorball", "Futsal", "Golf", "Gymnastics", "Hockey", 
                                 "Horse Racing", "Ice hockey", "Ice Skating", "Korfball", "Lacrosse", "Martial Arts", 
                                 "Mixed Martial Arts", "Modern Pentathlon", "Motorcycle Racing", "Mountaineering", 
                                 "Netball", "Orienteering", "Poker", "Polo", "Powerboating", "Racquetball", "Rodeo", 
                                 "Roller Sports", "Rowing", "Rugby League", "Rugby Union", "Sailing", "Shooting", 
                                 "Ski Jumping", "Skiing", "Sled Racing", "Snowboarding", "Softball", "Sport Climbing", 
                                 "Squash", "Surfing", "Swimming", "Syncronized Swimming", "Table Tennis", "Team handball", 
                                 "Tennis", "Triathlon", "Tug of war", "Ultimate Disc", "Underwater Sports", "Video Gaming"
                                 , "Volleyball", "Water Polo", "Water Skiing", "Weightlifting", "Wrestling"
                             };
            return new SelectList(sports, sport);
        }

        #endregion
    }
}