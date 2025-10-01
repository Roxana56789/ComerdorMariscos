using ComedorMariscos.DTOs;
using ComedorMariscos.DTOs.CategoriaDTOs;
using ComedorMariscos.DTOs.PlatilloDTOs;

namespace ComedorMariscos.Interfaces
{
    public interface IPlatilloService
    {
        Task<List<PlatilloRespuestaDTO>> GetAllAsync();
        Task<PlatilloRespuestaDTO?> GetByIdAsync(int Id_Platillo);
        Task<PlatilloRespuestaDTO> CreateAsync(PlatilloCreateDTO dto);
        Task<bool> UpdateAsync(int Id_Platillo, PlatilloActualizarDTO dto);
        Task<bool> DeleteAsync(int Id_Platillo);

       
    }
}
