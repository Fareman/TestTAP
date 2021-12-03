namespace TestTAP.Services.Interfaces
{
    using TestTAP.Models;

    /// <summary>
    /// Сервис для работы с сотрудниками.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Получить всех сотрудников.
        /// </summary>
        /// <returns> Список сотрудников. </returns>
        Task<List<Person>> GetAllAsync();

        /// <summary>
        /// Получить конкретного сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns> Сотрудник по идентификатору. </returns>
        Task<Person> GetByIdAsync(long id);

        /// <summary>
        /// Добавить сотрудника.
        /// </summary>
        /// <param name="person"> Сотрудник. </param>
        /// <returns></returns>
        Task CreateAsync(Person person);

        /// <summary>
        /// Редактировать сотрудника.
        /// </summary>
        /// <param name="person"> Сотрудник. </param>
        /// <returns></returns>
        Task EditAsync(Person person);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника. </param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
