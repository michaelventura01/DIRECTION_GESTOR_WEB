using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Enlaces = new HashSet<Enlaces>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdRol { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionRol { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Enlaces> Enlaces { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
