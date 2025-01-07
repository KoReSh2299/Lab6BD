using FluentAssertions;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Commands;
using Kursach.Application.Requests.Queries;
using Lab6.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testss
{
    public class CarsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CarsController _controller;

        public CarsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CarsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithListOfCars()
        {
            // Arrange
            var cars = new List<CarDto>
        {
            new CarDto { Id = 1, Brand = "Toyota", Number = "ABC123", ClientId = 1 },
            new CarDto { Id = 2, Brand = "Honda", Number = "XYZ456", ClientId = 2 }
        };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCarsQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(cars);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(cars);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkWithCar()
        {
            // Arrange
            var car = new CarDto { Id = 1, Brand = "Toyota", Number = "ABC123", ClientId = 1 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCarByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(car);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(car);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenCarDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCarByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((CarDto)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            notFoundResult.Should().NotBeNull();
            notFoundResult!.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedCar()
        {
            // Arrange
            var carDto = new CarForCreationDto { Brand = "Toyota", Number = "ABC123", ClientId = 1 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()))
                         .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(carDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().Be(carDto);
        }

        [Fact]
        public async Task Update_ShouldReturnNoContent_WhenCarIsUpdated()
        {
            // Arrange
            var carDto = new CarForUpdateDto { Id = 1, Brand = "Toyota", Number = "XYZ789", ClientId = 1 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateCarCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(true);

            // Act
            var result = await _controller.Update(1, carDto);

            // Assert
            var noContentResult = result as NoContentResult;
            noContentResult.Should().NotBeNull();
            noContentResult!.StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFound_WhenCarDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCarByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((CarDto)null);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            notFoundResult.Should().NotBeNull();
            notFoundResult!.StatusCode.Should().Be(404);
        }
    }
}
