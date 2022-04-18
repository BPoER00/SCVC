using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                    this.CookieSet((string)dato.data, login.Usuario);
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
                    ViewBag.Token = token.Token;
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

        public void CookieSet(string dato, string Nombre)
        {
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Append("Token", dato, options);

            options.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Append("Usuario", Nombre, options);
        }

        public DatosUsuarios CookieGet()
        {
            if (Request.Cookies["Token"] != null)
            {
                string Token = Request.Cookies["Token"];
                string Usuario = Request.Cookies["Usuario"];

                return new DatosUsuarios()
                {
                    Token = Token,
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
                Response.Cookies.Delete("Token");
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