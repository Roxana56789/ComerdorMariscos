

namespace ComedorMariscos.DTOs.PlatilloDTOs
{
    public class PlatilloActualizarDTO
    {
       
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
       
        public decimal Precio { get; set; }

        
        public int CategoriaId { get; set; }
    }
}
