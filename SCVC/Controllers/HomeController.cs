using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCVC.Api;
using SCVC.Models;

namespace SCVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Creditos()
        {
            return View();
        }

        public IActionResult Privacy(object dato)
        {
            if(dato != null)
            {
                return View();
            }
            return BadRequest();
        }

        public async Task<IActionResult> LoginGuardar(LoginVM login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                ApiService api = new ApiService();
                var dato = await api.GetToken("https://apiscvc.azurewebsites.net/Login/Post/", login);
                this.Privacy(dato.data);
                return RedirectToAction("Privacy");
            }
        }
    }
}
