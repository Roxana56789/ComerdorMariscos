namespace ComedorMariscos.DTOs.PlatilloDTOs
{
    public class PlatilloDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; } // para mostrar el nombre de la categoría
    }
}
