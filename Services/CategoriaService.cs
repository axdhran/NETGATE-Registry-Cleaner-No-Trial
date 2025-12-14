using PFakeStoreApiMovil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PFakeStoreApiMovil.Services
{
    internal class CategoriaService : ICategoriaService
    {
        const string URL = "https://api.escuelajs.co/api/v1/categories";
        const string URL2 = "https://api.escuelajs.co/api/v1/categories/";

        public async Task CreateCategory(Categoria category)
        {
            var httpClient = new HttpClient();
            var categoryJson = JsonSerializer.Serialize(category);
            var content = new StringContent(categoryJson, Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync(URL2, content);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Categoría creada exitosamente.", "Aceptar");
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        await Application.Current.MainPage.DisplayAlert("Error", "La solicitud no fue exitosa. Detalles: " + errorContent, "Aceptar");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un error al crear la categoría. Código de estado: " + response.StatusCode, "Aceptar");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error de red", "No se pudo realizar la solicitud. Verifica tu conexión a Internet." + ex, "Aceptar");
            }
        }

        public async Task<bool> EliminarCategoria(int id)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync($"https://api.escuelajs.co/api/v1/categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Error","Detalles del error: " + content, "Aceptar");
            }

            return false;
        }

        public async Task<List<Categoria>> GetCategories()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL);
            var content = await response.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<List<Categoria>>(content);

            return categories;
        }

        public async Task<bool> UpdateCategory(int id, string name)
        {
            var httpClient = new HttpClient();
            var content = new StringContent($"{{\"name\": \"{name}\"}}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"https://api.escuelajs.co/api/v1/categories/{id}", content);
           
            if (response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Exitoso", "La categoria de actualizo", "Aceptar");
                return true;
            }
            else
            {
                string conttent = await response.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Error", "Detalles del error: " + conttent, "Aceptar");
            }

            return false;
        }
    }
}
