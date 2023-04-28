using FicticiaSA.Entity;
using FicticiaSA.Models;
using FicticiaSA.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FicticiaSA.Repository
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly ApplicationDbContext dbContext;

        public PersonaRepositorio(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreatePersona(Persona persona)
        {
            await dbContext.Personas.AddAsync(persona);
        }
        public async Task<bool> PersonaIdentificacionExists(string dni)
        {
            return await dbContext.Personas.AnyAsync(u => u.Identificacion == dni);
        }
        public async Task<IList<Persona>> GetPersonas(bool EsActivo)
        {
            return await dbContext.Personas.Where(x => x.EsActivo == EsActivo).ToListAsync();
        }
        public async Task<Persona> GetPersona(int idPersona)
        {
            return await dbContext.Personas.AsNoTracking().FirstOrDefaultAsync(u => u.IdPersona.Equals(idPersona));
        }
        public Persona GestPersona(int idPersona)
        {
            return dbContext.Personas.FirstOrDefault(u => u.IdPersona.Equals(idPersona));
        }
        public void UpdatePersona(Persona persona)
        {
            dbContext.Update(persona);
        }

        public void DeletePersona(Persona persona)
        {
            dbContext.Remove(persona);
        }
        public async Task<bool> PersonaUpdateExists(int IdPersona, string documento)
        {
            return await dbContext.Personas.AnyAsync(u => u.Identificacion == documento && u.IdPersona != IdPersona);
        }
    }
}
