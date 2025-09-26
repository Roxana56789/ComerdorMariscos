using ComedorMariscos.DTOs.UsuarioDTOs;

namespace ComedorMariscos.Interfaces
{
    
    
        public interface IAuthService
        {
            Task<UsuarioRespuestaDTO> RegistrarAsync(UsuarioRegistroDTO dto);
            Task<UsuarioRespuestaDTO?> LoginAsync(UsuarioLoginDTO dto);
        }
    
}

