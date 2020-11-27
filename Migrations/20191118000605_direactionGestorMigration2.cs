using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIRECTION_GESTOR.Migrations
{
    public partial class direactionGestorMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ARCHIVOS__idInst__55F4C372",
                table: "ARCHIVOS");

            migrationBuilder.RenameColumn(
                name: "idInstitucionFK",
                table: "ARCHIVOS",
                newName: "idPersonaFK");

            migrationBuilder.RenameIndex(
                name: "IX_ARCHIVOS_idInstitucionFK",
                table: "ARCHIVOS",
                newName: "IX_ARCHIVOS_idPersonaFK");

            migrationBuilder.AddColumn<int>(
                name: "idInstitucionFK",
                table: "SALUDOBSERVACIONES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idInstitucionFK",
                table: "RESPONSABILIDADOBSERVACIONES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idSexoFK",
                table: "PERSONAS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idInstitucionFK",
                table: "CONDUCTAOBSERVACIONES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "INSTITUCIONESARCHIVOS",
                columns: table => new
                {
                    idArchivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enlaceArchivo = table.Column<string>(type: "text", nullable: false),
                    fechaArchivo = table.Column<DateTime>(type: "date", nullable: false),
                    hora = table.Column<TimeSpan>(nullable: false),
                    idTipoArchivoFK = table.Column<int>(nullable: false),
                    idEstadoFK = table.Column<int>(nullable: false),
                    idInstitucionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTITUCIONESARCHIVOS", x => x.idArchivo);
                    table.ForeignKey(
                        name: "FK__INSTITUCI__idIns__793DFFAF",
                        column: x => x.idInstitucionFK,
                        principalTable: "INSTITUCIONES",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SEXOS",
                columns: table => new
                {
                    idSexo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcionSexo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEXOS", x => x.idSexo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SALUDOBSERVACIONES_idInstitucionFK",
                table: "SALUDOBSERVACIONES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONAS_idSexoFK",
                table: "PERSONAS",
                column: "idSexoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CONDUCTAOBSERVACIONES_idInstitucionFK",
                table: "CONDUCTAOBSERVACIONES",
                column: "idInstitucionFK");

            migrationBuilder.CreateIndex(
                name: "IX_INSTITUCIONESARCHIVOS_idInstitucionFK",
                table: "INSTITUCIONESARCHIVOS",
                column: "idInstitucionFK");

            migrationBuilder.AddForeignKey(
                name: "FK__ARCHIVOS__idPers__76619304",
                table: "ARCHIVOS",
                column: "idPersonaFK",
                principalTable: "PERSONAS",
                principalColumn: "idPersona",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__CONDUCTAO__idIns__74794A92",
                table: "CONDUCTAOBSERVACIONES",
                column: "idInstitucionFK",
                principalTable: "INSTITUCIONES",
                principalColumn: "idInstitucion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PERSONAS__idSexo__0880433F",
                table: "PERSONAS",
                column: "idSexoFK",
                principalTable: "SEXOS",
                principalColumn: "idSexo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__SALUDOBSE__idIns__756D6ECB",
                table: "SALUDOBSERVACIONES",
                column: "idInstitucionFK",
                principalTable: "INSTITUCIONES",
                principalColumn: "idInstitucion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ARCHIVOS__idPers__76619304",
                table: "ARCHIVOS");

            migrationBuilder.DropForeignKey(
                name: "FK__CONDUCTAO__idIns__74794A92",
                table: "CONDUCTAOBSERVACIONES");

            migrationBuilder.DropForeignKey(
                name: "FK__PERSONAS__idSexo__0880433F",
                table: "PERSONAS");

            migrationBuilder.DropForeignKey(
                name: "FK__SALUDOBSE__idIns__756D6ECB",
                table: "SALUDOBSERVACIONES");

            migrationBuilder.DropTable(
                name: "INSTITUCIONESARCHIVOS");

            migrationBuilder.DropTable(
                name: "SEXOS");

            migrationBuilder.DropIndex(
                name: "IX_SALUDOBSERVACIONES_idInstitucionFK",
                table: "SALUDOBSERVACIONES");

            migrationBuilder.DropIndex(
                name: "IX_PERSONAS_idSexoFK",
                table: "PERSONAS");

            migrationBuilder.DropIndex(
                name: "IX_CONDUCTAOBSERVACIONES_idInstitucionFK",
                table: "CONDUCTAOBSERVACIONES");

            migrationBuilder.DropColumn(
                name: "idInstitucionFK",
                table: "SALUDOBSERVACIONES");

            migrationBuilder.DropColumn(
                name: "idInstitucionFK",
                table: "RESPONSABILIDADOBSERVACIONES");

            migrationBuilder.DropColumn(
                name: "idSexoFK",
                table: "PERSONAS");

            migrationBuilder.DropColumn(
                name: "idInstitucionFK",
                table: "CONDUCTAOBSERVACIONES");

            migrationBuilder.RenameColumn(
                name: "idPersonaFK",
                table: "ARCHIVOS",
                newName: "idInstitucionFK");

            migrationBuilder.RenameIndex(
                name: "IX_ARCHIVOS_idPersonaFK",
                table: "ARCHIVOS",
                newName: "IX_ARCHIVOS_idInstitucionFK");

            migrationBuilder.AddForeignKey(
                name: "FK__ARCHIVOS__idInst__55F4C372",
                table: "ARCHIVOS",
                column: "idInstitucionFK",
                principalTable: "INSTITUCIONES",
                principalColumn: "idInstitucion",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
