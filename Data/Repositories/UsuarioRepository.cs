using Core.Interfaces.Repositories;
using Core.Models;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Usuario> BuscarTodos()
        {
            return _dbContext.Usuarios.ToList();
        }
        public Usuario BuscarPorId(int id)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public Usuario CadastrarUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }

        public Usuario EditarUsuario(Usuario usuario)
        {
            Usuario usuarioDb = BuscarPorId(usuario.Id);

            if (usuarioDb != null)
            {
                usuario.Nome = usuario.Nome;
                usuario.Cpf = usuario.Cpf;
                usuario.DataNascimento = usuario.DataNascimento.ToUniversalTime();
                usuario.Telefone = usuario.Telefone;
                usuario.Email = usuario.Email;
                usuario.Cep = usuario.Cep;
                usuario.Senha = usuario.Senha;
                usuario.Admin = usuario.Admin;
                usuario.DataCadastro = DateTime.UtcNow;
                _dbContext.Update(usuario);
                _dbContext.SaveChanges();
            }

            // return usuario;
            return usuario;
        }

        public bool DeletarUsuario(int id)
        {
            Usuario usuarioDB = BuscarPorId(id);

            _dbContext.Usuarios.Remove(usuarioDB);
            _dbContext.SaveChanges();

            return true;
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }
    }
}

