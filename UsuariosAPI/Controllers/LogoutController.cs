using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        public IActionResult DeslogarUsuario()
        {
            Result resultado = _logoutService.DeslogarUsuario();
            if (resultado.IsFailed)
                return Unauthorized(resultado.Errors);
            return Ok();
        }
    }
}
