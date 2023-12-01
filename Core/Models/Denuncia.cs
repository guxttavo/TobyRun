namespace Core.Models
{
    public class Denuncia
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public int IdBairro { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }
        public Bairro Bairro { get; set; }
    }
}