namespace ComedorMariscos.Entidades
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public ICollection<usuario> usuarios { get; set; } = new List<usuario>();
    }
}
