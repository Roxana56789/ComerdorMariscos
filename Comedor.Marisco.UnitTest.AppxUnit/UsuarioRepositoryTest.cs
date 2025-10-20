using System;
using System.Threading.Tasks;      
using ComedorMariscos.Entidades;       
using ComedorMariscos.Repositorios;    
using Microsoft.EntityFrameworkCore;

using Xunit;                           

namespace ComedorMariscos.UnitTest.AppxUnit
{
    public class UsuarioRepositoryTest
    {
        
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDB_{Guid.NewGuid()}")
                .Options;

            var context = new AppDbContext(options);

            // Datos iniciales de prueba
            context.Roles.Add(new Rol { Id = 1, Nombre = "Admin" });

            context.Usuarios.Add(new usuario
            {
                Id = 2,
                Nombre = "Roxana",
                Email = "Roxana@test.com",
                Passwordhast = "123",
                RolId = 1
            });

            context.SaveChanges();
            return context;
        }

        // ✅ PRUEBA 1: Buscar un usuario existente por email
        [Fact]
        public async Task GetByEmailAsync_RetornarUsuarioExistente()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            // Act
            var usuario = await repo.GetByEmailAsync("Roxana@test.com");

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal("Roxana", usuario.Nombre);
            Assert.Equal("Admin", usuario.Rol.Nombre);
        }

        // ✅ PRUEBA 2: Agregar un nuevo usuario
        [Fact]
        public async Task AddAsync_AgregarUsuario()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            var nuevoUsuario = new usuario
            {
                Nombre = "Juan",
                Email = "Juan@test.com",
                Passwordhast = "3456",
                RolId = 1
            };

            // Act
            await repo.AddAsync(nuevoUsuario);
            var usuarioGuardado = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == "Juan@test.com");

            // Assert
            Assert.NotNull(usuarioGuardado);
            Assert.Equal("Juan", usuarioGuardado.Nombre);
        }

      
        [Fact]
        public async Task GetAllUsuariosAsync_RetornarListaUsuarios()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            // Act
            var lista = await repo.GetAllUsuariosAsync();

            // Assert
            Assert.NotEmpty(lista);
            Assert.Contains(lista, u => u.Email == "Roxana@test.com");
        }
    }
}
