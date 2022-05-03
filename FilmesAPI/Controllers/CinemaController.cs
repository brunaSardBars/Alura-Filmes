using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        
        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto createDto = _cinemaService.AdicionaCinema(cinemaDto);            
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = createDto.Id }, createDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> cinemas = _cinemaService.RecuperaCinemas(nomeDoFilme);
            
            if(cinemas.Any())
                return Ok(cinemas);
            return NotFound();

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            ReadCinemaDto cinemaDto = _cinemaService.RecuperaCinemaPorId(id);
           
            if (cinemaDto != null)
            {               
                return Ok(cinemaDto);
            }
            return NotFound();
                    
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinema(id, cinemaDto);
            
            if (resultado.IsFailed)
                return NoContent();            
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);           

            if (resultado.IsFailed)            
                return NoContent();           
            return NotFound();
        }

    }
}
