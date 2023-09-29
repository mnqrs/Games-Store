using Games.Model;

namespace Games.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();

        Task<Categoria> GetById(int id);

        Task<IEnumerable<Categoria>> GetByGenero(string genero);

        Task<Categoria?> Create(Categoria categoria);

        Task<Categoria?> Update(Categoria categoria);

        Task<Categoria?> Delete(Categoria categoria);
    }
}
