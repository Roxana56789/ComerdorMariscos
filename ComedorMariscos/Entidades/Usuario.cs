using System.ComponentModel.DataAnnotations.Schema;

namespace ComedorMariscos.Entidades
{
    [Table("Usuarios")]
    public class usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Email { get; set; } = "";
        [Column("Password")]
        public string PasswordHash { get; set; } = "";
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;
    }
}
