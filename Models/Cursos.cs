using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Cursosasignaturas = new HashSet<Cursosasignaturas>();
            Estudiantescursos = new HashSet<Estudiantescursos>();
        }

        public int IdCurso { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el curso")]
        public string DescripcionCurso { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el tiempo del curso")]
        public decimal TiempoCurso { get; set; }

        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public ICollection<Cursosasignaturas> Cursosasignaturas { get; set; }
        public ICollection<Estudiantescursos> Estudiantescursos { get; set; }
    }
}
