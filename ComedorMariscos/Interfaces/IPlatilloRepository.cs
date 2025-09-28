using ComedorMariscos.Entidades;

namespace ComedorMariscos.Interfaces


{
    public interface IPlatilloRepository
    {
        Task<IEnumerable<Platillo>> GetAllAsync();
        Task<Platillo?> GetByIdAsync(int id);
        Task AddAsync(Platillo platillo);
        Task UpdateAsync(Platillo platillo);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}

