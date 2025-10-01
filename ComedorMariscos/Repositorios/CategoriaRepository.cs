using ComedorMariscos.Entidades;
using ComedorMariscos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComedorMariscos.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> GetAllAsync()
            => await _context.Categorias.AsNoTracking().ToListAsync();
        public async Task<Categoria?> GetByIdAsync(int Id_Categoria)
            => await _context.Categorias.FindAsync(Id_Categoria);
        public async Task<Categoria> AddAsync(Categoria entity)
        {
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> UpdateAsync(Categoria entity)
        {
            _context.Categorias.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Categorias.FindAsync(id);
            if (existing == null) return false;
            _context.Categorias.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
