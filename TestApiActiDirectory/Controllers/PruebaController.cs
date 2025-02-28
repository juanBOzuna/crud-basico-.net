
using Microsoft.AspNetCore.Mvc;
using TestApiActiDirectory.Data;
using TestApiActiDirectory.Data.PruebaModels;
using TestApiActiDirectory.Services;

namespace TestApiActiDirectory.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PruebaController: ControllerBase
    {
    public readonly PersonaService _service;

       public PruebaController(PersonaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Persona>> index()
        {
            return await _service.index();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> FindOne (int id)

        {
            var persona = await _service.FindOne(id);

            if (persona is null)
                return NotFound();
            return persona;
        }

        [HttpPost] 
        public async Task<IActionResult> create(Persona persona)
        {
            var newPersona = await _service.create(persona);

            return  CreatedAtAction(nameof(FindOne), new { id = newPersona.Id }, newPersona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Persona persona)
        {
            if (id != persona.Id)
                return NotFound();
            var existingPersona =await  _service.FindOne(id);
            if (existingPersona is null)
                return NotFound();

           await _service.Update(persona);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var existingPersona = await _service.FindOne(id);
            if (existingPersona is null)
                return NotFound();

           await  _service.delete(id);

            return Ok();
        }
    }
}
