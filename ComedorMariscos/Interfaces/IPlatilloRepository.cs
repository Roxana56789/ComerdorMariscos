using ComedorMariscos.Entidades;

namespace ComedorMariscos.Interfaces


{
    public interface IPlatilloRepository
    {
        Task<List<Platillo>> GetAllAsync();
        Task<Platillo?> GetByIdAsync(int Id_platillo);
        Task<Platillo> AddAsync(Platillo entity);
        Task<bool> UpdateAsync(Platillo entity);
        Task<bool> DeleteAsync(int Id_platillo);
    }
}

