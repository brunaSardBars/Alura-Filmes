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
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }
        
        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaSessoes()
        {
            List<ReadSessaoDto> sessoes = _sessaoService.RecuperaSessoes();

            if (sessoes.Any())
                return Ok(sessoes);
            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperaSessaoPorId(id);
            
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
                    
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result resultado = _sessaoService.AtualizaSessao(id, sessaoDto);
            
            if (resultado.IsFailed)
                return NoContent();
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Result resultado = _sessaoService.DeletaSessao(id);

            if (resultado.IsFailed)
                return NoContent();
            return NotFound();
        }
    }
}
