using Games.Model;

namespace Games.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();
            
        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNameorConsole(string nameOrConsole);

        Task<IEnumerable<Produto>> GetByValores(decimal primeiroPreco, decimal ultimoPreco);

        Task<Produto?> Create (Produto produto);

        Task<Produto?> Update (Produto produto);

        Task<Produto?> Delete (Produto produto);
    }
}
