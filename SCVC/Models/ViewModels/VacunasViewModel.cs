using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    public class VacunasViewModel 
    {
        [Required(ErrorMessage = "El Campo Paciente Es Necesario")]
        public int IdPersona { get; set; }
        
        [Required(ErrorMessage = "El Campo Responsable Es Necesario")]
        public int IdEnfermero { get; set; }
        
        [Required(ErrorMessage = "El Campo Vacuna  Es Necesario")]
        public int IdVacuna { get; set; }
        
        [Required(ErrorMessage = "El Campo Dosis Es Necesario")]
        public int Dosis { get; set; }
        
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        public DateTime Fecha_COMMIT { get; set; }
        
        [Required(ErrorMessage = "El Campo Ususario Es Necesario")]
        public int IdUsuario { get; set; }
    }
}