using ComedorMariscos.DTOs;
using ComedorMariscos.DTOs.CategoriaDTOs;

namespace ComedorMariscos.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaRespuestaDTO>> GetAllAsync();
        Task<CategoriaRespuestaDTO?> GetByIdAsync(int Id_Categoria);
        Task<CategoriaRespuestaDTO> CreateAsync(CategoriaCreateDTO dto);
        Task<bool> UpdateAsync(int Id_Categoria, CategoriaActualizarDTO dto);
        Task<bool> DeleteAsync(int Id_Categoria);
    }
}
