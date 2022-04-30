using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            return Ok(_context.Gerentes);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            Gerente gerente = ObterGerentePorId(id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();

        }
       

        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult AtualizaGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        //{
        //    Gerente gerente = obterGerentePorId(id);

        //    if (gerente != null)
        //    {
        //        gerente = _mapper.Map(gerenteDto, gerente);
        //        _context.SaveChanges();
        //        return NoContent();
        //    }
        //    return NotFound();

        //}

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Gerente gerente = ObterGerentePorId(id);

            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }

        private Gerente ObterGerentePorId(int id)
        {
            return _context.Gerentes.FirstOrDefault(f => f.Id == id);
        }
    }
}
