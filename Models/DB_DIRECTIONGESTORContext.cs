using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DIRECTION_GESTOR.Models
{
    public partial class DB_DIRECTIONGESTORContext : DbContext
    {
        public DB_DIRECTIONGESTORContext()
        {
        }

        public DB_DIRECTIONGESTORContext(DbContextOptions<DB_DIRECTIONGESTORContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actanacimiento> Actanacimiento { get; set; }
        public virtual DbSet<Archivos> Archivos { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Asignaturas> Asignaturas { get; set; }
        public virtual DbSet<Asignaturasempleados> Asignaturasempleados { get; set; }
        public virtual DbSet<Asignaturasempleadosestudiantes> Asignaturasempleadosestudiantes { get; set; }
        public virtual DbSet<Aulas> Aulas { get; set; }
        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }
        public virtual DbSet<Circunscripciones> Circunscripciones { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Conductaobservaciones> Conductaobservaciones { get; set; }
        public virtual DbSet<Correos> Correos { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Cursosasignaturas> Cursosasignaturas { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Dominioestados> Dominioestados { get; set; }
        public virtual DbSet<Edificios> Edificios { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Empleadosinstituciones> Empleadosinstituciones { get; set; }
        public virtual DbSet<Enlaces> Enlaces { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Estudiantescursos> Estudiantescursos { get; set; }
        public virtual DbSet<Estudiantesinstituciones> Estudiantesinstituciones { get; set; }
        public virtual DbSet<Instituciones> Instituciones { get; set; }
        public virtual DbSet<Institucionesarchivos> Institucionesarchivos { get; set; }
        public virtual DbSet<Institucionescorreos> Institucionescorreos { get; set; }
        public virtual DbSet<Institucionestelefonos> Institucionestelefonos { get; set; }
        public virtual DbSet<Mensajes> Mensajes { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Periodos> Periodos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Personascorreos> Personascorreos { get; set; }
        public virtual DbSet<Personastelefonos> Personastelefonos { get; set; }
        public virtual DbSet<Prioridades> Prioridades { get; set; }
        public virtual DbSet<Puestostrabajos> Puestostrabajos { get; set; }
        public virtual DbSet<Relaciones> Relaciones { get; set; }
        public virtual DbSet<Responsabilidadobservaciones> Responsabilidadobservaciones { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Saludobservaciones> Saludobservaciones { get; set; }
        public virtual DbSet<Sexos> Sexos { get; set; }
        public virtual DbSet<Tareas> Tareas { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
        public virtual DbSet<Tipocuentas> Tipocuentas { get; set; }
        public virtual DbSet<Tipodocumentos> Tipodocumentos { get; set; }
        public virtual DbSet<Tiposarchivos> Tiposarchivos { get; set; }
        public virtual DbSet<Tiposrelaciones> Tiposrelaciones { get; set; }
        public virtual DbSet<Tipotelefonos> Tipotelefonos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-3HLIAOT8;DataBase=DB_DIRECTIONGESTOR;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actanacimiento>(entity =>
            {
                entity.HasKey(e => e.IdActaNacimiento);

                entity.ToTable("ACTANACIMIENTO");

                entity.Property(e => e.IdActaNacimiento).HasColumnName("idActaNacimiento");

                entity.Property(e => e.AnioActaNacimiento)
                    .IsRequired()
                    .HasColumnName("anioActaNacimiento")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FolioActaNacimiento)
                    .IsRequired()
                    .HasColumnName("folioActaNacimiento")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdCircunscripcionFk).HasColumnName("idCircunscripcionFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.Property(e => e.LibroActaNacimiento)
                    .IsRequired()
                    .HasColumnName("libroActaNacimiento")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroActaNacimiento)
                    .IsRequired()
                    .HasColumnName("numeroActaNacimiento")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCircunscripcionFkNavigation)
                    .WithMany(p => p.Actanacimiento)
                    .HasForeignKey(d => d.IdCircunscripcionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACTANACIM__idCir__797309D9");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Actanacimiento)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACTANACIM__idEst__787EE5A0");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Actanacimiento)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACTANACIM__idIns__4D5F7D71");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Actanacimiento)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ACTANACIM__idPer__778AC167");
            });

            modelBuilder.Entity<Archivos>(entity =>
            {
                entity.HasKey(e => e.IdArchivo);

                entity.ToTable("ARCHIVOS");

                entity.Property(e => e.IdArchivo).HasColumnName("idArchivo");

                entity.Property(e => e.EnlaceArchivo)
                    .IsRequired()
                    .HasColumnName("enlaceArchivo")
                    .HasColumnType("text");

                entity.Property(e => e.FechaArchivo)
                    .HasColumnName("fechaArchivo")
                    .HasColumnType("date");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.Property(e => e.IdTipoArchivoFk).HasColumnName("idTipoArchivoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ARCHIVOS__idEsta__6A30C649");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ARCHIVOS__idPers__76619304");

                entity.HasOne(d => d.IdTipoArchivoFkNavigation)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdTipoArchivoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ARCHIVOS__idTipo__693CA210");
            });

            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.HasKey(e => e.IdArticulo);

                entity.ToTable("ARTICULOS");

                entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");

                entity.Property(e => e.CantidadArticulo)
                    .HasColumnName("cantidadArticulo")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CodigoArticulo)
                    .IsRequired()
                    .HasColumnName("codigoArticulo")
                    .HasColumnType("text");

                entity.Property(e => e.DescripcionArticulo)
                    .IsRequired()
                    .HasColumnName("descripcionArticulo")
                    .HasColumnType("text");

                entity.Property(e => e.FechaArticulo)
                    .IsRequired()
                    .HasColumnName("fechaArticulo")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.PrecioArticulo)
                    .HasColumnName("precioArticulo")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ARTICULOS__idEst__2A164134");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ARTICULOS__idIns__5CA1C101");
            });

            modelBuilder.Entity<Asignaturas>(entity =>
            {
                entity.HasKey(e => e.IdAsignatura);

                entity.ToTable("ASIGNATURAS");

                entity.Property(e => e.IdAsignatura)
                    .HasColumnName("idAsignatura")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DescripcionAsignatura)
                    .IsRequired()
                    .HasColumnName("descripcionAsignatura")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASIGNATUR__idEst__10566F31");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASIGNATUR__idIns__59C55456");
            });

            modelBuilder.Entity<Asignaturasempleados>(entity =>
            {
                entity.HasKey(e => e.IdAsignaturaEmpleado);

                entity.ToTable("ASIGNATURASEMPLEADOS");

                entity.Property(e => e.IdAsignaturaEmpleado).HasColumnName("idAsignaturaEmpleado");

                entity.Property(e => e.CodigoEmpleadoFk)
                    .HasColumnName("codigoEmpleadoFK")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.CodigoEmpleadoFkNavigation)
                    .WithMany(p => p.Asignaturasempleados)
                    .HasForeignKey(d => d.CodigoEmpleadoFk)
                    .HasConstraintName("FK__ASIGNATUR__codig__123EB7A3");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Asignaturasempleados)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASIGNATUR__idEst__1332DBDC");
            });

            modelBuilder.Entity<Asignaturasempleadosestudiantes>(entity =>
            {
                entity.HasKey(e => e.IdAsignaturaEmpleadoEstudiante);

                entity.ToTable("ASIGNATURASEMPLEADOSESTUDIANTES");

                entity.Property(e => e.IdAsignaturaEmpleadoEstudiante).HasColumnName("idAsignaturaEmpleadoEstudiante");

                entity.Property(e => e.CodigoEstudianteFk)
                    .IsRequired()
                    .HasColumnName("codigoEstudianteFK")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IdAsignaturaEmpleadoFk).HasColumnName("idAsignaturaEmpleadoFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdPeriodoFk).HasColumnName("idPeriodoFK");

                entity.HasOne(d => d.CodigoEstudianteFkNavigation)
                    .WithMany(p => p.Asignaturasempleadosestudiantes)
                    .HasForeignKey(d => d.CodigoEstudianteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASIGNATUR__codig__151B244E");

                entity.HasOne(d => d.IdAsignaturaEmpleadoFkNavigation)
                    .WithMany(p => p.Asignaturasempleadosestudiantes)
                    .HasForeignKey(d => d.IdAsignaturaEmpleadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASIGNATUR__idAsi__14270015");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Asignaturasempleadosestudiantes)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASIGNATUR__idEst__160F4887");

                entity.HasOne(d => d.IdPeriodoFkNavigation)
                    .WithMany(p => p.Asignaturasempleadosestudiantes)
                    .HasForeignKey(d => d.IdPeriodoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ASIGNATUR__idPer__17036CC0");
            });

            modelBuilder.Entity<Aulas>(entity =>
            {
                entity.HasKey(e => e.IdAula);

                entity.ToTable("AULAS");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.DescripcionAula)
                    .IsRequired()
                    .HasColumnName("descripcionAula")
                    .HasColumnType("text");

                entity.Property(e => e.IdEdificioFk).HasColumnName("idEdificioFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.IdEdificioFkNavigation)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.IdEdificioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AULAS__idEdifici__70DDC3D8");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AULAS__idEstadoF__6FE99F9F");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AULAS__idInstitu__55009F39");
            });

            modelBuilder.Entity<Barrios>(entity =>
            {
                entity.HasKey(e => e.IdBarrio);

                entity.ToTable("BARRIOS");

                entity.Property(e => e.IdBarrio).HasColumnName("idBarrio");

                entity.Property(e => e.DescripcionBarrio)
                    .IsRequired()
                    .HasColumnName("descripcionBarrio")
                    .HasColumnType("text");

                entity.Property(e => e.IdCiudadFk)
                    .IsRequired()
                    .HasColumnName("idCiudadFK")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdCiudadFkNavigation)
                    .WithMany(p => p.Barrios)
                    .HasForeignKey(d => d.IdCiudadFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BARRIOS__idCiuda__72C60C4A");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Barrios)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BARRIOS__idEstad__71D1E811");
            });

            modelBuilder.Entity<Calificaciones>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion);

                entity.ToTable("CALIFICACIONES");

                entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");

                entity.Property(e => e.Calificacion)
                    .HasColumnName("calificacion")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FechaCalificacion)
                    .HasColumnName("fechaCalificacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdAsignaturaEmpleadoEstudianteFk).HasColumnName("idAsignaturaEmpleadoEstudianteFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.IdAsignaturaEmpleadoEstudianteFkNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdAsignaturaEmpleadoEstudianteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CALIFICAC__idAsi__17F790F9");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CALIFICAC__idEst__18EBB532");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CALIFICAC__idIns__5AB9788F");
            });

            modelBuilder.Entity<Circunscripciones>(entity =>
            {
                entity.HasKey(e => e.IdCircunscripcion);

                entity.ToTable("CIRCUNSCRIPCIONES");

                entity.Property(e => e.IdCircunscripcion).HasColumnName("idCircunscripcion");

                entity.Property(e => e.DescripcionCircunscripcion)
                    .IsRequired()
                    .HasColumnName("descripcionCircunscripcion")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Circunscripciones)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CIRCUNSCR__idEst__76969D2E");
            });

            modelBuilder.Entity<Ciudades>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.ToTable("CIUDADES");

                entity.Property(e => e.IdCiudad)
                    .HasColumnName("idCiudad")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DescripcionCiudad)
                    .IsRequired()
                    .HasColumnName("descripcionCiudad")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdPaisFk)
                    .IsRequired()
                    .HasColumnName("idPaisFK")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CIUDADES__idEsta__73BA3083");

                entity.HasOne(d => d.IdPaisFkNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.IdPaisFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CIUDADES__idPais__74AE54BC");
            });

            modelBuilder.Entity<Conductaobservaciones>(entity =>
            {
                entity.HasKey(e => e.IdConductaObservacion);

                entity.ToTable("CONDUCTAOBSERVACIONES");

                entity.Property(e => e.IdConductaObservacion).HasColumnName("idConductaObservacion");

                entity.Property(e => e.DescripcionConductaObservacion)
                    .IsRequired()
                    .HasColumnName("descripcionConductaObservacion")
                    .HasColumnType("text");

                entity.Property(e => e.FechaConductaObservacion)
                    .HasColumnName("fechaConductaObservacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Conductaobservaciones)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONDUCTAO__idEst__69FBBC1F");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Conductaobservaciones)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONDUCTAO__idIns__74794A92");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Conductaobservaciones)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONDUCTAO__idPer__671F4F74");
            });

            modelBuilder.Entity<Correos>(entity =>
            {
                entity.HasKey(e => e.IdCorreo);

                entity.ToTable("CORREOS");

                entity.Property(e => e.IdCorreo).HasColumnName("idCorreo");

                entity.Property(e => e.DescripcionCorreo)
                    .IsRequired()
                    .HasColumnName("descripcionCorreo")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Correos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CORREOS__idEstad__02084FDA");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Correos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CORREOS__idInsti__4F47C5E3");
            });

            modelBuilder.Entity<Cuentas>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.ToTable("CUENTAS");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.DescripcionCuenta)
                    .IsRequired()
                    .HasColumnName("descripcionCuenta")
                    .HasColumnType("text");

                entity.Property(e => e.FechaCuenta)
                    .HasColumnName("fechaCuenta")
                    .HasColumnType("date");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.Property(e => e.IdTipoCuentaFk).HasColumnName("idTipoCuentaFK");

                entity.Property(e => e.MontoCuenta)
                    .HasColumnName("montoCuenta")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CUENTAS__idEstad__2CF2ADDF");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CUENTAS__idInsti__503BEA1C");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CUENTAS__idPerso__2BFE89A6");

                entity.HasOne(d => d.IdTipoCuentaFkNavigation)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.IdTipoCuentaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CUENTAS__idTipoC__2B0A656D");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.ToTable("CURSOS");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.DescripcionCurso)
                    .IsRequired()
                    .HasColumnName("descripcionCurso")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.TiempoCurso)
                    .HasColumnName("tiempoCurso")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOS__idEstado__06CD04F7");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOS__idInstit__56E8E7AB");
            });

            modelBuilder.Entity<Cursosasignaturas>(entity =>
            {
                entity.HasKey(e => e.IdCursoAsignatura);

                entity.ToTable("CURSOSASIGNATURAS");

                entity.Property(e => e.IdCursoAsignatura).HasColumnName("idCursoAsignatura");

                entity.Property(e => e.IdAsignaturaFk)
                    .IsRequired()
                    .HasColumnName("idAsignaturaFK")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdCursoFk).HasColumnName("idCursoFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdAsignaturaFkNavigation)
                    .WithMany(p => p.Cursosasignaturas)
                    .HasForeignKey(d => d.IdAsignaturaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOSASI__idAsi__09A971A2");

                entity.HasOne(d => d.IdCursoFkNavigation)
                    .WithMany(p => p.Cursosasignaturas)
                    .HasForeignKey(d => d.IdCursoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOSASI__idCur__0A9D95DB");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Cursosasignaturas)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOSASI__idEst__0F624AF8");
            });

            modelBuilder.Entity<Direcciones>(entity =>
            {
                entity.HasKey(e => e.IdDireccion);

                entity.ToTable("DIRECCIONES");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.DescripcionDireccion)
                    .IsRequired()
                    .HasColumnName("descripcionDireccion")
                    .HasColumnType("text");

                entity.Property(e => e.IdBarrioFk).HasColumnName("idBarrioFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.IdBarrioFkNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.IdBarrioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIRECCION__idBar__6D0D32F4");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIRECCION__idEst__6C190EBB");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIRECCION__idIns__58D1301D");
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("DOCUMENTOS");

                entity.Property(e => e.IdDocumento).HasColumnName("idDocumento");

                entity.Property(e => e.DescripcionDocumento)
                    .IsRequired()
                    .HasColumnName("descripcionDocumento")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdTipoDocumentoFk).HasColumnName("idTipoDocumentoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DOCUMENTO__idEst__7B5B524B");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DOCUMENTO__idIns__531856C7");

                entity.HasOne(d => d.IdTipoDocumentoFkNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdTipoDocumentoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DOCUMENTO__idTip__7A672E12");
            });

            modelBuilder.Entity<Dominioestados>(entity =>
            {
                entity.HasKey(e => e.IdDominioEstado);

                entity.ToTable("DOMINIOESTADOS");

                entity.Property(e => e.IdDominioEstado).HasColumnName("idDominioEstado");

                entity.Property(e => e.DescripcionDominioEstado)
                    .IsRequired()
                    .HasColumnName("descripcionDominioEstado")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Edificios>(entity =>
            {
                entity.HasKey(e => e.IdEdificio);

                entity.ToTable("EDIFICIOS");

                entity.Property(e => e.IdEdificio).HasColumnName("idEdificio");

                entity.Property(e => e.DescripcionEdificio)
                    .IsRequired()
                    .HasColumnName("descripcionEdificio")
                    .HasColumnType("text");

                entity.Property(e => e.IdDireccionFk).HasColumnName("idDireccionFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.IdDireccionFkNavigation)
                    .WithMany(p => p.Edificios)
                    .HasForeignKey(d => d.IdDireccionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EDIFICIOS__idDir__6EF57B66");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Edificios)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EDIFICIOS__idEst__6E01572D");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Edificios)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EDIFICIOS__idIns__540C7B00");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpleado);

                entity.ToTable("EMPLEADOS");

                entity.Property(e => e.CodigoEmpleado)
                    .HasColumnName("codigoEmpleado")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.Property(e => e.IdPuestoTrabajoFk).HasColumnName("idPuestoTrabajoFK");

                entity.Property(e => e.SueldoEmpleado)
                    .HasColumnName("sueldoEmpleado")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLEADOS__idEst__0D7A0286");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLEADOS__idPer__0C85DE4D");

                entity.HasOne(d => d.IdPuestoTrabajoFkNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdPuestoTrabajoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLEADOS__idPue__0E6E26BF");
            });

            modelBuilder.Entity<Empleadosinstituciones>(entity =>
            {
                entity.HasKey(e => e.IdEmpleadoInstitucion);

                entity.ToTable("EMPLEADOSINSTITUCIONES");

                entity.Property(e => e.IdEmpleadoInstitucion).HasColumnName("idEmpleadoInstitucion");

                entity.Property(e => e.CodigoEmpleadoFk)
                    .IsRequired()
                    .HasColumnName("codigoEmpleadoFK")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.CodigoEmpleadoFkNavigation)
                    .WithMany(p => p.Empleadosinstituciones)
                    .HasForeignKey(d => d.CodigoEmpleadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLEADOS__codig__1B9317B3");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Empleadosinstituciones)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLEADOS__idIns__1C873BEC");
            });

            modelBuilder.Entity<Enlaces>(entity =>
            {
                entity.HasKey(e => e.IdEnlace);

                entity.ToTable("ENLACES");

                entity.Property(e => e.IdEnlace).HasColumnName("idEnlace");

                entity.Property(e => e.DescripcionEnlace)
                    .IsRequired()
                    .HasColumnName("descripcionEnlace")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdRolFk).HasColumnName("idRolFK");

                entity.Property(e => e.UrlEnlace)
                    .IsRequired()
                    .HasColumnName("urlEnlace")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Enlaces)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ENLACES__idEstad__245D67DE");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Enlaces)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ENLACES__idInsti__5BAD9CC8");

                entity.HasOne(d => d.IdRolFkNavigation)
                    .WithMany(p => p.Enlaces)
                    .HasForeignKey(d => d.IdRolFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ENLACES__idRolFK__25518C17");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("ESTADOS");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.DescripcionEstado)
                    .IsRequired()
                    .HasColumnName("descripcionEstado")
                    .HasColumnType("text");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdDominioEstadoFk).HasColumnName("idDominioEstadoFK");

                entity.HasOne(d => d.IdDominioEstadoFkNavigation)
                    .WithMany(p => p.Estados)
                    .HasForeignKey(d => d.IdDominioEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTADOS__idDomin__6477ECF3");
            });

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.CodigoEstudiante);

                entity.ToTable("ESTUDIANTES");

                entity.Property(e => e.CodigoEstudiante)
                    .HasColumnName("codigoEstudiante")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__idEst__05D8E0BE");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__idPer__04E4BC85");
            });

            modelBuilder.Entity<Estudiantescursos>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteCurso);

                entity.ToTable("ESTUDIANTESCURSOS");

                entity.Property(e => e.IdEstudianteCurso).HasColumnName("idEstudianteCurso");

                entity.Property(e => e.CodigoEstudianteFk)
                    .HasColumnName("codigoEstudianteFK")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEstudianteCurso)
                    .HasColumnName("fechaEstudianteCurso")
                    .HasColumnType("date");

                entity.Property(e => e.IdCursoFk).HasColumnName("idCursoFK");

                entity.HasOne(d => d.CodigoEstudianteFkNavigation)
                    .WithMany(p => p.Estudiantescursos)
                    .HasForeignKey(d => d.CodigoEstudianteFk)
                    .HasConstraintName("FK__ESTUDIANT__codig__07C12930");

                entity.HasOne(d => d.IdCursoFkNavigation)
                    .WithMany(p => p.Estudiantescursos)
                    .HasForeignKey(d => d.IdCursoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__idCur__08B54D69");
            });

            modelBuilder.Entity<Estudiantesinstituciones>(entity =>
            {
                entity.HasKey(e => e.IdEmpleadoInstitucion);

                entity.ToTable("ESTUDIANTESINSTITUCIONES");

                entity.Property(e => e.IdEmpleadoInstitucion).HasColumnName("idEmpleadoInstitucion");

                entity.Property(e => e.CodigoEstudianteFk)
                    .IsRequired()
                    .HasColumnName("codigoEstudianteFK")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.CodigoEstudianteFkNavigation)
                    .WithMany(p => p.Estudiantesinstituciones)
                    .HasForeignKey(d => d.CodigoEstudianteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__codig__1F63A897");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Estudiantesinstituciones)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__idIns__2057CCD0");
            });

            modelBuilder.Entity<Instituciones>(entity =>
            {
                entity.HasKey(e => e.IdInstitucion);

                entity.ToTable("INSTITUCIONES");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.Property(e => e.DescripcionInstitucion)
                    .IsRequired()
                    .HasColumnName("descripcionInstitucion")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.NombreInstitucion)
                    .IsRequired()
                    .HasColumnName("nombreInstitucion")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Instituciones)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idEst__1CBC4616");
            });

            modelBuilder.Entity<Institucionesarchivos>(entity =>
            {
                entity.HasKey(e => e.IdArchivo);

                entity.ToTable("INSTITUCIONESARCHIVOS");

                entity.Property(e => e.IdArchivo).HasColumnName("idArchivo");

                entity.Property(e => e.EnlaceArchivo)
                    .IsRequired()
                    .HasColumnName("enlaceArchivo")
                    .HasColumnType("text");

                entity.Property(e => e.FechaArchivo)
                    .HasColumnName("fechaArchivo")
                    .HasColumnType("date");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdTipoArchivoFk).HasColumnName("idTipoArchivoFK");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Institucionesarchivos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idIns__793DFFAF");
            });

            modelBuilder.Entity<Institucionescorreos>(entity =>
            {
                entity.HasKey(e => e.IdInstitucionCorreo);

                entity.ToTable("INSTITUCIONESCORREOS");

                entity.Property(e => e.IdInstitucionCorreo).HasColumnName("idInstitucionCorreo");

                entity.Property(e => e.IdCorreoFk).HasColumnName("idCorreoFK");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.HasOne(d => d.IdCorreoFkNavigation)
                    .WithMany(p => p.Institucionescorreos)
                    .HasForeignKey(d => d.IdCorreoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idCor__2180FB33");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Institucionescorreos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idEst__22751F6C");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Institucionescorreos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idIns__208CD6FA");
            });

            modelBuilder.Entity<Institucionestelefonos>(entity =>
            {
                entity.HasKey(e => e.IdInstitucionTelefono);

                entity.ToTable("INSTITUCIONESTELEFONOS");

                entity.Property(e => e.IdInstitucionTelefono).HasColumnName("idInstitucionTelefono");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdTelefonoFk).HasColumnName("idTelefonoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Institucionestelefonos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idEst__1F98B2C1");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Institucionestelefonos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idIns__1DB06A4F");

                entity.HasOne(d => d.IdTelefonoFkNavigation)
                    .WithMany(p => p.Institucionestelefonos)
                    .HasForeignKey(d => d.IdTelefonoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INSTITUCI__idTel__1EA48E88");
            });

            modelBuilder.Entity<Mensajes>(entity =>
            {
                entity.HasKey(e => e.IdMensaje);

                entity.ToTable("MENSAJES");

                entity.Property(e => e.IdMensaje).HasColumnName("idMensaje");

                entity.Property(e => e.DescripcionMensaje)
                    .IsRequired()
                    .HasColumnName("descripcionMensaje")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdUsuarioEmisorFk).HasColumnName("idUsuarioEmisorFK");

                entity.Property(e => e.IdUsuarioReceptorFk).HasColumnName("idUsuarioReceptorFK");

                entity.Property(e => e.TituloMensaje)
                    .IsRequired()
                    .HasColumnName("tituloMensaje")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MENSAJES__idEsta__29221CFB");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MENSAJES__idInst__5E8A0973");

                entity.HasOne(d => d.IdUsuarioEmisorFkNavigation)
                    .WithMany(p => p.MensajesIdUsuarioEmisorFkNavigation)
                    .HasForeignKey(d => d.IdUsuarioEmisorFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MENSAJES__idUsua__2739D489");

                entity.HasOne(d => d.IdUsuarioReceptorFkNavigation)
                    .WithMany(p => p.MensajesIdUsuarioReceptorFkNavigation)
                    .HasForeignKey(d => d.IdUsuarioReceptorFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MENSAJES__idUsua__282DF8C2");
            });

            modelBuilder.Entity<Movimientos>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("MOVIMIENTOS");

                entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");

                entity.Property(e => e.DescripcionMovimiento)
                    .IsRequired()
                    .HasColumnName("descripcionMovimiento")
                    .HasColumnType("text");

                entity.Property(e => e.FechaMovimiento)
                    .HasColumnName("fechaMovimiento")
                    .HasColumnType("date");

                entity.Property(e => e.HoraMovimiento).HasColumnName("horaMovimiento");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdTipoMovimiento).HasColumnName("idTipoMovimiento");

                entity.Property(e => e.MontoMovimiento)
                    .HasColumnName("montoMovimiento")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MOVIMIENT__idEst__2EDAF651");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MOVIMIENT__idIns__5F7E2DAC");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.ToTable("PAISES");

                entity.Property(e => e.IdPais)
                    .HasColumnName("idPais")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DescripcionPais)
                    .IsRequired()
                    .HasColumnName("descripcionPais")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasColumnName("nacionalidad")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Paises)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PAISES__idEstado__75A278F5");
            });

            modelBuilder.Entity<Periodos>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo);

                entity.ToTable("PERIODOS");

                entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");

                entity.Property(e => e.DescripcionPeriodo)
                    .IsRequired()
                    .HasColumnName("descripcionPeriodo")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Periodos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERIODOS__idEsta__114A936A");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("PERSONAS");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.ApellidoPersonas)
                    .IsRequired()
                    .HasColumnName("apellidoPersonas")
                    .HasColumnType("text");

                entity.Property(e => e.FechaNacimientoPersona)
                    .HasColumnName("fechaNacimientoPersona")
                    .HasColumnType("date");

                entity.Property(e => e.IdDireccionFk).HasColumnName("idDireccionFK");

                entity.Property(e => e.IdSexoFk).HasColumnName("idSexoFK");

                entity.Property(e => e.NacionalidadPaisFk)
                    .IsRequired()
                    .HasColumnName("nacionalidadPaisFK")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePersonas)
                    .IsRequired()
                    .HasColumnName("nombrePersonas")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdDireccionFkNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdDireccionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONAS__idDire__656C112C");

                entity.HasOne(d => d.IdSexoFkNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdSexoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONAS__idSexo__0880433F");

                entity.HasOne(d => d.NacionalidadPaisFkNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.NacionalidadPaisFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONAS__nacion__2EA5EC27");
            });

            modelBuilder.Entity<Personascorreos>(entity =>
            {
                entity.HasKey(e => e.IdPersonaCorreo);

                entity.ToTable("PERSONASCORREOS");

                entity.Property(e => e.IdPersonaCorreo).HasColumnName("idPersonaCorreo");

                entity.Property(e => e.IdCorreoFk).HasColumnName("idCorreoFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.HasOne(d => d.IdCorreoFkNavigation)
                    .WithMany(p => p.Personascorreos)
                    .HasForeignKey(d => d.IdCorreoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONASC__idCor__03F0984C");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Personascorreos)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONASC__idPer__02FC7413");
            });

            modelBuilder.Entity<Personastelefonos>(entity =>
            {
                entity.HasKey(e => e.IdPersonaTelefono);

                entity.ToTable("PERSONASTELEFONOS");

                entity.Property(e => e.IdPersonaTelefono).HasColumnName("idPersonaTelefono");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.Property(e => e.IdTelefonoFk).HasColumnName("idTelefonoFK");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Personastelefonos)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONAST__idPer__00200768");

                entity.HasOne(d => d.IdTelefonoFkNavigation)
                    .WithMany(p => p.Personastelefonos)
                    .HasForeignKey(d => d.IdTelefonoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONAST__idTel__01142BA1");
            });

            modelBuilder.Entity<Prioridades>(entity =>
            {
                entity.HasKey(e => e.IdPrioridad);

                entity.ToTable("PRIORIDADES");

                entity.Property(e => e.IdPrioridad).HasColumnName("idPrioridad");

                entity.Property(e => e.DescripcionPrioridad)
                    .IsRequired()
                    .HasColumnName("descripcionPrioridad")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Puestostrabajos>(entity =>
            {
                entity.HasKey(e => e.IdPuestoTrabajo);

                entity.ToTable("PUESTOSTRABAJOS");

                entity.Property(e => e.IdPuestoTrabajo).HasColumnName("idPuestoTrabajo");

                entity.Property(e => e.DescripcionPuestoTrabajo)
                    .IsRequired()
                    .HasColumnName("descripcionPuestoTrabajo")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Relaciones>(entity =>
            {
                entity.HasKey(e => e.IdRelacion);

                entity.ToTable("RELACIONES");

                entity.Property(e => e.IdRelacion).HasColumnName("idRelacion");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.Property(e => e.IdPersonaRelacionFk).HasColumnName("idPersonaRelacionFK");

                entity.Property(e => e.IdTipoRelacionFk).HasColumnName("idTipoRelacionFK");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.RelacionesIdPersonaFkNavigation)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RELACIONE__idPer__66603565");

                entity.HasOne(d => d.IdPersonaRelacionFkNavigation)
                    .WithMany(p => p.RelacionesIdPersonaRelacionFkNavigation)
                    .HasForeignKey(d => d.IdPersonaRelacionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RELACIONE__idPer__6754599E");

                entity.HasOne(d => d.IdTipoRelacionFkNavigation)
                    .WithMany(p => p.Relaciones)
                    .HasForeignKey(d => d.IdTipoRelacionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RELACIONE__idTip__68487DD7");
            });

            modelBuilder.Entity<Responsabilidadobservaciones>(entity =>
            {
                entity.HasKey(e => e.IdResponsabilidadObservacion);

                entity.ToTable("RESPONSABILIDADOBSERVACIONES");

                entity.Property(e => e.IdResponsabilidadObservacion).HasColumnName("idResponsabilidadObservacion");

                entity.Property(e => e.DescripcionResponsabilidadObservacion)
                    .IsRequired()
                    .HasColumnName("descripcionResponsabilidadObservacion")
                    .HasColumnType("text");

                entity.Property(e => e.FechaResponsabilidadObservacion)
                    .HasColumnName("fechaResponsabilidadObservacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Responsabilidadobservaciones)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RESPONSAB__idEst__6AEFE058");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Responsabilidadobservaciones)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RESPONSAB__idPer__681373AD");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("ROLES");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.DescripcionRol)
                    .IsRequired()
                    .HasColumnName("descripcionRol")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ROLES__idEstadoF__236943A5");
            });

            modelBuilder.Entity<Saludobservaciones>(entity =>
            {
                entity.HasKey(e => e.IdSaludObservacion);

                entity.ToTable("SALUDOBSERVACIONES");

                entity.Property(e => e.IdSaludObservacion).HasColumnName("idSaludObservacion");

                entity.Property(e => e.DescripcionSaludObservacion)
                    .IsRequired()
                    .HasColumnName("descripcionSaludObservacion")
                    .HasColumnType("text");

                entity.Property(e => e.FechaSaludObservacion)
                    .HasColumnName("fechaSaludObservacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Saludobservaciones)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALUDOBSE__idEst__690797E6");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Saludobservaciones)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALUDOBSE__idIns__756D6ECB");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Saludobservaciones)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALUDOBSE__idPer__662B2B3B");
            });

            modelBuilder.Entity<Sexos>(entity =>
            {
                entity.HasKey(e => e.IdSexo);

                entity.ToTable("SEXOS");

                entity.Property(e => e.IdSexo).HasColumnName("idSexo");

                entity.Property(e => e.DescripcionSexo)
                    .IsRequired()
                    .HasColumnName("descripcionSexo")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Tareas>(entity =>
            {
                entity.HasKey(e => e.IdTarea);

                entity.ToTable("TAREAS");

                entity.Property(e => e.IdTarea).HasColumnName("idTarea");

                entity.Property(e => e.DescripcionTarea)
                    .IsRequired()
                    .HasColumnName("descripcionTarea")
                    .HasColumnType("text");

                entity.Property(e => e.FechaTarea)
                    .HasColumnName("fechaTarea")
                    .HasColumnType("date");

                entity.Property(e => e.HoraTarea).HasColumnName("horaTarea");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdPrioridadFk).HasColumnName("idPrioridadFK");

                entity.Property(e => e.TituloTarea)
                    .IsRequired()
                    .HasColumnName("tituloTarea")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TAREAS__idEstado__2645B050");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TAREAS__idInstit__57DD0BE4");

                entity.HasOne(d => d.IdPrioridadFkNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdPrioridadFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TAREAS__idPriori__40058253");
            });

            modelBuilder.Entity<Telefonos>(entity =>
            {
                entity.HasKey(e => e.IdTelefono);

                entity.ToTable("TELEFONOS");

                entity.Property(e => e.IdTelefono).HasColumnName("idTelefono");

                entity.Property(e => e.DescripcionTelefono)
                    .IsRequired()
                    .HasColumnName("descripcionTelefono")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdTipoTelefonoFk).HasColumnName("idTipoTelefonoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TELEFONOS__idEst__7E37BEF6");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TELEFONOS__idIns__4E53A1AA");

                entity.HasOne(d => d.IdTipoTelefonoFkNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.IdTipoTelefonoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TELEFONOS__idTip__7D439ABD");
            });

            modelBuilder.Entity<Tipocuentas>(entity =>
            {
                entity.HasKey(e => e.IdTipoCuenta);

                entity.ToTable("TIPOCUENTAS");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("idTipoCuenta");

                entity.Property(e => e.DescripcionTipoCuenta)
                    .IsRequired()
                    .HasColumnName("descripcionTipoCuenta")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Tipocuentas)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TIPOCUENT__idEst__2DE6D218");
            });

            modelBuilder.Entity<Tipodocumentos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.ToTable("TIPODOCUMENTOS");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.DescripcionTipoDocumento)
                    .IsRequired()
                    .HasColumnName("descripcionTipoDocumento")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Tipodocumentos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TIPODOCUM__idEst__7C4F7684");
            });

            modelBuilder.Entity<Tiposarchivos>(entity =>
            {
                entity.HasKey(e => e.IdTipoArchivo);

                entity.ToTable("TIPOSARCHIVOS");

                entity.Property(e => e.IdTipoArchivo).HasColumnName("idTipoArchivo");

                entity.Property(e => e.DescripcionTipoArchivo)
                    .IsRequired()
                    .HasColumnName("descripcionTipoArchivo")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.TerminalTipoArchivo)
                    .IsRequired()
                    .HasColumnName("terminalTipoArchivo")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Tiposarchivos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TIPOSARCH__idEst__6B24EA82");
            });

            modelBuilder.Entity<Tiposrelaciones>(entity =>
            {
                entity.HasKey(e => e.IdTipoRelacion);

                entity.ToTable("TIPOSRELACIONES");

                entity.Property(e => e.IdTipoRelacion)
                    .HasColumnName("idTipoRelacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescripcionTipoRelacion)
                    .IsRequired()
                    .HasColumnName("descripcionTipoRelacion")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Tipotelefonos>(entity =>
            {
                entity.HasKey(e => e.IdTipoTelefono);

                entity.ToTable("TIPOTELEFONOS");

                entity.Property(e => e.IdTipoTelefono).HasColumnName("idTipoTelefono");

                entity.Property(e => e.DescripcionTipoTelefono)
                    .IsRequired()
                    .HasColumnName("descripcionTipoTelefono")
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Tipotelefonos)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TIPOTELEF__idEst__7F2BE32F");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFK");

                entity.Property(e => e.IdInstitucionFk).HasColumnName("idInstitucionFK");

                entity.Property(e => e.IdPersonaFk).HasColumnName("idPersonaFK");

                entity.Property(e => e.IdRolFk).HasColumnName("idRolFK");

                entity.Property(e => e.NameUsuario)
                    .IsRequired()
                    .HasColumnName("nameUsuario")
                    .HasColumnType("text");

                entity.Property(e => e.PasswordUsuario)
                    .IsRequired()
                    .HasColumnName("passwordUsuario")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEstadoFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__idEsta__19DFD96B");

                entity.HasOne(d => d.IdInstitucionFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdInstitucionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__idInst__5D95E53A");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__idPers__1BC821DD");

                entity.HasOne(d => d.IdRolFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRolFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__idRolF__1AD3FDA4");
            });
        }
    }
}
