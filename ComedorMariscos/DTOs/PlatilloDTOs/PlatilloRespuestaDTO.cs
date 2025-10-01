namespace ComedorMariscos.DTOs.PlatilloDTOs
{
    public class PlatilloRespuestaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }


        public int CategoriaId { get; set; }
    }
}
