namespace TestTAP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TestTAP.Dtos;
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
        /// Возвращает список всех DTO сотрудников.
        /// </summary>
        /// <returns> Список сотрудников. </returns>
        [HttpGet("persons")]
        public async Task<ActionResult<List<PersonDto>>> PersonsAsync()
        {
            try
            {
                var personDtos = await _personService.GetAllAsync();
                return personDtos;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Возвращает объект типа PersonDTO по идентификатору.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns> Сотрудник. </returns>
        [HttpGet("person/{id}")]
        public async Task<ActionResult<PersonDto>> PersonAsync(long id)
        {
            try
            {
                var personDto = await _personService.GetByIdAsync(id);
                return Ok(personDto);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Добавляет сотрудника с набором скилов.
        /// </summary>
        /// <param name="personDto"> DTO сотрудника. </param>
        /// <returns></returns>
        [HttpPost("person")]
        public async Task<ActionResult> AddPersonAsync(PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Insert the correct values.");
                return BadRequest(ModelState);
            }
            await _personService.CreateAsync(personDto);
            return Ok();
        }

        /// <summary>
        /// Редактирует данные сотрудника и набор его скилов.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <param name="personDto"> Новые данные сотрудника. </param>
        /// <returns></returns>
        [HttpPut("person/{id}")]
        public async Task<IActionResult> EditPersonAsync(long id, PersonDto personDto)
        {
            if(personDto == null)
            {
                _logger.LogInformation("User tried to create an empty person.");
                return BadRequest();
            }
            try
            {
                await _personService.EditAsync(id, personDto);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Удаляет сотрудника и набор его скилов.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns></returns>
        [HttpDelete("person/{id}")]
        public async Task<IActionResult> DeletePersonAsync(long id)
        {
            try
            {
                await _personService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
