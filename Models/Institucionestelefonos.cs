using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Institucionestelefonos
    {
        public int IdInstitucionTelefono { get; set; }
        public int IdInstitucionFk { get; set; }
        public int IdTelefonoFk { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Telefonos IdTelefonoFkNavigation { get; set; }
    }
}
