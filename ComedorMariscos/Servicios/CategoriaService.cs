using ComedorMariscos.DTOs;
using ComedorMariscos.Entidades;
using ComedorMariscos.Interfaces;

namespace ComedorMariscos.Servicios
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categorias = await _repository.GetAllAsync();
            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion
            });
        }

        public async Task<CategoriaDTO?> GetByIdAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null) return null;

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<CategoriaDTO> AddAsync(CategoriaCreateDTO dto)
        {
            var categoria = new Categoria
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            await _repository.AddAsync(categoria);

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<bool> UpdateAsync(int id, CategoriaCreateDTO dto)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null) return false;

            categoria.Nombre = dto.Nombre;
            categoria.Descripcion = dto.Descripcion;

            await _repository.UpdateAsync(categoria);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
