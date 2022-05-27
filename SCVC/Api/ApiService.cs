using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<Reply> GetModels(string url, string token)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await httpClient.GetAsync(url);
                var result = await respuesta.Content.ReadAsStringAsync();
                // var dato = JsonConvert.DeserializeObject<List<T>>(result);

                return new Reply()
                {
                    message = result,
                    result = 1 
                };                
            }catch(Exception Ex)
            {
                return new Reply(){
                    message = $"Error: {Ex.Message}",
                    result = 0
                };
            }
        }
        public async Task<Reply> Post<T>(Object model, string url, string token)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();

                if(!response.IsSuccessStatusCode)
                {
                    return new Reply()
                    {
                        result = 0,
                        message = answer
                    };
                }

                var obj = JsonConvert.DeserializeObject<T>(answer);

                return new Reply()
                {
                    result = 1,
                    data = obj
                };
                
            }catch(Exception ex)
            {
                return new Reply(){
                    message = $"Error {ex.Message}",
                    result = 0
                };
            }
        }
    }
}
