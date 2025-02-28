using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiActiDirectory.Data;
using TestApiActiDirectory.Data.PruebaModels;

namespace TestApiActiDirectory.Services
{
    public class PersonaService
    {
        public readonly PruebaContext _context;

        public PersonaService(PruebaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> index()
        {
            return await _context.Personas.ToListAsync();

        }

        public async Task<Persona?> FindOne(int id)

        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<Persona> create(Persona persona)
        {
            _context.Personas.Add(persona);
           await  _context.SaveChangesAsync();

            return persona;
        }
        public async Task Update( Persona persona)
        {
            var existingPersona = FindOne(persona.Id);
            if (existingPersona is not null)
              
            existingPersona.Result.Nombre = persona.Nombre;
            existingPersona.Result.Edad = persona.Edad;
            existingPersona.Result.Correo = persona.Correo;

            await _context.SaveChangesAsync();
        }

        public async Task delete(int id)
        {
            var existingPersona = FindOne(id);
            if (existingPersona.Result is not null)
            _context.Personas.Remove(existingPersona.Result);
            await _context.SaveChangesAsync();
        }
    }
}
