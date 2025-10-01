using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedorMariscos.Entidades
{
    [Table("platillos")]
    public class Platillo
    {
        [Key]
        [Column("id_platillo")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;
        [Column("descripcion")]
        public string? Descripcion { get; set; }
        [Column("precio")]
        public decimal Precio { get; set; }

        // 🔗 Relación con Categoría
        [Column("id_categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
