using ComedorMariscos.Entidades;
using Xunit;
using System.Linq;

namespace ComedorMariscos.UnitTest
{
    public class CategoriaTests
    {
        [Fact]
        public void Constructor_DeberiaInicializarColeccionPlatillosVacia()
        {
            // Arrange & Act
            var categoria = new Categoria();

            // Assert
            Assert.NotNull(categoria.Platillos);
            Assert.Empty(categoria.Platillos);
        }

        [Fact]
        public void Propiedades_DeberianAsignarseCorrectamente()
        {
            // Arrange
            var categoria = new Categoria
            {
                Id = 1,
                Nombre = "Mariscos",
                Descripcion = "Comidas del mar"
            };

            // Act & Assert
            Assert.Equal(1, categoria.Id);
            Assert.Equal("Mariscos", categoria.Nombre);
            Assert.Equal("Comidas del mar", categoria.Descripcion);
        }

        [Fact]
        public void Nombre_DeberiaSerStringVacioPorDefecto()
        {
            // Arrange
            var categoria = new Categoria();

            // Act & Assert
            Assert.Equal(string.Empty, categoria.Nombre);
        }

        [Fact]
        public void Platillos_DeberiaPermitirAgregarElementos()
        {
            // Arrange
            var categoria = new Categoria();
            var platillo = new Platillo { Id = 10, Nombre = "Ceviche" };

            // Act
            categoria.Platillos.Add(platillo);

            // Assert
            Assert.Single(categoria.Platillos);
            Assert.Equal("Ceviche", categoria.Platillos.First().Nombre);
        }
    }

    
}

