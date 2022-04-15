using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SCVC.Models;

namespace SCVC.Api
{
    public class ApiService
    {

        public async Task<Reply> GetToken(string url, LoginVM login)
        {
            try
            {
                var httpClient = new HttpClient();

                var json = JsonConvert.SerializeObject(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PostAsync(url, content);
                var result = await respuesta.Content.ReadAsStringAsync();
                var dato = JsonConvert.DeserializeObject<Reply>(result);

                if (dato.result == 1)
                {
                    return dato;
                }
                else
                {
                    return dato = new Reply()
                    {
                        result = 0
                    };
                }
            }
            catch
            {
                return new Reply()
                {
                    result = 0
                };
            }
        }

        public async Task<Reply> ValidationToken(string token, string url)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await httpClient.GetAsync(url);
                var result = await respuesta.Content.ReadAsStringAsync();
                var dato = JsonConvert.DeserializeObject<Reply>(result);

                if (dato.result != 1)
                {
                    dato = new Reply()
                    {
                        result = 0,
                        data = false,
                        message = "Token Invalido"
                    };

                    return dato;
                }
                else
                {
                    return dato;
                }

            }
            catch
            {
                return new Reply()
                {
                    result = 0,
                    data = false,
                    message = "Token Invalido"
                };
            }
        }

    }
}
