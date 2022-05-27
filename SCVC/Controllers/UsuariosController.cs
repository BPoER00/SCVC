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
    public class UsuariosController : Controller  {
        
        private ApiService api;

        public UsuariosController()
        {
            this.api = new ApiService();
        }

        public async Task<IActionResult> AgregarUsuario(BuscarPersona persona)
        {
            var tokenValidate = await this.api.ValidationToken(persona.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    try
                    {
                        this.CookieSet(persona.Id, persona.Token, persona.Nombre, persona.Usuario);
                        var rolesU = await this.api.GetModels("https://apiscvc.azurewebsites.net/RolUsuario/Get/", persona.Token);
                        var RolS = JsonConvert.DeserializeObject<List<RolUsuario>>(rolesU.message);
                        ViewBag.roles = RolS;
                        ViewBag.Token = persona.Token;
                        ViewData["Usuario"] = persona.Usuario;
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

        public async Task<IActionResult> GuardarUsuarios(Usuarios usuarios)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    var cookies = this.CookieGet();
                    var dato = await this.api.Post<Usuarios>(usuarios, "https://apiscvc.azurewebsites.net/Usuarios/Post/", cookies.Token);
                    return Ok(dato);
                }catch(Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }

        }

        public async Task<IActionResult> MostrarUsuarios(BuscarPersona persona)
        {
            var tokenValidate = await this.api.ValidationToken(persona.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    try
                    {
                        this.CookieSet(persona.Id, persona.Token, persona.Nombre, persona.Usuario);
                        var Usuarios = await this.api.GetModels("https://apiscvc.azurewebsites.net/Usuarios/Get/", persona.Token);
                        var usuariosS = JsonConvert.DeserializeObject<List<Usuarios>>(Usuarios.message);
                        ViewBag.Usuarios = usuariosS;
                        ViewBag.Token = persona.Token;
                        ViewData["Usuario"] = persona.Usuario;
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