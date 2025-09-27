namespace ComedorMariscos.Entidades
{
    public class usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;
    }
}
