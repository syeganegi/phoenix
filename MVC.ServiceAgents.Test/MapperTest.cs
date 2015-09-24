using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVC.ServiceAgents.Test
{
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Adapter;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.NetFramework.Adapter;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Mappers;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Proxies.ProfileModule;
    using Phoenix.PhoenixApp.Presentation.Seedwork;

    [TestClass]
    public class MapperTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var typeAdapterFactory = new AutomapperTypeAdapterFactory();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
            AutoMapper.Mapper.Initialize(a => a.AddProfile<ModelProfile>());
        }

        //[TestMethod]
        //public void ProfileDTO_to_ProfileModel_AboutModelTest()
        //{
        //    // Arrange
        //    var dto = new ProfileDTO { About = "About me!" };

        //    // Action
        //    var model = dto.ConvertToModel();

        //    // Assert
        //    Assert.IsNotNull(model);
        //    Assert.IsNotNull(model.About);
        //    Assert.AreEqual(model.About.About, "About me!");
        //}

        //[TestMethod]
        //public void ProfileDTO_to_ProfileModel_BasicInfoModelTest()
        //{
        //    // Arrange
        //    var dto = new ProfileDTO { FirstName = "Joe", LastName = "Smith" };

        //    // Action
        //    var model = dto.ConvertToModel();

        //    // Assert
        //    Assert.IsNotNull(model);
        //    Assert.IsNotNull(model.BasicInfo);
        //    Assert.AreEqual(model.BasicInfo.FirstName, "Joe");
        //    Assert.AreEqual(model.BasicInfo.LastName, "Smith");
        //}

        [TestMethod]
        public void BasicInfoModel_Birthday_to_BasicInfoDTO_DateTime()
        {
            // Arrange
            var birthday = new DateTime(1975, 5, 7);
            var model = new BasicInfoModel { Birthday = new Birthday(birthday) };

            // Action
            var dto = model.ProjectedAs<BasicInfoDTO>();

            // Assert
            Assert.IsNotNull(dto);
            Assert.AreEqual(dto.Birthday, birthday);
        }

        [TestMethod]
        public void BasicInfoDTO_DateTime_to_BasicInfoModel_Birthday()
        {
            // Arrange
            var birthday = new DateTime(1975, 5, 7);
            var basicInfoDTO = new BasicInfoDTO { Birthday = birthday };

            // Action
            var model = basicInfoDTO.ConvertToModel();

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Birthday.ToDate(), birthday);
        }
    }
}
