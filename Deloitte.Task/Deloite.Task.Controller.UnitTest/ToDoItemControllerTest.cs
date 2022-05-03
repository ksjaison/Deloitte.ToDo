using Xunit;
using Deloitte.Task.BusinessService.Abstractions;
using Moq;
using Deloitte.Task.Web.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Deloitte.Task.Web.Models;
using System.Linq;

namespace Deloite.ToDo.Controller.UnitTest
{
    public class ToDoItemControllerTest
    {
        private readonly IMapper _mapper;

        [Fact]
        public void Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var mockRepo = new Mock<ITaskDetailsProvider>();
            var controller = new ToDoItemController(mockRepo.Object, _mapper);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = controller.Create(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


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
