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
    public class ClientsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ClientsController _controller;

        public ClientsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ClientsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithListOfClients()
        {
            // Arrange
            var clients = new List<ClientDto>
            {
                new ClientDto { Id = 1, Name = "Эдуард", Surname = "Гуринович", MiddleName = "Васильевич", IsRegularClient = true, Telephone = "37529386934"},
                new ClientDto { Id = 2, Name = "Василий", Surname = "Чопчиц", MiddleName = "Эдуардович", IsRegularClient = true, Telephone = "37529386934" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetClientsQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(clients);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(clients);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkWithClient()
        {
            // Arrange
            var client = new ClientDto { Id = 1, Name = "Эдуард", Surname = "Гуринович", MiddleName = "Васильевич", IsRegularClient = true, Telephone = "37529386934" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetClientByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(client);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(client);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenClientDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetClientByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((ClientDto)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            notFoundResult.Should().NotBeNull();
            notFoundResult!.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedClient()
        {
            // Arrange
            var clientDto = new ClientForCreationDto { Name = "Эдуард", Surname = "Гуринович", MiddleName = "Васильевич", IsRegularClient = true, Telephone = "37529386934" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateClientCommand>(), It.IsAny<CancellationToken>()))
                         .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(clientDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().Be(clientDto);
        }
    }
}
