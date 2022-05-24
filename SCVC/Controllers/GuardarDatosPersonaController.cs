using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCVC.Api;
using SCVC.Models;

namespace SCVC.Controllers
{
    public class GuardarDatosPersonaController : Controller  {
        
        private ApiService Api;
        public GuardarDatosPersonaController()
        {
            this.Api = new ApiService();
        }

        public async Task<IActionResult> GuardarPersona(PersonasViewModel persona)
        {
            if(!ModelState.IsValid)
            {               
                return BadRequest();
            }
            else
            {
                try
                {
                    Persona DatosPersona = new Persona();
                    DatosPersona.NombrePersona = persona.NombrePersona;
                    DatosPersona.cui = int.Parse(persona.CUI);
                    DatosPersona.idDireccion = int.Parse(persona.IdDireccionFK);
                    DatosPersona.idGenero = int.Parse(persona.IdGeneroFK);
                    DatosPersona.idEtnia = int.Parse(persona.IdEtniasFK);
                    DatosPersona.idEdad = 1;
                    DatosPersona.idRol = int.Parse(persona.IdRolFK);
                    DatosPersona.estatus = 1;
                    DatosPersona.Fecha_Nacimiento = persona.Fecha_Nacimiento;

                    this.CookieSet(persona.Token, persona.usuario);
                    var resultado = await this.Api.Post<Persona>(DatosPersona, "https://apiscvc.azurewebsites.net/Persona/Post/", persona.Token);
                    return RedirectToAction("MenuPrincipal", "Opciones");
                }catch(Exception Ex)
                {
                    return BadRequest($"Error: {Ex.Message}");
                }
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