using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Tareas
    {
        public int IdTarea { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el titulo")]
        public string TituloTarea { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la tarea")]
        public string DescripcionTarea { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha")]
        public DateTime FechaTarea { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la hora")]
        public TimeSpan HoraTarea { get; set; }
        public int IdEstadoFk { get; set; }
        public int IdPrioridadFk { get; set; }
        public int IdInstitucionFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public Instituciones IdInstitucionFkNavigation { get; set; }
        public Prioridades IdPrioridadFkNavigation { get; set; }
    }
}
