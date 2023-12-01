namespace Core.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? IdCategoriaPai { get; set; }

        public IEnumerable<Denuncia> Denuncias { get; set; }
    }
}