using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIRECTION_GESTOR.Models
{
    public partial class Instituciones
    {
        public Instituciones()
        {
            Actanacimiento = new HashSet<Actanacimiento>();
            Articulos = new HashSet<Articulos>();
            Asignaturas = new HashSet<Asignaturas>();
            Aulas = new HashSet<Aulas>();
            Calificaciones = new HashSet<Calificaciones>();
            Conductaobservaciones = new HashSet<Conductaobservaciones>();
            Correos = new HashSet<Correos>();
            Cuentas = new HashSet<Cuentas>();
            Cursos = new HashSet<Cursos>();
            Direcciones = new HashSet<Direcciones>();
            Documentos = new HashSet<Documentos>();
            Edificios = new HashSet<Edificios>();
            Empleadosinstituciones = new HashSet<Empleadosinstituciones>();
            Enlaces = new HashSet<Enlaces>();
            Estudiantesinstituciones = new HashSet<Estudiantesinstituciones>();
            Institucionesarchivos = new HashSet<Institucionesarchivos>();
            Institucionescorreos = new HashSet<Institucionescorreos>();
            Institucionestelefonos = new HashSet<Institucionestelefonos>();
            Mensajes = new HashSet<Mensajes>();
            Movimientos = new HashSet<Movimientos>();
            Saludobservaciones = new HashSet<Saludobservaciones>();
            Tareas = new HashSet<Tareas>();
            Telefonos = new HashSet<Telefonos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdInstitucion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar el nombre de la institucion")]
        public string NombreInstitucion { get; set; }

        [Required(ErrorMessage = "Debes Suministrar la descripcion")]
        public string DescripcionInstitucion { get; set; }
        public int IdEstadoFk { get; set; }

        public Estados IdEstadoFkNavigation { get; set; }
        public ICollection<Actanacimiento> Actanacimiento { get; set; }
        public ICollection<Articulos> Articulos { get; set; }
        public ICollection<Asignaturas> Asignaturas { get; set; }
        public ICollection<Aulas> Aulas { get; set; }
        public ICollection<Calificaciones> Calificaciones { get; set; }
        public ICollection<Conductaobservaciones> Conductaobservaciones { get; set; }
        public ICollection<Correos> Correos { get; set; }
        public ICollection<Cuentas> Cuentas { get; set; }
        public ICollection<Cursos> Cursos { get; set; }
        public ICollection<Direcciones> Direcciones { get; set; }
        public ICollection<Documentos> Documentos { get; set; }
        public ICollection<Edificios> Edificios { get; set; }
        public ICollection<Empleadosinstituciones> Empleadosinstituciones { get; set; }
        public ICollection<Enlaces> Enlaces { get; set; }
        public ICollection<Estudiantesinstituciones> Estudiantesinstituciones { get; set; }
        public ICollection<Institucionesarchivos> Institucionesarchivos { get; set; }
        public ICollection<Institucionescorreos> Institucionescorreos { get; set; }
        public ICollection<Institucionestelefonos> Institucionestelefonos { get; set; }
        public ICollection<Mensajes> Mensajes { get; set; }
        public ICollection<Movimientos> Movimientos { get; set; }
        public ICollection<Saludobservaciones> Saludobservaciones { get; set; }
        public ICollection<Tareas> Tareas { get; set; }
        public ICollection<Telefonos> Telefonos { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
