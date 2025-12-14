using PFakeStoreApiMovil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFakeStoreApiMovil.Services
{
    internal interface ICategoriaService
    {
        Task CreateCategory(Categoria category);

        Task<bool> UpdateCategory(int id, string name);

        Task<List<Categoria>> GetCategories();

        Task<bool> EliminarCategoria(int id);
    }
}
