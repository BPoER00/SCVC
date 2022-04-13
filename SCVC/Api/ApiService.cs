using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
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

                if(dato.result == 1)
                {
                    return dato;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
