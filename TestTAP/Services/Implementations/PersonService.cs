namespace TestTAP.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestTAP.Data;
    using TestTAP.Dtos;
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
        public async Task<List<PersonDto>> GetAllAsync()
        {
            var persons = await _context.Persons
                .Include(p => p.Skills)
                .AsNoTracking()
                .ToListAsync();
            var personsDto = persons.Select(p => new PersonDto
            {
                Id = p.Id,
                Name = p.Name,
                DisplayName = p.DisplayName,
                Skills = p.Skills.Select(s => new SkillDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Level = s.Level,
                    PersonId = s.Id,
                }).ToList()
            }).ToList();
            if (personsDto.Count == 0)
            {
                throw new Exception("Persons not found.");
            }
            return personsDto;
        }
        /// <inheritdoc cref="IPersonService.GetByIdAsync"> 
        public async Task<PersonDto> GetByIdAsync(long id)
        {
            var person = await _context.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);
            var personDto = new PersonDto
            {
                Id = id,
                Name = person.Name,
                DisplayName = person.DisplayName,
                Skills = person.Skills.Select(p => new SkillDto
                {
                    Id = id,
                    Name = p.Name,
                    Level = p.Level,
                    PersonId = id
                }).ToList()
            };
            if(personDto == null)
            {
                throw new ArgumentException($"The person with ID = {id} not found.");
            }
            return personDto;
        }

        /// <inheritdoc cref="IPersonService.CreateAsync"> 
        public async Task CreateAsync(PersonDto personDto)
        {
            var person = new Person
            {
                Name = personDto.Name,
                DisplayName = personDto.DisplayName,
                Skills = personDto.Skills.Select(s => new Skill
                {
                    Id = 0,
                    Name = s.Name,
                    Level = s.Level,
                    PersonId = 0
                }).ToList()
            };
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc cref="IPersonService.EditAsync"> 
        public async Task EditAsync(long id, PersonDto personDto)
        {
            var person = await _context.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);
            if(person == null)
            {
                throw new Exception($"The person with ID = {id} doesn't exist");
            }
            person.Name = personDto.Name;
            person.DisplayName = personDto.DisplayName;
            foreach (var skill in personDto.Skills)
            {
                var  personSkill = person.Skills.FirstOrDefault(s => s.Name == skill.Name);
                if (personSkill != null)
                {
                    personSkill.Level = skill.Level;
                    _context.Update(personSkill);
                }
                else
                {
                    personSkill = new Skill
                    {
                        Name = skill.Name,
                        Level = skill.Level,
                        PersonId = id
                    };
                    _context.Add(personSkill);
                }
            }
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc cref="IPersonService.DeleteAsync"> 
        public async Task DeleteAsync(long id)
        {
            var person = await _context.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(person == null)
            {
                throw new ArgumentException($"Wrong person ID: {id}");
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
