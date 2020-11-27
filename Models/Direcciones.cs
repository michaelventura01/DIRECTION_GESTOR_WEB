using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Direcciones
    {
        public Direcciones()
        {
            Edificios = new HashSet<Edificios>();
            Personas = new HashSet<Personas>();
        }

        public int IdDireccion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la direccion")]
        public string DescripcionDireccion { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdBarrioFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Barrios IdBarrioFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public ICollection<Edificios> Edificios { get; set; }
        public ICollection<Personas> Personas { get; set; }
    }
}
