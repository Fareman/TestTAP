namespace TestTAP.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestTAP.Data;
    using TestTAP.Models;
    using TestTAP.Services.Interfaces;

    /// <inheritdoc cref="IPersonService">
    public class PersonService : IPersonService
    {
        /// <summary>
        /// Контекст БД.
        /// </summary>
        private readonly PersonContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"> Контекст БД. </param>
        public PersonService(PersonContext context)
        {
            _context = context;
        }

        /// <inheritdoc cref="IPersonService.GetAllAsync">
        public async Task<List<Person>> GetAllAsync()
        {
            var persons = await _context.Persons
                .Include(p => p.Skills)
                .AsNoTracking()
                .ToListAsync();
            return persons;
        }
        /// <inheritdoc cref="IPersonService.GetByIdAsync"> 
        public async Task<Person> GetByIdAsync(long id)
        {
            var person = await _context.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);
            return person;
        }

        /// <inheritdoc cref="IPersonService.CreateAsync"> 
        public async Task CreateAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc cref="IPersonService.EditAsync"> 
        public async Task EditAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc cref="IPersonService.DeleteAsync"> 
        public async Task DeleteAsync(long id)
        {
            var person = await _context.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
