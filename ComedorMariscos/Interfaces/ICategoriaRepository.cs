using ComedorMariscos.Entidades;

namespace ComedorMariscos.Interfaces

{
    public interface ICategoriaRepository

    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int Id_Categoria);
        Task<Categoria> AddAsync(Categoria entity);
        Task<bool> UpdateAsync(Categoria entity);
        Task<bool> DeleteAsync(int Id_Categoria);
    }
}
