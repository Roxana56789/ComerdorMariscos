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

        public async Task AddAsync(Platillo platillo)
        {
            await _context.Platillos.AddAsync(platillo);
        }

        public async Task UpdateAsync(Platillo platillo)
        {
            _context.Platillos.Update(platillo);
        }

        public async Task DeleteAsync(int id)
        {
            var platillo = await GetByIdAsync(id);
            if (platillo != null)
            {
                _context.Platillos.Remove(platillo);
            }
        }

        public async Task<Platillo?> GetByIdAsync(int id)
        {
            return await _context.Platillos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Platillo>> GetAllAsync()
        {
            return await _context.Platillos
                .Include(p => p.Categoria)
                .ToListAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
