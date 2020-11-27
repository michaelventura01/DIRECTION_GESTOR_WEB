using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Asignaturas
    {
        public Asignaturas()
        {
            Cursosasignaturas = new HashSet<Cursosasignaturas>();
        }

        public string IdAsignatura { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el nombre de la Asignatura")]
        public string DescripcionAsignatura { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public ICollection<Cursosasignaturas> Cursosasignaturas { get; set; }
    }
}
