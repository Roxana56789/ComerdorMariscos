using System.ComponentModel.DataAnnotations.Schema;

namespace ComedorMariscos.DTOs
{
    public class CategoriaRespuestaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}