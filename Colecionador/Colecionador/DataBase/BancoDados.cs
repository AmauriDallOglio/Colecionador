using Colecionador.Entidade;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colecionador.DataBase
{
    public class BancoDados
    {
        readonly SQLiteAsyncConnection _database;
        public BancoDados(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Categoria>().Wait();
            _database.CreateTableAsync<Marca>().Wait();
            _database.CreateTableAsync<Produto>().Wait();
        }

        public Task<List<Categoria>> CategoriaTodas()
        {
            return _database.Table<Categoria>().ToListAsync();
        }
        public Task<Categoria> CategoriaPorId(int id)
        {
            return _database.Table<Categoria>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> CategoriaSalvar(Categoria categoria)
        {
            if (categoria.Id != 0)
            {
                return _database.UpdateAsync(categoria);
            }
            else
            {
                return _database.InsertAsync(categoria);
            }
        }
        public Task<int> CategoriaDeletar(Categoria categoria)
        {
            return _database.DeleteAsync(categoria);
        }


        public Task<List<Marca>> MarcaTodas()
        {
            var resultado = _database.Table<Marca>().ToListAsync();
            return resultado;
        }
        public List<Marca> ListaMarcaTodas()
        {
            var resultado = _database.Table<Marca>().ToListAsync().Result.Distinct().ToList();
            return resultado;
        }
        public Task<List<Marca>> TodasMarcasPorCategoria(Categoria categoria)
        {
            return _database.Table<Marca>().Where(a => a.IdCategoria == categoria.Id).ToListAsync();
        }
        public Task<Marca> MarcaPorId(int id)
        {
            return _database.Table<Marca>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> MarcaSalvar(Marca obj)
        {
            if (obj.Id != 0)
            {
                return _database.UpdateAsync(obj);
            }
            else
            {
                return _database.InsertAsync(obj);
            }
        }
        public Task<int> MarcaDeletar(Marca obj)
        {
            return _database.DeleteAsync(obj);
        }



        public Task<List<Produto>> ProdutoTodos()
        {
            return _database.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> ProdutoTodosPorMarca(int idCategoria, int idMarca)
        {
            return _database.Table<Produto>().Where(a => a.IdCategoria == idCategoria && a.IdMarca == idMarca).ToListAsync();
        }

        public Produto ProdutoPorId(int id)
        {
            return _database.Table<Produto>().Where(i => i.Id == id).FirstOrDefaultAsync().Result;
        }
        public Task<int> ProdutoSalvar(Produto obj)
        {
            if (obj.Id != 0)
            {
                return _database.UpdateAsync(obj);
            }
            else
            {
                return _database.InsertAsync(obj);
            }
        }
        public Task<int> ProdutoDeletar(Produto obj)
        {
            return _database.DeleteAsync(obj);
        }
        public Task<List<Produto>> ListaTodosProdutosCategoria(Categoria categoria)
        {
            return _database.Table<Produto>().Where(a => a.IdCategoria == categoria.Id).ToListAsync();
        }
    }
}
