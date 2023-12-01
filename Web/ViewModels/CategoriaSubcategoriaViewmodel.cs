namespace Web.ViewModels
{
    public class CategoriaSubcategoriaViewmodel
    {
        public List<Categoria> Categorias { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public int IdBairro { get; set; }
        public int? IdCategoriaPai { get; set; }
    }
}
