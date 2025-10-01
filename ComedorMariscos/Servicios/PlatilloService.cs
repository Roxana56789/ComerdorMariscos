using ComedorMariscos.DTOs;
using ComedorMariscos.DTOs.PlatilloDTOs;
using ComedorMariscos.Entidades;
using ComedorMariscos.Interfaces;

namespace ComedorMariscos.Servicios
{
    public class PlatilloService :IPlatilloService
    {
        private readonly IPlatilloRepository _repo;
        public PlatilloService(IPlatilloRepository repo) => _repo = repo;
        public async Task<List<PlatilloRespuestaDTO>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(x => new PlatilloRespuestaDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Precio = x.Precio,
                CategoriaId = x.CategoriaId,
            }).ToList();
        public async Task<PlatilloRespuestaDTO?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            return x == null ? null : new PlatilloRespuestaDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Precio = x.Precio,
                CategoriaId = x.CategoriaId,
            };
        }
        public async Task<PlatilloRespuestaDTO> CreateAsync(PlatilloCreateDTO dto)
        {
            var entity = new Platillo { Nombre = dto.Nombre.Trim(), Descripcion = dto.Descripcion.Trim(), Precio = dto.Precio, CategoriaId = dto.CategoriaId };
            var saved = await _repo.AddAsync(entity);
            return new PlatilloRespuestaDTO { Id = saved.Id, Nombre = saved.Nombre, Descripcion = saved.Descripcion, Precio = saved.Precio, CategoriaId = saved.CategoriaId };
        }

        public async Task<bool> UpdateAsync(int Id_Platillo, PlatilloActualizarDTO dto)
        {
            var current = await _repo.GetByIdAsync(Id_Platillo);
            if (current == null) return false;
            current.Nombre = dto.Nombre.Trim();
            current.Descripcion = dto.Descripcion.Trim();
            current.Precio = dto.Precio;
            current.CategoriaId = dto.CategoriaId;


            return await _repo.UpdateAsync(current);
        }

        public Task<bool> DeleteAsync(int Id_Platillo) => _repo.DeleteAsync(Id_Platillo);
    }
}
