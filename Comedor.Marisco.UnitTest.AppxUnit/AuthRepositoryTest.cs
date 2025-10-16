using ComedorMariscos.DTOs.UsuarioDTOs;
using ComedorMariscos.Entidades;
using ComedorMariscos.Interfaces;
using ComedorMariscos.Repositorios.DTOs;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AuthApi.TestXunit
{
    public class AuthRepositoryTest
    {
        private IConfiguration GetTestConfiguration()
        {
            var inMemoryConfig = new Dictionary<string, string>
            {
                {"Jwt:Key", "ClaveSuperSecretaMuyLargatest567890!" },
                {"Jwt:Issuer", "AuthApiTest"},
                {"Jwt:Audience", "AuthApiClients"}
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryConfig)
                .Build();
        }

        [Fact]
        public async Task RegistrarAsync_RetorneUsuarioConToken()
        {
            // Arrange
            var mockRepo = new Mock<IUsuarioRepository>();
            var config = GetTestConfiguration();

            var usuario = new usuario
            {
                Id = 1,
                Nombre = "Kenia",
                Email = "kenia@gmail.com",
                PasswordHash = "hash",
                Rol = new Rol { Id = 2, Nombre = "usuario" }
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<usuario>())).ReturnsAsync(usuario);
            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(usuario);

            var service = new AuthRepository(mockRepo.Object, config);

            var registroDTO = new UsuarioRegistroDTO
            {
                Nombre = "Kenia",
                Email = "kenia@gmail.com",
                Password = "123"
            };

            // Act
            var result = await service.RegistrarAsync(registroDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Kenia", result.Nombre);
            Assert.Equal("kenia@gmail.com", result.Email);
            Assert.False(string.IsNullOrEmpty(result.Token));
        }

        [Fact]
        public async Task LoginAsync_RetornalNullSiUsuarioNoExiste()
        {
            var mockRepo = new Mock<IUsuarioRepository>();
            var confing = GetTestConfiguration();

            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((usuario?)null);

            var service = new AuthRepository(mockRepo.Object, confing);
            var loginDto = new UsuarioLoginDTO
            {
                Email = "Kenia@test.com",
                Password = "123"
            };
            var result = service.LoginAsync(loginDto);

            Assert.NotNull(result);

        }
    }
}