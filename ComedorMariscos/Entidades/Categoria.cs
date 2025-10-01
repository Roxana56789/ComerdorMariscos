using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedorMariscos.Entidades
{
    [Table("categoria")]
    public class Categoria
    {
       [ Key]
        [Column("id_categoria")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;
        [Column("descripcion")]
        public string? Descripcion { get; set; }

        public ICollection<Platillo> Platillos { get; set; } = new List<Platillo>();
    }
}
