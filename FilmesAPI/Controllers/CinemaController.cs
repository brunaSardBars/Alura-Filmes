using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
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
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas()
        {
            return Ok(_context.Cinemas);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = obterCinemaPorId(id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);                
                return Ok(cinemaDto);
            }
            return NotFound();
                    
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = obterCinemaPorId(id);

            if (cinema != null)
            {
                cinema = _mapper.Map(cinemaDto, cinema);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = obterCinemaPorId(id);

            if (cinema != null)
            {
                _context.Remove(cinema);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        private Cinema obterCinemaPorId(int id)
        {
            return _context.Cinemas.FirstOrDefault(f => f.Id == id);
        }
    }
}
