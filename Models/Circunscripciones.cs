using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Circunscripciones
    {
        public Circunscripciones()
        {
            Actanacimiento = new HashSet<Actanacimiento>();
        }

        public int IdCircunscripcion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la circunscripcion")]
        public string DescripcionCircunscripcion { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Actanacimiento> Actanacimiento { get; set; }
    }
}
