using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Mensajes
    {
        public int IdMensaje { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el titulo")]
        public string TituloMensaje { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionMensaje { get; set; }
        public int IdUsuarioEmisorFk { get; set; }
        public int IdUsuarioReceptorFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Usuarios IdUsuarioEmisorFkNavigation { get; set; }
        public Usuarios IdUsuarioReceptorFkNavigation { get; set; }
    }
}
