using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Login
{
    static async Task IniciarSesion()
    {
        bool credencialesCorrectas = false;

        do
        {
            Console.WriteLine("Ingrese su nombre de usuario:");
            string username = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña:");
            string password = Console.ReadLine();

            string token = await IniciarSesion(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                credencialesCorrectas = true;
                Console.WriteLine($"Bienvenido");
                Menu.Menuprincipal();
            }
            else
            {
                Console.WriteLine("Datos incorrectos");
            }

        } while (!credencialesCorrectas);
    }

    static async Task<string> IniciarSesion(string username, string password)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            string loginUrl = "https://dummyjson.com/auth/login";

            var datosLogin = new
            {
                username,
                password
            };

            string jsonDatosLogin = Newtonsoft.Json.JsonConvert.SerializeObject(datosLogin);

            httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            var contenido = new StringContent(jsonDatosLogin, Encoding.UTF8, "application/json");

            HttpResponseMessage respuesta = await httpClient.PostAsync(loginUrl, contenido);

            if (respuesta.IsSuccessStatusCode)
            {
                string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                var usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<UsuarioConToken>(contenidoRespuesta);

                if (usuario != null)
                {
                    return usuario.Token;
                }
            }

            return null;
        }
    }
}

class UsuarioConToken
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}