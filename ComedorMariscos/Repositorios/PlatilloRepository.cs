using ComedorMariscos.Entidades;
using ComedorMariscos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComedorMariscos.Repositorios
{
    public class PlatilloRepository : IPlatilloRepository
    {
        private readonly AppDbContext _context;
        public PlatilloRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Platillo>> GetAllAsync()
            => await _context.Platillos.AsNoTracking().ToListAsync();
        public async Task<Platillo?> GetByIdAsync(int Id_platillo)
            => await _context.Platillos.FindAsync(Id_platillo);
        public async Task<Platillo> AddAsync(Platillo entity)
        {
            _context.Platillos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> UpdateAsync(Platillo entity)
        {
            _context.Platillos.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Platillos.FindAsync(id);
            if (existing == null) return false;
            _context.Platillos.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
