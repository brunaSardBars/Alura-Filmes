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
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet]
        public IActionResult RecuperaSessoes()
        {
            return Ok(_context.Sessoes);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            Sessao sessao = obterSessaoPorId(id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);                
                return Ok(sessaoDto);
            }
            return NotFound();
                    
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = obterSessaoPorId(id);

            if (sessao != null)
            {
                sessao = _mapper.Map(sessaoDto, sessao);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Sessao sessao = obterSessaoPorId(id);

            if (sessao != null)
            {
                _context.Remove(sessao);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        private Sessao obterSessaoPorId(int id)
        {
            return _context.Sessoes.FirstOrDefault(f => f.Id == id);
        }
    }
}
