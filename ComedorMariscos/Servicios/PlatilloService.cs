using ComedorMariscos.DTOs;
using ComedorMariscos.DTOs.PlatilloDTOs;
using ComedorMariscos.Entidades;
using ComedorMariscos.Interfaces;

namespace ComedorMariscos.Servicios
{
    public class PlatilloService
    {
        private readonly IPlatilloRepository _repository;

        public PlatilloService(IPlatilloRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlatilloDTO>> GetAllAsync()
        {
            var platillos = await _repository.GetAllAsync();
            return platillos.Select(p => new PlatilloDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria != null ? p.Categoria.Nombre : null
            });
        }

        public async Task<PlatilloDTO?> GetByIdAsync(int id)
        {
            var platillo = await _repository.GetByIdAsync(id);
            if (platillo == null) return null;

            return new PlatilloDTO
            {
                Id = platillo.Id,
                Nombre = platillo.Nombre,
                Descripcion = platillo.Descripcion,
                Precio = platillo.Precio,
                CategoriaId = platillo.CategoriaId,
                CategoriaNombre = platillo.Categoria != null ? platillo.Categoria.Nombre : null
            };
        }

        public async Task<PlatilloDTO> AddAsync(PlatilloCreateDTO dto)
        {
            var platillo = new Platillo
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                CategoriaId = dto.CategoriaId
            };

            await _repository.AddAsync(platillo);

            return new PlatilloDTO
            {
                Id = platillo.Id,
                Nombre = platillo.Nombre,
                Descripcion = platillo.Descripcion,
                Precio = platillo.Precio,
                CategoriaId = platillo.CategoriaId
            };
        }

        public async Task<bool> UpdateAsync(int id, PlatilloCreateDTO dto)
        {
            var platillo = await _repository.GetByIdAsync(id);
            if (platillo == null) return false;

            platillo.Nombre = dto.Nombre;
            platillo.Descripcion = dto.Descripcion;
            platillo.Precio = dto.Precio;
            platillo.CategoriaId = dto.CategoriaId;

            await _repository.UpdateAsync(platillo);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var platillo = await _repository.GetByIdAsync(id);
            if (platillo == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
