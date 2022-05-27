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
    public class OpcionesController : Controller
    {
        private ApiService api = new ApiService();
        public async Task<IActionResult> LoginGuardar(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var dato = await this.api.GetToken("https://apiscvc.azurewebsites.net/Login/Post/", login);
                if (dato.result == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    var Usuario = await this.api.GetModels($"https://apiscvc.azurewebsites.net/Usuarios/Get/{dato.message}", (string) dato.data);
                    var UsuarioS = JsonConvert.DeserializeObject<Usuarios>(Usuario.message);
                    string Id = UsuarioS.IdUsuario.ToString();

                    this.CookieSet(Id, (string)dato.data, UsuarioS.Usuario, login.Usuario);
                    return RedirectToAction("MenuPrincipal");
                }
            }
        }

        public async Task<IActionResult> MenuPrincipal()
        {
            var token = this.CookieGet();
            if (token != null)
            {
                var tokenValidate = await this.api.ValidationToken(token.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    ViewBag.Id = token.Id;
                    ViewBag.Token = token.Token;
                    ViewBag.Nombre = token.Nombre;
                    ViewData["Usuario"] = token.Usuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest("Error");
            }
        }

        public async Task<IActionResult> VistaAgregarPersona()
        {
            var token = this.CookieGet();
            if (token != null)
            {
                var tokenValidate = await this.api.ValidationToken(token.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    ViewBag.Id = token.Id;
                    ViewBag.Token = token.Token;
                    ViewBag.Nombre = token.Nombre;
                    ViewData["Usuario"] = token.Usuario;

                    var Direcciones = await this.api.GetModels("https://apiscvc.azurewebsites.net/Direcciones/Get/", token.Token);
                    var Dire = JsonConvert.DeserializeObject<List<Direcciones>>(Direcciones.message);
                    ViewBag.Direcciones = Dire;

                    var Generos = await this.api.GetModels("https://apiscvc.azurewebsites.net/Generos/Get/", token.Token);
                    var Gene = JsonConvert.DeserializeObject<List<Generos>>(Generos.message);
                    ViewBag.Generos = Gene;

                    var Etnias = await this.api.GetModels("https://apiscvc.azurewebsites.net/Etnias/Get/", token.Token);
                    var Etni = JsonConvert.DeserializeObject<List<Etnias>>(Etnias.message);
                    ViewBag.Etnias = Etni;

                    var Roles = await this.api.GetModels("https://apiscvc.azurewebsites.net/Roles/Get/", token.Token);
                    var Role = JsonConvert.DeserializeObject<List<Roles>>(Roles.message);
                    ViewBag.Roles = Role;                     

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest();
            }            
        }

        public async Task<IActionResult> VistaVacunasPersona()
        {
            var token = this.CookieGet();
            if (token != null)
            {
                var tokenValidate = await this.api.ValidationToken(token.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    ViewBag.Id = token.Id;
                    ViewBag.Token = token.Token;
                    ViewBag.Nombre = token.Nombre;
                    ViewData["Usuario"] = token.Usuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest();
            }         
        }
        public async Task<IActionResult> VistaVacunas(BuscarPersona Buscar)
        {
            var token = this.CookieGet();
            if (token != null)
            {
                var tokenValidate = await this.api.ValidationToken(token.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    var PersonaVacuna = await this.api.GetModels($"https://apiscvc.azurewebsites.net/Persona/Get/{Buscar.Id}", token.Token);
                    var persona = JsonConvert.DeserializeObject<Persona>(PersonaVacuna.message);
                    ViewBag.IdPersona = persona.IdPersona;
                    ViewBag.Persona = persona.NombrePersona;

                    var EnfermeroVacuna = await this.api.GetModels("https://apiscvc.azurewebsites.net/Persona/GetEnfermero", token.Token);
                    var enfermero = JsonConvert.DeserializeObject<List<Persona>>(EnfermeroVacuna.message);
                    ViewBag.Enfermero = enfermero;
                    
                    var VacunaM = await this.api.GetModels("https://apiscvc.azurewebsites.net/Vacunas/Get", token.Token);
                    var Vacuna = JsonConvert.DeserializeObject<List<Vacunas>>(VacunaM.message);
                    ViewBag.Vacuna = Vacuna;
                    
                    ViewBag.Id = token.Id;
                    ViewBag.Token = token.Token;
                    ViewBag.Nombre = token.Nombre;
                    ViewData["Usuario"] = token.Usuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest();
            }
        }

        public async Task<IActionResult> VistaRegistros()
        {
            var token = this.CookieGet();
            if (token != null)
            {
                var tokenValidate = await this.api.ValidationToken(token.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    ViewBag.Id = token.Id;
                    ViewBag.Token = token.Token;
                    ViewBag.Nombre = token.Nombre;
                    ViewData["Usuario"] = token.Usuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest();
            }
        }

        public async Task<IActionResult> VistaExtras()
        {
            var token = this.CookieGet();
            if (token != null)
            {
                var tokenValidate = await this.api.ValidationToken(token.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    ViewBag.Id = token.Id;
                    ViewBag.Token = token.Token;
                    ViewBag.Nombre = token.Nombre;
                    ViewData["Usuario"] = token.Usuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest();
            }
        }

        public async Task<IActionResult> VistaControl()
        {
            var token = this.CookieGet();
            if (token != null)
            {
                var tokenValidate = await this.api.ValidationToken(token.Token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if ((bool)tokenValidate.data == true)
                {
                    ViewBag.Id = token.Id;
                    ViewBag.Token = token.Token;
                    ViewBag.Nombre = token.Nombre;
                    ViewData["Usuario"] = token.Usuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest();
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