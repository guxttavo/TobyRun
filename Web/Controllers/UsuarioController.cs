using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : AuthenticatedController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioRepository.BuscarTodos();

            return View("Index", usuarios);
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            var novoUsuario = new Usuario
            {
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                DataNascimento = usuario.DataNascimento.ToUniversalTime(),
                Telefone = usuario.Telefone,
                Email = usuario.Email,
                Cep = usuario.Cep,
                Senha = usuario.Senha,
                Admin = usuario.Admin,
                DataCadastro = DateTime.UtcNow
            };

            _usuarioRepository.CadastrarUsuario(novoUsuario);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewCadastrar()
        {
            return View("_cadastrar");
        }

        [HttpGet]
        public IActionResult ViewEditar(int id)
        {
            var usuarioSelecionado = _usuarioRepository.BuscarPorId(id);
            return View("_editar", usuarioSelecionado);
        }
        
        [HttpGet]
        public IActionResult ViewApagarConfirmacao()
        {
            return View("_apagarConfirmacao");
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            _usuarioRepository.EditarUsuario(usuario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioRepository.DeletarUsuario(id); 
            return RedirectToAction("Index");
        }
    }
}