using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCVC.Models
{
    [Table("TBL_Persona")]
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El Campo Nombre Persona Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public string NombrePersona { get; set; }

        [Required(ErrorMessage = "El Campo CUI Persona Es Necesario")]
        [StringLength(13, ErrorMessage = "El Campo No Puede Ser Mayor a 13")]
        public int cui { get; set; }

        [Required(ErrorMessage = "El Campo Dirección Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int idDireccion { get; set; }

        [Required(ErrorMessage = "El Campo Genero Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int idGenero { get; set; }

        [Required(ErrorMessage = "El Campo Etnias Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int idEtnia { get; set; }

        public int idEdad { get; set; }

        [Required(ErrorMessage = "El Campo Rol Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        public int idRol { get; set; }
        public int estatus { get; set; }
        
        [Required(ErrorMessage = "El Campo Fecha Es Necesario")]
        [StringLength(100, ErrorMessage = "El Campo No Puede Ser Mayor A 100")]
        [DataType(DataType.DateTime, ErrorMessage = "El campo fecha es obligatorio ")]
        public string Fecha_Nacimiento { get; set; }

        //llaves Foraneas
        public virtual Direcciones Direcciones { get; set; }
        public virtual Generos Generos { get; set; }
        public virtual Etnias Etnias { get; set; }
        public virtual Edades Edades { get; set; }
        public virtual Roles Roles { get; set; }
    }
}