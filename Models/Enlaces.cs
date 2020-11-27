using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Enlaces
    {
        public int IdEnlace { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionEnlace { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el enlace")]
        public string UrlEnlace { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdRolFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Roles IdRolFkNavigation { get; set; }
    }
}
