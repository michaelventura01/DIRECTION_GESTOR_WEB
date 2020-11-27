using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Paises
    {
        public Paises()
        {
            Ciudades = new HashSet<Ciudades>();
            Personas = new HashSet<Personas>();
        }

        public string IdPais { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionPais { get; set; }
        public int IdEstadoFk { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la nacionalidad")]
        public string Nacionalidad { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Ciudades> Ciudades { get; set; }
        public ICollection<Personas> Personas { get; set; }
    }
}
