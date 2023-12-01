namespace Core.Models
{
    public class Suporte
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}