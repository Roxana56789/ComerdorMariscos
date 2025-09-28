namespace ComedorMariscos.DTOs
{
    public class PlatilloCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; } // 🔗 relación con la tabla Categoría
    }
}
