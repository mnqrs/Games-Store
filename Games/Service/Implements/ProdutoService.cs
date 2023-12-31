﻿using Games.Data;
using Games.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Service.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                .Include(c => c.Categoria)
                .ToListAsync();
        }
        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
                    .Include(c => c.Categoria)
                    .FirstAsync(i => i.Id == id);

                return Produto;
            }
            catch 
            {
                return null;
            }
        }
        public async Task<IEnumerable<Produto>> GetByValores(decimal primeiroPreco, decimal ultimoPreco)
        
            {

                var Produto = await _context.Produtos
                                .Include(c => c.Categoria)
                                .Where(p => p.Preco >= primeiroPreco && p.Preco <= ultimoPreco)
                                .ToListAsync();

                return Produto;
            }

        
        public async Task<IEnumerable<Produto>> GetByNameorConsole(string nameOrConsole)
        
            {
                var Produto = await _context.Produtos
                                .Include(c => c.Categoria)
                                .Where(p => p.Nome.Contains(nameOrConsole) || p.Console.Contains(nameOrConsole))
                                .ToListAsync();

                return Produto;
            }
        public async Task<Produto?> Update(Produto produto)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(produto.Id);
            if (ProdutoUpdate is null)
            {
                return null;
            }

            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias
                    .FindAsync(produto.Categoria.Id);

                if (BuscaCategoria is null)
                {
                    return null;
                }
            }

            
            produto.Categoria = produto.Categoria is not null ? _context.Categorias
                .FirstOrDefault(t => t.Id == produto.Categoria.Id) : null;

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto?> Create(Produto produto)
        {
            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias
                    .FindAsync(produto.Categoria.Id);

                if (BuscaCategoria is null)
                {
                    return null;
                }
            }

            produto.Categoria = produto.Categoria is not null ? _context.Categorias
                .FirstOrDefault(t => t.Id == produto.Categoria.Id) : null;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        Task<Produto?> IProdutoService.Delete(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
