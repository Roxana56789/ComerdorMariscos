using ComedorMariscos.DTOs.UsuarioDTOs;
using ComedorMariscos.Entidades;

namespace ComedorMariscos.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario> AddAsync(Usuario usuario);
        Task<List<UsuarioListadoDTO>> GetAllUsuariosAsync();
    }
}
