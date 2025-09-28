namespace ComedorMariscos.Entidades
{
    public class Platillo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }

        // 🔗 Relación con Categoría
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
