using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Institucionescorreos
    {
        public int IdInstitucionCorreo { get; set; }
        public int IdInstitucionFk { get; set; }
        public int IdCorreoFk { get; set; }
        public int IdEstadoFk { get; set; }

        public Correos IdCorreoFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
