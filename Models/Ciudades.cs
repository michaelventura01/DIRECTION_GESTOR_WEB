using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            Barrios = new HashSet<Barrios>();
        }

        public string IdCiudad { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Nombre de la Ciudad")]
        public string DescripcionCiudad { get; set; }
        public int IdEstadoFk { get; set; }
        public string IdPaisFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Paises IdPaisFkNavigation { get; set; }
        public ICollection<Barrios> Barrios { get; set; }
    }
}
