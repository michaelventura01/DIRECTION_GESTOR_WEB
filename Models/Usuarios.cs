using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            MensajesIdUsuarioEmisorFkNavigation = new HashSet<Mensajes>();
            MensajesIdUsuarioReceptorFkNavigation = new HashSet<Mensajes>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el usuario")]
        public string NameUsuario { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la contraseña")]
        public string PasswordUsuario { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdRolFk { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
        public Roles IdRolFkNavigation { get; set; }
        public ICollection<Mensajes> MensajesIdUsuarioEmisorFkNavigation { get; set; }
        public ICollection<Mensajes> MensajesIdUsuarioReceptorFkNavigation { get; set; }
    }
}
