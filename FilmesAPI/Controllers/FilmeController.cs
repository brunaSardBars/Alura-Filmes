﻿using AutoMapper;
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
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = obterFilmePorId(id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraDaConsulta = DateTime.Now;
                return Ok(filmeDto);
            }
            return NotFound();
                    
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = obterFilmePorId(id);

            if (filme != null)
            {
                filme = _mapper.Map(filmeDto, filme);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = obterFilmePorId(id);

            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        private Filme obterFilmePorId(int id)
        {
            return _context.Filmes.FirstOrDefault(f => f.Id == id);
        }
    }
}
