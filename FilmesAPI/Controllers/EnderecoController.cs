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
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            return Ok(_context.Enderecos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = obterEnderecoPorId(id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);                
                return Ok(enderecoDto);
            }
            return NotFound();
                    
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = obterEnderecoPorId(id);

            if (endereco != null)
            {
                endereco = _mapper.Map(enderecoDto, endereco);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = obterEnderecoPorId(id);

            if (endereco != null)
            {
                _context.Remove(endereco);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        private Endereco obterEnderecoPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(f => f.Id == id);
        }
    }
}
