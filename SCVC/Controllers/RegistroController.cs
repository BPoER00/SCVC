using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCVC.Api;
using SCVC.Models;

namespace SCVC.Controllers
{
    public class RegistroController : Controller  {
       private ApiService api;

        public RegistroController()
        {
            this.api = new ApiService();
        }

        public async Task<IActionResult> RegistroPersonas(BuscarPersona persona)
        {
            var tokenValidate = await this.api.ValidationToken(persona.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    try
                    {
                        var Persona = await this.api.GetModels("https://apiscvc.azurewebsites.net/Persona/Get/", persona.Token);
                        var PersonaS = JsonConvert.DeserializeObject<List<Persona>>(Persona.message);
                        this.CookieSet(persona.Id, persona.Token, persona.Nombre, persona.Usuario);
                        ViewBag.Token = persona.Token;
                        ViewData["Usuario"] = persona.Usuario;
                        ViewBag.Persona = PersonaS;
                        return View();
                    }catch(Exception Ex)
                    {
                        return BadRequest($"Error: {Ex.Message}");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
        }

        public async Task<IActionResult> RegistroVacunacion(BuscarPersona persona)
        {
            var tokenValidate = await this.api.ValidationToken(persona.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    try
                    {
                        var Vacunacion = await this.api.GetModels("https://apiscvc.azurewebsites.net/Vacunacion/Get/", persona.Token);
                        var VacunacionS = JsonConvert.DeserializeObject<List<Vacunacion>>(Vacunacion.message);                        
                        this.CookieSet(persona.Id, persona.Token, persona.Nombre, persona.Usuario);
                        ViewBag.Token = persona.Token;
                        ViewData["Usuario"] = persona.Usuario;
                        ViewBag.Vacunacion = VacunacionS;
                        return View();
                    }
                    catch(Exception Ex)
                    {
                        return BadRequest($"Error: {Ex.Message}");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
        }

        public void CookieSet(string Id, string Token, string Nombre, string Usuario)
        {
            var options = new CookieOptions();

            options.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Append("Id", Id, options);

            options.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Append("Token", Token, options);

            options.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Append("Nombre", Nombre, options);
        
            options.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Append("Usuario", Usuario, options);
        
        }

        public BuscarPersona CookieGet()
        {
            if (Request.Cookies["Token"] != null)
            {
                string Id = Request.Cookies["Id"];
                string Token = Request.Cookies["Token"];
                string Nombre = Request.Cookies["Nombre"];
                string Usuario = Request.Cookies["Usuario"];

                return new BuscarPersona()
                {
                    Id = Id,
                    Token = Token,
                    Nombre = Nombre,
                    Usuario = Usuario
                };
            }
            else
            {
                return null;
            }

        }

        public IActionResult CookieDelete()
        {
            if (Request.Cookies["Token"] != null)
            {
                Response.Cookies.Delete("Id");
                Response.Cookies.Delete("Token");
                Response.Cookies.Delete("Nombre");
                Response.Cookies.Delete("Usuario");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return BadRequest();
            }
        }


    }
}