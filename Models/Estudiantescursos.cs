using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Estudiantescursos
    {
        public int IdEstudianteCurso { get; set; }
        public string CodigoEstudianteFk { get; set; }
        public int IdCursoFk { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaEstudianteCurso { get; set; }

        public Estudiantes CodigoEstudianteFkNavigation { get; set; }
        public Cursos IdCursoFkNavigation { get; set; }
    }
}
