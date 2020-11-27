using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Aulas
    {
        public int IdAula { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el Aula")]
        public string DescripcionAula { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdEdificioFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Edificios IdEdificioFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
