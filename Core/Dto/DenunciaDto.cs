using Core.Models;

namespace Core.Dto
{
    public class DenunciaDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
    }
}