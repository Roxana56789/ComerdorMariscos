using ComedorMariscos.DTOs.UsuarioDTOs;
using ComedorMariscos.Entidades;

namespace ComedorMariscos.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<usuario?> GetByEmailAsync(string email);
        Task<usuario> AddAsync(usuario usuario);
        Task<List<UsuarioListadoDTO>> GetAllUsuariosAsync();
    }
}
