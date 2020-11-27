using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Edificios
    {
        public Edificios()
        {
            Aulas = new HashSet<Aulas>();
        }

        public int IdEdificio { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Edificio")]
        public string DescripcionEdificio { get; set; }

        public int IdEstadoFk { get; set; }
        public int IdDireccionFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Direcciones IdDireccionFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public ICollection<Aulas> Aulas { get; set; }
    }
}
