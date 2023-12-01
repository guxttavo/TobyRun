namespace Core.Models
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Denuncia> Denuncias { get; set; }
    }
}