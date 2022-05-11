using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public CadastroController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario([FromBody] CreateUsuarioDto createDto)
        {
            ReadUsuarioDto readDto = _usuarioService.CadastraUsuario(createDto);
            return CreatedAtAction(nameof(RecuperaUsuarioPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaUsuarioPorId([FromQuery] int id)
        {
            ReadUsuarioDto readDto = _usuarioService.RecuperaEnderecoPorId(id);

            if (readDto != null)
                return Ok(readDto);

            return NotFound();
        }
    }
}
