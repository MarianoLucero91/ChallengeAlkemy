using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using ChallengeAlkemy.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Controllers
{
    [Authorize]
    [Route("api/movies")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;

        public PeliculaController (IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchPeliculaResponseDto>>> GetPeliculas ([FromQuery] SearchPeliculaRequestDto request)
        {
            var listaPeliculas = await _peliculaService.GetPeliculas(request);
            return Ok(listaPeliculas);
        }

        [HttpGet("{peliculaId}")]
        public async Task<ActionResult<PeliculaDto>> GetPelicula ([FromRoute] int peliculaId)
        {
            var pelicula = await _peliculaService.GetPelicula(peliculaId);
            return Ok(pelicula);
        }

        [HttpPut]
        public async Task<ActionResult<PeliculaDto>> AddPelicula ([FromBody] SavePeliculaDto model)
        {
            var pelicula = await _peliculaService.AddPelicula(model);
            return Ok(pelicula);
        }

        [HttpPatch]
        public ActionResult<Pelicula> UpdatePelicula ([FromBody] SavePeliculaDto model)
        {
            var peliculaUpdate =  _peliculaService.UpdatePelicula(model);
            return Ok(peliculaUpdate);
        }

        [HttpDelete("peliculaId")]
        public async Task<ActionResult<string>> DeletePelicula ([FromRoute] int peliculaId)
        {
            await _peliculaService.DeletePelicula(peliculaId);
            return Ok("La pelicula se borró exitosamente");
        }
    }
}
