using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lupi.BusinessLogic;
using Lupi.WebApi.Controllers;
using System.Web.Http;
using Moq;
using Lupi.Data.Entities;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Net.Http;

namespace Lupi.WebApi.Tests
{
    [TestClass]
    public class BreedControllerTests
    {
        [TestMethod]
        public void GetAllBreedsOkTest()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var expectedBreeds = GetFakeBreeds();
            var mockBreedsBusinessLogic = new Mock<IBreedBusinessLogic>();
            mockBreedsBusinessLogic
                .Setup(bl => bl.Get())
                .Returns(expectedBreeds);

            var controller = new BreedController(mockBreedsBusinessLogic.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Breed>>;
            mockBreedsBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedBreeds, contentResult.Content);
        }

        [TestMethod]
        public void GetAllBreedsErrorNotFoundTest()
        {
            //Arrange
            List<Breed> expectedBreeds = null;

            var mockBreedsBusinessLogic = new Mock<IBreedBusinessLogic>();
            mockBreedsBusinessLogic
                .Setup(bl => bl.Get())
                .Returns(expectedBreeds);

            var controller = new BreedController(mockBreedsBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            mockBreedsBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }

        //Función auxiliar
        private IEnumerable<Breed> GetFakeBreeds()
        {
            return new List<Breed>
            {
                new Breed
                {
                    Id = new Guid("e5020d0b-6fce-4b9f-a492-746c6c8a1bfa"),
                    Name = "Pug",
                    HairType  = "short fur",
                    HairColors = new List<string>
                    {
                        "blonde"
                    }
                },
                new Breed
                {
                    Id = new Guid("6b718186-fa8c-4e14-9af8-2601e153db71"),
                    Name = "Golden Retriever",
                    HairType  = "hairy fur",
                    HairColors = new List<string>
                    {
                        "blonde"
                    }
                }
            };
        }


        [TestMethod]
        public void CreateNewBreedTest()
        {
            //Arrange
            var fakeBreed = GetAFakeBreed();

            var mockBreedsBusinessLogic = new Mock<IBreedBusinessLogic>();
            mockBreedsBusinessLogic
                .Setup(bl => bl.Add(fakeBreed))
                .Returns(fakeBreed.Id);

            var controller = new BreedController(mockBreedsBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(fakeBreed);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Breed>;

            //Assert
            mockBreedsBusinessLogic.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(fakeBreed.Id, createdResult.RouteValues["id"]);
            Assert.AreEqual(fakeBreed, createdResult.Content);
        }

        [TestMethod]
        public void CreateNullBreedErrorTest()
        {
            //Arrange
            Breed fakeBreed = null;

            var mockBreedsBusinessLogic = new Mock<IBreedBusinessLogic>();
            mockBreedsBusinessLogic
                .Setup(bl => bl.Add(fakeBreed))
                .Throws(new ArgumentNullException());

            var controller = new BreedController(mockBreedsBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(fakeBreed);

            //Assert
            mockBreedsBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
        }

        private Breed GetAFakeBreed()
        {
            return new Breed
            {
                Id = new Guid("e5020d0b-6fce-4b9f-a492-746c6c8a1bfa"),
                Name = "Pug",
                HairType = "short fur",
                HairColors = new List<string>
                    {
                        "blonde"
                    }
            };
        }


        [TestMethod]
        public void DeleteBreedOkTest()
        {
            //Arrange

            Guid fakeGuid = Guid.NewGuid();

            var mockBreedsBusinessLogic = new Mock<IBreedBusinessLogic>();
            mockBreedsBusinessLogic
                .Setup(bl => bl.Delete(It.IsAny<Guid>()))
                .Returns(It.IsAny<bool>());

            var controller = new BreedController(mockBreedsBusinessLogic.Object);
            // Configuramos la Request (dado que estamos utilziando HttpResponseMessage)
            // Y usando el objeto Request adentro.
            ConfigureHttpRequest(controller);

            //Act
            HttpResponseMessage obtainedResult = controller.Delete(fakeGuid);

            //Assert
            mockBreedsBusinessLogic.VerifyAll();
            Assert.IsNotNull(obtainedResult);
        }

        private void ConfigureHttpRequest(BreedController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
