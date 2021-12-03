namespace TestTAP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TestTAP.Models;
    using TestTAP.Services.Interfaces;

    /// <summary>
    /// Контроллер для сотрудников.
    /// </summary>
    [Route("api/v1")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        /// <summary>
        /// Сервис сотрудников.
        /// </summary>
        private readonly IPersonService _personService;

        /// <summary>
        /// Сервис логирования.
        /// </summary>
        private readonly ILogger<PersonController> _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="personService"> Сервис сотрудников. </param>
        /// <param name="logger"> Сервис логирования. </param>
        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает массив объектов типа Person.
        /// </summary>
        /// <returns> Список сотрудников </returns>
        [HttpGet("persons")]
        public async Task<ActionResult<List<Person>>> PersonsAsync()
        {
            var persons = await _personService.GetAllAsync();
            _logger.LogInformation("Getting all the persons.");
            return persons;
        }

        /// <summary>
        /// Возвращает объект типа Person по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns> Сотрудника </returns>
        [HttpGet("person/{id}")]
        public async Task<ActionResult<Person>> PersonAsync(long id)
        {
            var person = await _personService.GetByIdAsync(id);

            return person == null ? NotFound() : Ok(person);
        }

        /// <summary>
        /// Добавляет сотрудника с набором скилов.
        /// </summary>
        /// <param name="person"> Данные сотрудника. </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPersonAsync(Person person)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Insert the correct values.");
                return BadRequest(ModelState);
            }
            await _personService.CreateAsync(person);
            return Ok();
        }

        /// <summary>
        /// Редактирует данные сотрудника и набор его скилов.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditPersonAsync(Person person)
        {
            if(person == null)
            {
                _logger.LogInformation("User tried to edit empty person.");
                return BadRequest(string.Empty);
            }
            await _personService.EditAsync(person);
            return Ok();
        }

        /// <summary>
        /// Удаляет сотрудника и набор его скилов.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns></returns>
        [HttpDelete("person/{id}")]
        public async Task<IActionResult> DeletePersonAsync(long id)
        {
            await _personService.DeleteAsync(id);
            return Ok();
        }
    }
}
