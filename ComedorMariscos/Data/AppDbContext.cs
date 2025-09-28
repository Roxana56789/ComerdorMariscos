using ComedorMariscos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComedorMariscos.Repositorios
{
    public class AppDbContext : DbContext
    {
        internal object Categoria;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<usuario> usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- CORRECCIONES DE MAPEO (CASE SENSITIVITY) ---

            // FIX 1: Mapeo de la entidad 'usuario' a la tabla 'usuarios' (minúsculas)
            modelBuilder.Entity<usuario>().ToTable("usuarios");

            // 🚨 FIX FINAL: Mapeo de la entidad 'Rol' a la tabla 'roles' (minúsculas) 🚨
            modelBuilder.Entity<Rol>().ToTable("roles");

            // 🚨 FIX FINAL: Mapeo de la entidad 'Rol' a la tabla 'roles' (minúsculas) 🚨
            modelBuilder.Entity<Categoria>().ToTable("categoria");

            // --- RESTO DE CONFIGURACIONES ---

            // FIX 2: Mapeo de la columna de contraseña
            modelBuilder.Entity<usuario>()
                .Property(u => u.PasswordHash)
                .HasColumnName("Password");

            // Índice Único (Email)
            modelBuilder.Entity<usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Relación de Clave Foránea
            modelBuilder.Entity<usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.usuarios)
                .HasForeignKey(u => u.RolId);

            base.OnModelCreating(modelBuilder);
        }
    }
}