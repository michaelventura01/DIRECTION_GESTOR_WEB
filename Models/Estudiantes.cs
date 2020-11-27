using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Estudiantes
    {
        public Estudiantes()
        {
            Asignaturasempleadosestudiantes = new HashSet<Asignaturasempleadosestudiantes>();
            Estudiantescursos = new HashSet<Estudiantescursos>();
            Estudiantesinstituciones = new HashSet<Estudiantesinstituciones>();
        }

        [Required(ErrorMessage = "Debes Suministrar el codigo del estudiante")]
        public string CodigoEstudiante { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Personas IdPersonaFkNavigation { get; set; }
        public ICollection<Asignaturasempleadosestudiantes> Asignaturasempleadosestudiantes { get; set; }
        public ICollection<Estudiantescursos> Estudiantescursos { get; set; }
        public ICollection<Estudiantesinstituciones> Estudiantesinstituciones { get; set; }
    }
}
