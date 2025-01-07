using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Commands;
using Kursach.Application.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab6.Controllers
{
    /// <summary>
    /// Контроллер для управления парковочными местами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpacesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingSpacesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить список всех парковочных мест.
        /// </summary>
        /// <returns>Список парковочных мест.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var parkingSpaces = await _mediator.Send(new GetParkingSpacesQuery());
            return Ok(parkingSpaces);
        }

        /// <summary>
        /// Получить данные о парковочном месте по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор парковочного места.</param>
        /// <returns>Данные о парковочном месте.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var parkingSpace = await _mediator.Send(new GetParkingSpaceByIdQuery(id));
            if (parkingSpace == null)
            {
                return NotFound(new { message = "Parking space not found" });
            }

            return Ok(parkingSpace);
        }

        /// <summary>
        /// Создать новое парковочное место.
        /// </summary>
        /// <param name="parkingSpaceDto">Данные нового парковочного места.</param>
        /// <returns>Созданное парковочное место.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ParkingSpaceForCreationDto parkingSpaceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(new CreateParkingSpaceCommand(parkingSpaceDto));
            return Ok(parkingSpaceDto);
        }

        /// <summary>
        /// Обновить данные парковочного места.
        /// </summary>
        /// <param name="id">Идентификатор парковочного места.</param>
        /// <param name="parkingSpaceDto">Обновленные данные парковочного места.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ParkingSpaceForUpdateDto parkingSpaceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            parkingSpaceDto.Id = id;
            var updatedParkingSpace = await _mediator.Send(new UpdateParkingSpaceCommand(parkingSpaceDto));
            if (updatedParkingSpace == null)
            {
                return NotFound(new { message = "Не удалось обновить данные парковочного места" });
            }

            return NoContent();
        }

        /// <summary>
        /// Удалить парковочное место.
        /// </summary>
        /// <param name="id">Идентификатор парковочного места.</param>
        /// <returns>Результат операции.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var parkingSpace = await _mediator.Send(new GetParkingSpaceByIdQuery(id));
            if (parkingSpace == null)
            {
                return NotFound(new { message = "Parking space not found" });
            }

            await _mediator.Send(new DeleteParkingSpaceCommand(id));
            return NoContent();
        }
    }


}
