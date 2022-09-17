using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Controllers
{
    [Authorize]
    [Route("api/characters")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeService _personajeService;

        public PersonajeController(IPersonajeService personajeService)
        {
            _personajeService = personajeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchPersonajeResponseDto>>> GetPersonajes([FromQuery]SearchPersonajeRequestDto request)
        {
            var listaPersonajes = await _personajeService.GetPersonajes(request);

            return Ok(listaPersonajes);
        }

        [HttpGet("{personajeId}")]
        public async Task<ActionResult<PersonajeDto>> GetPersonaje([FromRoute] int personajeId)
        {
            var detallePersonaje = await _personajeService.GetPersonaje(personajeId);

            if (detallePersonaje == null)
            {
                return NotFound("No se encontro ningun personaje con este ID");
            }

            return Ok(detallePersonaje);
        }

        [HttpPost]
        public async Task<ActionResult<PersonajeDto>> AddPersonaje([FromBody]SavePersonajeDto model)
        {
            var character = await _personajeService.AddPersonaje(model);
            return Ok(character);
        }

        [HttpDelete("{personajeId}")]
        public async Task<ActionResult<string>> DeletePersonaje([FromRoute]int personajeId)
        {
            await _personajeService.DeletePersonaje(personajeId);
            return Ok("Se borro el personaje correctamente");
        }

        [HttpPatch]
        public async Task<ActionResult<Personaje>> UpdatePersonaje([FromBody]SavePersonajeDto personajeUpdateRequest)
        {
            var result = await _personajeService.UpdatePersonaje(personajeUpdateRequest);
            return Ok(result);
        }
    }
}
