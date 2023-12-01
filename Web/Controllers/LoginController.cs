using Core.Configuration;
using Core.Extensions;
using Core.Helpers;
using Core.Interfaces.Repositories;
using Core.Settings;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly Notification _notification;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly AppSettings _appSettings;

        public LoginController(Notification notification, IUsuarioRepository usuarioRepository, AppSettings appSettings)
        {
            _notification = notification;
            _usuarioRepository = usuarioRepository;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            var cookie = Request.Cookies["DataInfraAuthentication"];

            if (!string.IsNullOrEmpty(cookie))
            {
                try
                {
                    DecodeToken.Handler(cookie);
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    Response.Cookies.Delete("DataInfraAuthentication");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(Usuario usuario)
        {

            var usuarioBuscado = _usuarioRepository.BuscarPorEmail(usuario.Email);

            // if (!loginViewModel.Senha.Cryptograph().Equals(usuario.Senha))
            //     return BadRequest("Email ou senha incorretos!");
            if (!usuario.Senha.Equals(usuarioBuscado.Senha) || (!usuario.Email.Equals(usuarioBuscado.Email)))
            {
                return BadRequest("Login ou senha incorretos!");
            }
            else
            {
                var jwt = TokenService.GenerateToken(usuarioBuscado, _appSettings.TokenSettings.Chave);
                Response.Cookies.Append("DataInfraAuthentication", jwt, new CookieOptions
                {
                    Expires = usuario.ManterConectado != default
                            ? DateTime.Now.AddDays(30)
                            : DateTime.Now.AddHours(3)
                }
                );
                return Ok();
            }
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("DataInfraAuthentication");
            return RedirectToAction("Index");
        }
    }
}
