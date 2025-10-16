using Comedor.Marisco;
using Comedor.Marisco.Entidades;
using Comedor.Marisco.Repositorios;
using ComedorMariscos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Comedor.Marisco.UnitTest.AppxUnit
{
    public class ComedorRepositoryTest 
    {
        // 🔹 Crea un contexto de base de datos en memoria
        private ComedorDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ComedorDbContext>()
                .UseInMemoryDatabase(databaseName: $"ComedorTestDB_{Guid.NewGuid()}")
                .Options;

            var context = new ComedorDbContext(options);

            // Datos iniciales
            context.Platillos.Add(new Platillo
            {
                Id = 1,
                Nombre = "Camarones al Ajillo",
                Precio = 12.5,
                Categoria = "Mariscos"
            });

            context.Platillos.Add(new Platillo
            {
                Id = 2,
                Nombre = "Pescado Frito",
                Precio = "9.99",
                Categoria = "Mariscos",
            });

            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetByNombreAsync_DeberiaRetornarPlatilloExistente()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new ComedorRepository(context);

            // Act
            var platillo = await repo.GetByNombreAsync("Camarones al Ajillo");

            // Assert
            Assert.NotNull(platillo);
            Assert.Equal("Camarones al Ajillo", platillo.Nombre);
            Assert.Equal(12.5, platillo.Precio);
        }

        [Fact]
        public async Task AddAsync_DeberiaAgregarNuevoPlatillo()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new ComedorRepository(context);

            var nuevoPlatillo = new Platillo
            {
                Nombre = "Filete de Pescado",
                Precio = "10.5",
                Categoria = "Pescados",
            };

            // Act
            await repo.AddAsync(nuevoPlatillo);

            // Assert
            var platilloGuardado = await context.Platillos.FirstOrDefaultAsync(p => p.Nombre == "Filete de Pescado");
            Assert.NotNull(platilloGuardado);
            Assert.Equal("Filete de Pescado", platilloGuardado.Nombre);
            Assert.Equal(10.5, platilloGuardado.Precio);
        }

        [Fact]
        public async Task GetAllAsync_DeberiaRetornarListaDePlatillos()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new ComedorRepository(context);

            // Act
            var lista = await repo.GetAllAsync();

            // Assert
            Assert.NotEmpty(lista);
            Assert.Contains(lista, p => p.Nombre == "Camarones al Ajillo");
            Assert.Contains(lista, p => p.Nombre == "Pescado Frito");
        }
    }
}

