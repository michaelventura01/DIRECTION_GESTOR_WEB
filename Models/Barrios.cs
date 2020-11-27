using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Barrios
    {
        public Barrios()
        {
            Direcciones = new HashSet<Direcciones>();
        }

        public int IdBarrio { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Barrio")]
        public string DescripcionBarrio { get; set; }
        public int IdEstadoFk { get; set; }
        public string IdCiudadFk { get; set; }

        public Ciudades IdCiudadFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Direcciones> Direcciones { get; set; }
    }
}
