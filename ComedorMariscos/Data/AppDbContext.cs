using ComedorMariscos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComedorMariscos.Repositorios
{
    public class AppDbContext : DbContext
    {
        internal object Platillo;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // --- DbSets ---
        public DbSet<usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Platillo> Platillos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Mapear tablas (case-sensitive) ---
            modelBuilder.Entity<usuario>().ToTable("usuarios");
            modelBuilder.Entity<Rol>().ToTable("roles");
            modelBuilder.Entity<Categoria>().ToTable("categorias");
            modelBuilder.Entity<Platillo>().ToTable("platillos");

            // --- Propiedades ---
            // Mapear PasswordHash a columna 'Password'
            modelBuilder.Entity<usuario>()
                .Property(u => u.PasswordHash)
                .HasColumnName("Password");

            // Índice único para Email
            modelBuilder.Entity<usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // --- Relaciones ---
            modelBuilder.Entity<usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.usuarios)
                .HasForeignKey(u => u.RolId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
