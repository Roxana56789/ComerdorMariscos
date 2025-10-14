using Comedor.Marisco;
using System;
using Xunit;

namespace Comedor.Marisco.UnitTest.AppxUnit
{
    public class ComedorTests
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            Comedor comedor = new Comedor();
            double num1 = 5.0;
            double num2 = 3.0;

            // Act
            double result = comedor.Add(num1, num2);

            // Assert
            Assert.Equal(8.0, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            // Arrange
            Comedor comedor = new Comedor();
            double num1 = 8.0;
            double num2 = 3.0;

            // Act
            double result = comedor.subtract(num1, num2);

            // Assert
            Assert.Equal(5.0, result);
        }

        [Fact]
        public void Multiply_ShouldReturnCorrectProduct()
        {
            // Arrange
            Comedor comedor = new Comedor();
            double num1 = 4.0;
            double num2 = 2.0;

            // Act
            double result = comedor.multiply(num1, num2);

            // Assert
            Assert.Equal(8.0, result);
        }

        [Fact]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            // Arrange
            Comedor comedor = new Comedor();
            double num1 = 10.0;
            double num2 = 2.0;

            // Act
            double result = comedor.divide(num1, num2);

            // Assert
            Assert.Equal(5.0, result);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            // Arrange
            Comedor comedor = new Comedor();
            double num1 = 5.0;
            double num2 = 0.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => comedor.divide(num1, num2));
        }
    }
}

