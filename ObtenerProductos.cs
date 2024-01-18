using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class ObtenerProductos
{
    private const string UrlApi = "https://dummyjson.com/products";

    public async Task<List<Producto>> ObtenerProductosDesdeAPI()
    {
        List<Producto> productos = new List<Producto>();

        using (HttpClient cliente = new HttpClient())
        {
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(UrlApi);

                if (respuesta.IsSuccessStatusCode)
                {
                    string contenido = await respuesta.Content.ReadAsStringAsync();
                    productos = JsonConvert.DeserializeObject<List<Producto>>(contenido);

                    if (productos != null && productos.Count > 0)
                    {
                        Console.WriteLine("Productos obtenidos con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Lista vacia");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {respuesta.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
            }
        }

        return productos;
    }
}