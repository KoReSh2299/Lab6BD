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
    /// Контроллер для управления данными об автомобилях.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить список всех автомобилей.
        /// </summary>
        /// <returns>Список автомобилей.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _mediator.Send(new GetCarsQuery());
            return Ok(cars);
        }

        /// <summary>
        /// Получить данные об автомобиле по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор автомобиля.</param>
        /// <returns>Данные об автомобиле.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _mediator.Send(new GetCarByIdQuery(id));
            if (car == null)
            {
                return NotFound(new { message = "Car not found" });
            }

            return Ok(car);
        }

        /// <summary>
        /// Создать новый автомобиль.
        /// </summary>
        /// <param name="carDto">Данные автомобиля.</param>
        /// <returns>Созданный автомобиль.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarForCreationDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(new CreateCarCommand(carDto));
            return Ok(carDto);
        }

        /// <summary>
        /// Обновить данные автомобиля.
        /// </summary>
        /// <param name="id">Идентификатор автомобиля.</param>
        /// <param name="carDto">Обновленные данные автомобиля.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarForUpdateDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            carDto.Id = id;
            var updatedCar = await _mediator.Send(new UpdateCarCommand(carDto));
            if (updatedCar == null)
            {
                return NotFound(new { message = "Не удалось обновить данные автомобиля" });
            }

            return NoContent();
        }

        /// <summary>
        /// Удалить автомобиль.
        /// </summary>
        /// <param name="id">Идентификатор автомобиля.</param>
        /// <returns>Результат операции.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _mediator.Send(new GetCarByIdQuery(id));
            if (car == null)
            {
                return NotFound(new { message = "Car not found" });
            }

            await _mediator.Send(new DeleteCarCommand(id));
            return NoContent();
        }
    }

}
