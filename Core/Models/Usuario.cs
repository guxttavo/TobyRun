using System.ComponentModel.DataAnnotations.Schema;
using Core.Enum;
using Core.Helpers;

namespace Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Telefone { get; set; }
        public string Email { get; set; }
        public int Cep { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public DateTime DataCadastro { get; set; }
        [NotMapped]
        public bool? ManterConectado { get; set; }
        [NotMapped]
        public string? ConfirmarSenha { get; set; }

        public IEnumerable<Suporte> Suportes { get; set; }
        public IEnumerable<Denuncia> Denuncias { get; set; }

        public bool IsValid(Notification _notification)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
                _notification.Add("Apelido e senha são obrigatórios");

            return !_notification.Any();
        }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
