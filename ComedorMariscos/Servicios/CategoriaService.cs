using ComedorMariscos.DTOs;
using ComedorMariscos.DTOs.CategoriaDTOs;
using ComedorMariscos.Entidades;
using ComedorMariscos.Interfaces;

namespace ComedorMariscos.Servicios
{
    public class CategoriaService :ICategoriaService
    {
        private readonly ICategoriaRepository _repo;
        public CategoriaService(ICategoriaRepository repo) => _repo = repo;
        public async Task<List<CategoriaRespuestaDTO>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(x => new CategoriaRespuestaDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            }).ToList();
        public async Task<CategoriaRespuestaDTO?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            return x == null ? null : new CategoriaRespuestaDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            };
        }
        public async Task<CategoriaRespuestaDTO> CreateAsync(CategoriaCreateDTO dto)
        {
            var entity = new Categoria { Nombre = dto.Nombre.Trim(), Descripcion = dto.Descripcion.Trim() };
            var saved = await _repo.AddAsync(entity);
            return new CategoriaRespuestaDTO { Id = saved.Id, Nombre = saved.Nombre, Descripcion = saved.Descripcion };
        }

        public async Task<bool> UpdateAsync(int Id_Categoria, CategoriaActualizarDTO dto)
        {
            var current = await _repo.GetByIdAsync(Id_Categoria);
            if (current == null) return false;
            current.Nombre = dto.Nombre.Trim();
            current.Descripcion = dto.Descripcion.Trim();
            return await _repo.UpdateAsync(current);
        }

        public Task<bool> DeleteAsync(int Id_Categoria) => _repo.DeleteAsync(Id_Categoria);
    
    }
}
