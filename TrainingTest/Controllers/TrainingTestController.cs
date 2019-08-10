using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TrainingAPI.Controllers;
using TrainingAPI.Data;
using TrainingAPI.Models;
using TrainingAPI.Services;
using TrainingTest.EntityBuilder;
using Xunit;

namespace TrainingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingTestController : ControllerBase
    {

        [Fact]

        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            var testTraining = TrainingBuilder.GetTestTraining();
            var mock = new Mock<ITrainingRepository>();

            //Act
            mock.Setup(p => p.GetTraining(1)).ReturnsAsync(testTraining);
            var controller = new TrainingController(mock.Object);

            // Assert
            // act
            var result = controller.GetTraining(1);
            var response = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, response.StatusCode);

            Training trainingResult = (Training)response.Value;
            // assert
            Assert.Equal(1, trainingResult.Id);
        }


        [Fact]

        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var testTraining = TrainingBuilder.GetTestTraining();
            var mock = new Mock<ITrainingRepository>();

            //Act
            mock.Setup(p => p.GetTraining(1)).ReturnsAsync(testTraining);
            var controller = new TrainingController(mock.Object);


            // Assert
            // act
            var notFoundResult = controller.GetTraining(999);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void PostTraining_ValidModelReturnOkResult()
        {
            var item = TrainingBuilder.GetTestTraining();
            var mock = new Mock<ITrainingRepository>();

            //Act
            mock.Setup(p => p.Add(item)).ReturnsAsync(true);
            var controller = new TrainingController(mock.Object);

            var result =
                controller.PostTraining(item);

            Assert.NotNull(result);

            var response = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal(200, response.StatusCode);

        }


        [Fact]
        public void PostTraining_InValidModelBadRequestError()
        {
            var item = TrainingBuilder.GetTestTraining();
            var mock = new Mock<ITrainingRepository>();

            //Act
            mock.Setup(p => p.Add(item)).ReturnsAsync(true);
            var controller = new TrainingController(mock.Object);
            controller.ModelState.AddModelError("name", "name is required");
            var result =
                controller.PostTraining(item);

            Assert.NotNull(result);

            var response = Assert.IsType<BadRequestObjectResult>(result.Result);

            Assert.Equal(400, response.StatusCode);

        }
    }
}