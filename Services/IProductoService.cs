using PFakeStoreApiMovil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFakeStoreApiMovil.Services
{
    internal interface IProductoService
    {
        public Task<List<Productos>> GetAllProducts();
    }
}
