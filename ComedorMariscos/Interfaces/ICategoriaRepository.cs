using ComedorMariscos.Entidades;

namespace ComedorMariscos.Interfaces

{
    public interface ICategoriaRepository

    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task AddAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
