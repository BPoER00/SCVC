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
        public int CUI { get; set; }
        public int IdDireccionFK { get; set; }
        public int IdGeneroFK { get; set; }
        public int IdEtniasFK { get; set; }
        public int IdEdadesFK { get; set; }
        public int IdRolFK { get; set; }
        public int Estatus { get; set; }

        //llaves Foraneas
        public virtual Direcciones Direcciones { get; set; }
        public virtual Generos Generos { get; set; }
        public virtual Etnias Etnias { get; set; }
        public virtual Edades Edades { get; set; }
        public virtual Roles Roles { get; set; }
    }
}