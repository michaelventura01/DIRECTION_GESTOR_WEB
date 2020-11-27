using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Estudiantesinstituciones
    {
        public int IdEmpleadoInstitucion { get; set; }
        public string CodigoEstudianteFk { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaInicio { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estudiantes CodigoEstudianteFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
    }
}
