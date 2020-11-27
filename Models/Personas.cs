using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Personas
    {
        public Personas()
        {
            Actanacimiento = new HashSet<Actanacimiento>();
            Archivos = new HashSet<Archivos>();
            Conductaobservaciones = new HashSet<Conductaobservaciones>();
            Cuentas = new HashSet<Cuentas>();
            Empleados = new HashSet<Empleados>();
            Estudiantes = new HashSet<Estudiantes>();
            Personascorreos = new HashSet<Personascorreos>();
            Personastelefonos = new HashSet<Personastelefonos>();
            RelacionesIdPersonaFkNavigation = new HashSet<Relaciones>();
            RelacionesIdPersonaRelacionFkNavigation = new HashSet<Relaciones>();
            Responsabilidadobservaciones = new HashSet<Responsabilidadobservaciones>();
            Saludobservaciones = new HashSet<Saludobservaciones>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el nombre")]
        public string NombrePersonas { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el apellido")]
        public string ApellidoPersonas { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la fecha de nacimiento")]
        public DateTime FechaNacimientoPersona { get; set; }
        public int IdDireccionFk { get; set; }
        public int IdSexoFk { get; set; }
        public string NacionalidadPaisFk { get; set; }

        public Direcciones IdDireccionFkNavigation { get; set; }
        public Sexos IdSexoFkNavigation { get; set; }
        public Paises NacionalidadPaisFkNavigation { get; set; }
        public ICollection<Actanacimiento> Actanacimiento { get; set; }
        public ICollection<Archivos> Archivos { get; set; }
        public ICollection<Conductaobservaciones> Conductaobservaciones { get; set; }
        public ICollection<Cuentas> Cuentas { get; set; }
        public ICollection<Empleados> Empleados { get; set; }
        public ICollection<Estudiantes> Estudiantes { get; set; }
        public ICollection<Personascorreos> Personascorreos { get; set; }
        public ICollection<Personastelefonos> Personastelefonos { get; set; }
        public ICollection<Relaciones> RelacionesIdPersonaFkNavigation { get; set; }
        public ICollection<Relaciones> RelacionesIdPersonaRelacionFkNavigation { get; set; }
        public ICollection<Responsabilidadobservaciones> Responsabilidadobservaciones { get; set; }
        public ICollection<Saludobservaciones> Saludobservaciones { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
