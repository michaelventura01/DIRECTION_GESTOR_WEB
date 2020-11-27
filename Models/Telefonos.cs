using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Telefonos
    {
        public Telefonos()
        {
            Institucionestelefonos = new HashSet<Institucionestelefonos>();
            Personastelefonos = new HashSet<Personastelefonos>();
        }

        public int IdTelefono { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el telefono")]
        [Phone]
        public string DescripcionTelefono { get; set; }
        public int IdTipoTelefonoFk { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Tipotelefonos IdTipoTelefonoFkNavigation { get; set; }
        public ICollection<Institucionestelefonos> Institucionestelefonos { get; set; }
        public ICollection<Personastelefonos> Personastelefonos { get; set; }
    }
}
