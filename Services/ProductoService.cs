using PFakeStoreApiMovil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PFakeStoreApiMovil.Services
{
    internal class ProductoService : IProductoService
    {
        const string URL = "https://fakestoreapi.com/products";

        public async Task<List<Productos>> GetAllProducts()
        {
            var httpCliente = new HttpClient();
            var response = await httpCliente.GetAsync(URL);//--Ejecuta el metodo get
            var content = await response.Content.ReadAsStringAsync();//--Lee el resultado del metido get
            var products = JsonSerializer.Deserialize<List<Productos>>(content);//--Deserializa el Json

            return products;
        }
    }
}
