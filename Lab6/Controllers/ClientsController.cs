using AutoMapper;
using Kursach.Application.Dtos;
using Kursach.Application.Requests.Commands;
using Kursach.Application.Requests.Queries;
using Kursach.Domain.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab6.Controllers
{
    /// <summary>
    /// Контроллер для управления клиентами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить список всех клиентов.
        /// </summary>
        /// <returns>Список клиентов.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _mediator.Send(new GetClientsQuery());
            return Ok(items);
        }

        /// <summary>
        /// Получить данные о клиенте по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <returns>Данные о клиенте.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _mediator.Send(new GetClientByIdQuery(id));
            if (client == null)
            {
                return NotFound(new { message = "Client not found" });
            }

            return Ok(client);
        }

        /// <summary>
        /// Создать нового клиента.
        /// </summary>
        /// <param name="client">Данные клиента.</param>
        /// <returns>Созданный клиент.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientForCreationDto client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(new CreateClientCommand(client));
            return Ok(client);
        }

        /// <summary>
        /// Обновить данные клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <param name="client">Обновленные данные клиента.</param>
        /// <returns>Результат операции.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientForUpdateDto client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            client.Id = id;
            var updatedClient = await _mediator.Send(new UpdateClientCommand(client));
            if (updatedClient == null)
            {
                return NotFound(new { message = "Не удалось обновить данные клиента" });
            }

            return NoContent();
        }

        /// <summary>
        /// Удалить клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <returns>Результат операции.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _mediator.Send(new GetClientByIdQuery(id));
            if (client == null)
            {
                return NotFound(new { message = "Client not found" });
            }

            await _mediator.Send(new DeleteClientCommand(id));
            return NoContent();
        }
    }


}
