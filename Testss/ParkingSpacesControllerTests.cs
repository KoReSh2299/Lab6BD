using FluentAssertions;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Commands;
using Kursach.Application.Requests.Queries;
using Lab6.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Testss
{
    public class ParkingSpacesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ParkingSpacesController _controller;

        public ParkingSpacesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ParkingSpacesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithListOfParkingSpaces()
        {
            // Arrange
            var parkingSpaces = new List<ParkingSpaceDto>
            {
                new ParkingSpaceDto { Id = 1, CarId = 22, IsPenalty = false },
                new ParkingSpaceDto { Id = 2, CarId = 24, IsPenalty = false }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetParkingSpacesQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(parkingSpaces);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(parkingSpaces);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkWithParkingSpace()
        {
            // Arrange
            var parkingSpace = new ParkingSpaceDto { Id = 1, CarId = 22, IsPenalty = false };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetParkingSpaceByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(parkingSpace);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(parkingSpace);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenParkingSpaceDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetParkingSpaceByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((ParkingSpaceDto)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            notFoundResult.Should().NotBeNull();
            notFoundResult!.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedParkingSpace()
        {
            // Arrange
            var parkingSpaceDto = new ParkingSpaceForCreationDto { IsPenalty = true, CarId = 25 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateParkingSpaceCommand>(), It.IsAny<CancellationToken>()))
                         .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(parkingSpaceDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().Be(parkingSpaceDto);
        }
    }

}
