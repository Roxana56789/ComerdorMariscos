using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComedorMariscos.Entidades
{
    [Table("roles")]
    public class Rol
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; } = "";
        public ICollection<usuario> usuarios { get; set; } = new List<usuario>();
    }
}
