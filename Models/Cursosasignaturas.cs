using System;
using System.Collections.Generic;

namespace DIRECTION_GESTOR.Models
{
    public partial class Cursosasignaturas
    {
        public int IdCursoAsignatura { get; set; }
        public string IdAsignaturaFk { get; set; }
        public int IdCursoFk { get; set; }
        public int IdEstadoFk { get; set; }

        public Asignaturas IdAsignaturaFkNavigation { get; set; }
        public Cursos IdCursoFkNavigation { get; set; }
        public Estados IdEstadoFkNavigation { get; set; }
    }
}
