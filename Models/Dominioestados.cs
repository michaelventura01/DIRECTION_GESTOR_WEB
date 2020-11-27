using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Dominioestados
    {
        public Dominioestados()
        {
            Estados = new HashSet<Estados>();
        }

        public int IdDominioEstado { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el dominio del estado")]
        public string DescripcionDominioEstado { get; set; }

        public ICollection<Estados> Estados { get; set; }
    }
}
