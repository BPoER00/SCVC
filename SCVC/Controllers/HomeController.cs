using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCVC.Api;
using SCVC.Models;

namespace SCVC.Controllers
{
    public class HomeController : Controller
    {

        private ApiService api = new ApiService();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Creditos()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var token = this.CookieGet();
            if(token != null)
            {   
                var tokenValidate = await this.api.ValidationToken(token, "https://apiscvc.azurewebsites.net/WeatherForecast/");
                if((bool) tokenValidate.data == true)
                {
                    ViewBag.Token = token;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "<script>alert(Error Token Invalido)</script>");
                }
            }
            else
            {
                ViewBag.Token = "Error Al Crear El Token";
                return BadRequest();
            }
        }

        public async Task<IActionResult> LoginGuardar(LoginVM login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var dato = await api.GetToken("https://apiscvc.azurewebsites.net/Login/Post/", login);
                if(dato.result == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    this.CookieSet((string) dato.data);
                    return RedirectToAction("Privacy");
                }    
            }
        }

        public void CookieSet(string dato)
        {
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddHours(8);
            Response.Cookies.Append("Token", dato, options);    
        }

        public string CookieGet()
        {
            if(Request.Cookies["Token"] != null)
            {
                return Request.Cookies["Token"];
            }
            else
            {
                return null;
            }

        }

        public IActionResult CookieDelete()
        {
            if(Request.Cookies["Token"] != null)
            {
                Response.Cookies.Delete("Token");
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}