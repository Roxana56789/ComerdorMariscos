using ComedorMariscos.Entidades;
using Xunit;

namespace ComedorMariscos.UnitTest
{
    public class PlatilloTests
    {
        [Fact]
        public void Constructor_DeberiaInicializarConValoresPorDefecto()
        {
            // Arrange & Act
            var platillo = new Platillo();

            // Assert
            Assert.Equal(0, platillo.Id);
            Assert.Equal(string.Empty, platillo.Nombre);
            Assert.Null(platillo.Descripcion);
            Assert.Equal(0, platillo.Precio);
            Assert.Equal(0, platillo.CategoriaId);
            Assert.Null(platillo.Categoria);
        }

        [Fact]
        public void Propiedades_DeberianAsignarseCorrectamente()
        {
            // Arrange
            var categoria = new Categoria { Id = 1, Nombre = "Mariscos" };

            var platillo = new Platillo
            {
                Id = 10,
                Nombre = "Ceviche Mixto",
                Descripcion = "Delicioso ceviche con camarones y pescado",
                Precio = 8.50m,
                CategoriaId = 1,
                Categoria = categoria
            };

            // Act & Assert
            Assert.Equal(10, platillo.Id);
            Assert.Equal("Ceviche Mixto", platillo.Nombre);
            Assert.Equal("Delicioso ceviche con camarones y pescado", platillo.Descripcion);
            Assert.Equal(8.50m, platillo.Precio);
            Assert.Equal(1, platillo.CategoriaId);
            Assert.Equal("Mariscos", platillo.Categoria.Nombre);
        }

        [Fact]
        public void Nombre_DeberiaSerStringVacioPorDefecto()
        {
            // Arrange
            var platillo = new Platillo();

            // Assert
            Assert.Equal(string.Empty, platillo.Nombre);
        }

        [Fact]
        public void PuedeAsignarseCategoria()
        {
            // Arrange
            var categoria = new Categoria { Id = 5, Nombre = "Pescados" };
            var platillo = new Platillo
            {
                Id = 20,
                Nombre = "Filete de pescado",
                CategoriaId = 5,
                Categoria = categoria
            };

            // Act & Assert
            Assert.Equal(5, platillo.CategoriaId);
            Assert.Equal("Pescados", platillo.Categoria.Nombre);
        }
    }
}
