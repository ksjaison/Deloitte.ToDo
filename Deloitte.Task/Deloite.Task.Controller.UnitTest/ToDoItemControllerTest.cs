namespace Deloite.ToDo.Controller.UnitTest
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Deloitte.Task.BusinessService.Abstractions;
    using Deloitte.Task.Web.Controllers;
    using Deloitte.Task.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    /// <summary>
    /// This is unit test class for controller.
    /// </summary>
    public class ToDoItemControllerTest
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Bad request unit test.
        /// </summary>
        [Fact]
        public void Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            var mockRepo = new Mock<ITaskDetailsProvider>();
            var controller = new ToDoItemController(mockRepo.Object, _mapper);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = controller.Create(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Task List get method.
        /// </summary>
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfTasks()
        {
            // Arrange
            var mockRepo = new Mock<ITaskDetailsProvider>();
            mockRepo.Setup(repo => repo.GetTaskDetails());
            var controller = new ToDoItemController(mockRepo.Object,_mapper);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ToDoItemViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}
