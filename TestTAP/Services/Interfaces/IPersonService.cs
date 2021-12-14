namespace TestTAP.Services.Interfaces
{
    using TestTAP.Dtos;

    /// <summary>
    /// Сервис для работы с сотрудниками.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Получить DTO всех сотрудников.
        /// </summary>
        /// <returns> Список сотрудников. </returns>
        Task<List<PersonDto>> GetAllAsync();

        /// <summary>
        /// Получить DTO конкретного сотрудника.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns> Сотрудник по идентификатору. </returns>
        Task<PersonDto> GetByIdAsync(long id);

        /// <summary>
        /// Добавить сотрудника.
        /// </summary>
        /// <param name="personDto"> Данные нового сотрудника. </param>
        /// <returns></returns>
        Task CreateAsync(PersonDto personDto);

        /// <summary>
        /// Изменить данные сотрудника.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <param name="personDto"> Новые данные сотрудника. </param>
        /// <returns></returns>
        Task EditAsync(long id, PersonDto personDto);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
