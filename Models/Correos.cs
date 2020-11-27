using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Correos
    {
        public Correos()
        {
            Institucionescorreos = new HashSet<Institucionescorreos>();
            Personascorreos = new HashSet<Personascorreos>();
        }

        public int IdCorreo { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el correo")]
        [EmailAddress]
        public string DescripcionCorreo { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public ICollection<Institucionescorreos> Institucionescorreos { get; set; }
        public ICollection<Personascorreos> Personascorreos { get; set; }
    }
}
