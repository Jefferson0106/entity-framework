using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectoef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1b02"), null, "Actividades personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1bfe"), null, "Actividades pendiente", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1b10"), new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1b02"), null, new DateTime(2024, 2, 26, 15, 52, 17, 734, DateTimeKind.Local).AddTicks(3557), 0, "terminar la pelicula" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1b11"), new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1bfe"), null, new DateTime(2024, 2, 26, 15, 52, 17, 734, DateTimeKind.Local).AddTicks(3538), 1, "pago de servicio " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1b10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1b11"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1b02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("d75a4879-cb18-40c3-94a5-3d80bafb1bfe"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
