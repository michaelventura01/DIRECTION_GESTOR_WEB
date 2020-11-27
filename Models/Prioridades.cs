using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Prioridades
    {
        public Prioridades()
        {
            Tareas = new HashSet<Tareas>();
        }

        public int IdPrioridad { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la prioridad")]
        public string DescripcionPrioridad { get; set; }

        public ICollection<Tareas> Tareas { get; set; }
    }
}
